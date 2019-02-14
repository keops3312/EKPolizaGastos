


namespace EKPolizaGastos
{


    #region Libraries (Librerias)
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using DevComponents.DotNetBar;
    using DevComponents.DotNetBar.Rendering;
    using EKPolizaGastos.Common.Classes;
    using EKPolizaGastos.Context;
    using EKPolizaGastos.Forms;
    using System.IO.Compression;
    using System.Data;
    using System.Globalization;
    using System.Drawing;
    using ClosedXML.Excel;
    #endregion



    public partial class Form1 : DevComponents.DotNetBar.Office2007Form 
    {

        #region Context
        private SEMP_SATContext db;
        #endregion

        #region Attributtes
        private FolderBrowserDialog folderBrowserDialog;
        private ReadSATFactura readSATFactura;
        private diotClass diot;
        private ReadSatNominas readSatNominas;
        private ReadSatFactura2 readSatFactura2;
        #endregion

        #region Properties
        private string path;
        private string cnx;
        private int cantidad;
        private string letra;
        private string[] dirs;
        private string[] xmlFiles;
        private string nameFile;
        private int TotalRegistrosEnNuevaTabla;
        public string ejercicio;
        private string NoEmpresa;
        private string nombreBase;
        #endregion

        #region Methods


        public Form1()
        {
            InitializeComponent();
            db = new SEMP_SATContext();
            folderBrowserDialog = new FolderBrowserDialog();
            readSATFactura = new ReadSATFactura();
            readSatNominas = new ReadSatNominas();
            readSatFactura2 = new ReadSatFactura2();
            diot = new diotClass();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            CheckForIllegalCrossThreadCalls = false;//To Use Multi threads

            //RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, eOffice2007ColorScheme.Black);

            txtpath.Enabled = false;
            circularProgress1.Visible = false;
            btnLeer.Enabled = false;

            cnx = readSATFactura.CheckDataConection();

            LoadCompanies();


        }
        private void LoadPath()
        {
            cantidad = 0;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {

                path = folderBrowserDialog.SelectedPath;
                txtpath.Text = path;

                string[] dirs = Directory.GetFiles(path, "*.XML");

                cantidad = dirs.Length;
                lblCount.Text = "Numero de documentos XML encontrados: " + cantidad;

                showObjects();

            }




          

        }

        private void showObjects()
        {
            lblCount.Visible = true;
            lblLeyenda.Visible = true;
            txtpath.Visible = true;
        }

        private void hideObjects()
        {
            lblCount.Visible = false;
            lblLeyenda.Visible = false;
            txtpath.Visible = false;
        }

        private void ReadAndStart()
        {

            if (switchButton1.Value == true)
            {
                ReadSATFactura readSATFactura = new ReadSATFactura();

                TotalRegistrosEnNuevaTabla = readSATFactura.Scan(path, cnx, nameFile);


                readSATFactura.ToExcel(nameFile, path, cnx, txtpath.Text);
                LoadCompaniesProperties();

            }
            else
            {
                nombreBase = lblItemSeleted.Text.Substring(0, nameFile.Length);
                readSatNominas.NombreBase = nombreBase;
                TotalRegistrosEnNuevaTabla = readSatNominas.Scan(path, cnx, nombreBase);
                //LE CREAMOS EL EXCEL Y MOVEMOS A LA CARPETA 
                readSatNominas.ToExcel(nameFile, path, cnx, txtpath.Text);
                LoadCompaniesProperties();

            }

           

        }

        private void LoadCompaniesProperties()
        {

            if (listZip.Items.Count> 0)
            {
                for (int i = listZip.Items.Count-1; i >= 0; i--)
                {
                    listZip.Items.RemoveAt(i);

                }

               

            }

          
            
            letra = cmbEmpresa.SelectedValue.ToString();
            lblItemSeleted.Text = "-";
            NoEmpresa = Convert.ToString(diot.EmpresaId(letra, cnx));

            if (!String.IsNullOrEmpty(letra))
            {
                var empresa = db.Empresas.Where(p => p.Letra == letra).First();

                //Nueva linea para Defini si es la carga de archivos tipo Gastos o Nomina
                if (switchButton1.Value == true)
                {
                    txtpath.Text = empresa.Path;
                }
                else
                {
                   txtpath.Text = empresa.PathNomina;
                }




               
                lblEmpresa.Text = "Empresa Seleccionada: \n" + empresa.Empresa;
                //Buscamos archivos zip comprimidos y agregamos a la lista

                 dirs = Directory.GetFiles(txtpath.Text, "*.zip");

                cantidad = dirs.Length;

                ExistZipFiles();

              
            }

            DataTable list = new DataTable();
            //Lista de Bases de datos de Gastos
            if (switchButton1.Value == true)
            {
                list = readSATFactura.ToListDTB(letra.Trim(), cnx);
            }
            //Lista de Base de Datos de Nominas
            else
            {
                list = readSatNominas.ToListDTB(letra.Trim(), cnx);
            }


           
          

            listTables.Items.Clear();
            listBox1.Items.Clear();
            foreach (DataRow item in list.Rows)
            {
               // listTables.Items.Add(item[0].ToString());

                listBox1.Items.Add(item[0].ToString());
            }


            foreach (DataRow item in list.Rows)
            {
                // listTables.Items.Add(item[0].ToString());

                listTables.Items.Add(item[0].ToString(),1);
            }

            //cargamos la lista de los meses que ya se cargaron dentor de la base de datos por letra de empresa

            return;
           
        }

        private void ExistZipFiles()
        {
            if (cantidad >= 1)
            {
                foreach (var zip in dirs)
                {

                    if (switchButton1.Value == true)
                    {
                        listZip.Items.Add(zip.Substring(13));
                    }
                    else
                    {
                        listZip.Items.Add(zip.Substring(22));
                    }


                   
                }

                lblCount.Text = "Numero de documentos Zip encontrados: " + cantidad;
                btnCargarRuta.Enabled = true;
                return;
            }
            btnCargarRuta.Enabled = false;
            lblCount.Text = "No Existen archivos para Descomprimir";
            return;
          

        }

        private void LoadCompanies()
        {

            cmbEmpresa.DataSource = db.Empresas.ToList();
            cmbEmpresa.DisplayMember = "Empresa";
            cmbEmpresa.ValueMember = "Letra";

        }

        private void UnzipFolder()
        {
            
            nameFile = lblItemSeleted.Text;
            nameFile = nameFile.Substring(0, nameFile.Length - 4);


            if (Directory.Exists(txtpath.Text + "\\" + nameFile))
            {
                Directory.Delete(txtpath.Text + "\\" + nameFile, true);
            }

            ZipFile.ExtractToDirectory(txtpath.Text + "\\" + lblItemSeleted.Text, txtpath.Text + "\\" + nameFile);



            path = txtpath.Text + "\\" + nameFile;
           

            xmlFiles = Directory.GetFiles(path, "*.XML");

            cantidad = xmlFiles.Length;
            lblMessage.Text = "Numero de documentos XML encontrados: " + cantidad;

            //listView1.SmallImageList = imageList1;
            //listView1.View = View.List;
            foreach (var item in xmlFiles)
            {
                if (switchButton1.Value == true)
                {
                    listXML.Items.Add(item.Substring(26));
                }
                else
                {
                    listXML.Items.Add(item.Substring(38));
                }


               

            }


            foreach (var item in xmlFiles)
            {

                if (switchButton1.Value == true)
                {
                    listXML2.Items.Add(item.Substring(26), 0);
                }
                else
                {
                    listXML2.Items.Add(item.Substring(38), 0);
                }
               

            }



        }
        #endregion

        #region Events
        private void btnCargarRuta_Click(object sender, EventArgs e)
        {


            if (lblItemSeleted.Text.Length > 1)
            {
                circularProgress1.Visible = true;
                circularProgress1.IsRunning = true;
                backgroundWorker2.RunWorkerAsync();

            }
            else
            {
                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("No has seleccionado un archivo para descomprimir",
                    "EK Poliza Gastos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            

        }

        private void listTables_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listTables.Items.Count >= 1)
                {
                    ejercicio = listTables.SelectedItems[0].Text;


                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }

        }

        private void listTables_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (listTables.Items.Count >= 1)
                {
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        ejercicio = listTables.SelectedItems[0].Text;


                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtpath.Text))
            {
              

                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("NO hay ruta para leer Archivos XML","EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cantidad==0)
            {
                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("NO hay archivos XML para leer", "EKPolizaGastos",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

          
            circularProgress1.Visible = true;
            circularProgress1.IsRunning = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void listZip_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listZip.Items.Count >= 1)
                {
                    lblItemSeleted.Text = listZip.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
          


        }

        private void listZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (listZip.Items.Count >= 1)
                {
                    if (e.KeyChar == (char)Keys.Enter)
                    {

                        lblItemSeleted.Text = listZip.SelectedItem.ToString();

                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            
        }


        //Inicio del Formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            listXML2.View = View.Details;

            listXML2.Columns.Add("CFDI", 150);
            listXML2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listXML2.SmallImageList = imageList1;


            listTables.View = View.Details;

            listTables.Columns.Add("Ejercicios", 150);
            listTables.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listTables.SmallImageList = imageList1;


            cmbEmpresa.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbEmpresa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void btnCargarRuta_MouseHover(object sender, EventArgs e)
        {
           
            ToastNotification.Show(this, "Click para descomprimir carpeta",
                global::EKPolizaGastos.Properties.Resources.directorioM,2000,
                eToastGlowColor.Blue, eToastPosition.TopLeft);
        }

        private void btnLeer_MouseHover(object sender, EventArgs e)
        {
            ToastNotification.Show(this, "Click para comenzar a ingresar archivos XML",
               global::EKPolizaGastos.Properties.Resources.New_DatabaseP_fw, 2000,
               eToastGlowColor.Blue, eToastPosition.TopCenter);
        }

        private void btnPoliza_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ejercicio))
            {
                TaskDialogInfo info = CreateTaskDialogInfoInv();
                eTaskDialogResult result = TaskDialog.Show(info);
            }




            MessageBoxEx.EnableGlass = false;
            MessageBoxEx.Show("No has Seleccionado Ejercicio!",
                "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCompaniesProperties();
        }
        #endregion

        #region BackGroudnWorker
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ReadAndStart();
            Thread.Sleep(1000);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            circularProgress1.Value = e.ProgressPercentage;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            circularProgress1.Visible = false;
            circularProgress1.IsRunning = false;



          
            MessageBoxEx.EnableGlass = false;
            MessageBoxEx.Show("Numero de XML's Capturados: " + TotalRegistrosEnNuevaTabla.ToString() + "",
                "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);



            listXML.Items.Clear();
            listXML2.Items.Clear();
            lblMessage.Text = "-";

          //  readSATFactura.InsertProvedores(cnx, nameFile, nameFile.Substring(0, 3)); //catch Provedors


        }


        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            UnzipFolder();
            Thread.Sleep(1000);
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            circularProgress1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            circularProgress1.Visible = false;
            circularProgress1.IsRunning = false;
            MessageBoxEx.EnableGlass = false;
            MessageBoxEx.Show("Carpeta Descomprimida con Exito", "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if(listXML.Items.Count > 0)
            {
                btnLeer.Enabled = true;
            }
        }






        #endregion

        #region EtaskDialogs
        private TaskDialogInfo CreateTaskDialogInfoInv()
        {
            TaskDialogInfo info = new TaskDialogInfo("EKPolizaGastos",
                                                        eTaskDialogIcon.Information,
                                                        "¿Que version Voy a Utilizar?",
                                                        "",
                                                        eTaskDialogButton.Cancel,
                                                        eTaskDialogBackgroundColor.Blue, null, GetCommandButtonsInvs(), null, "", null);

            return info;
        }
     
        private Command[] GetCommandButtonsInvs()
        {


            return new Command[] { command1, command2 };


        }
        #endregion
        //Crear Reporte de DIOT
        private void buttonX1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(ejercicio))
            {
                MessageBoxEx.EnableGlass = false;

                DialogResult result = MessageBoxEx.Show("¿Generar Diot del Ejercicio Seleccionado? (" + ejercicio + ")", "EKDIOT",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        {

                            BeginDiot();

                            break;
                        }
                    case DialogResult.No:
                        {

                            break;
                        }
                }
            }
            else
            {
                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("No has Seleccionado Ejercicio", "EKDIOT",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
                

        }


        //Generar DIOT
        private void BeginDiot()
        {
            try
            {
                string value = ".16";
                if (InputBox("Generacion de DIOT", "Ingrese el valor del IVA:", ref value) == DialogResult.OK)
                {
                    if (decimal.Parse(value)>0)
                    {

                        DataTable resultados = new DataTable();
                        //resultados = diot.ToListPRV(ejercicio, cnx, value, NoEmpresa, ejercicio.Substring(4, 3), ejercicio.Substring(7, 4));

                        //DataTable result = new DataTable();
                        //result = diot.DIOT(resultados, ejercicio, cnx, value, NoEmpresa, ejercicio.Substring(4, 3), ejercicio.Substring(7, 4));

                        //Export(result);
                        //Lo creamos con la nueva version para la diot
                        //Hacemos el desgloce
                        //ejercicio CIS-ENE2018 CIC ENE 2018
                        int no = int.Parse(NoEmpresa);
                        var rfc = db.Empresas.Where(p => p.IdEmpresa == no).First(); 
                        resultados = readSatFactura2.ToListPRV(ejercicio, cnx, value, rfc.RFC, ejercicio.Substring(4, 3), ejercicio.Substring(7, 4));

                        DataTable result = new DataTable();
                        result = readSatFactura2.DIOT(resultados, ejercicio, cnx, value, NoEmpresa, ejercicio.Substring(4, 3), ejercicio.Substring(7, 4));

                        Export(result);

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("Valor no Valido para Generar DIOT" + ex.Message, "EKDIOT",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }


        public void Export(DataTable Result)
        {
            string ruta;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                ruta = saveFileDialog1.FileName;

                if (string.IsNullOrEmpty(ruta))
                {
                    MessageBoxEx.EnableGlass = false;
                    MessageBoxEx.Show("No hay directorio Seleccionado",
                        "EKDIOT", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {

                    //Formato a las filas
                    Result.Columns[3].DataType = System.Type.GetType("System.Decimal");
                    Result.Columns[4].DataType = System.Type.GetType("System.Decimal");
                    Result.Columns[5].DataType = System.Type.GetType("System.Decimal");

                    DataView dataview = new DataView(Result);

                    //ALTERNAMENTE DISEÑAMOS EL BLOC DE NOTAS
                    using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(ruta + ".txt"))
                    {
                        int importe;
                        string rfc;
                       
                       
                        for (int i = 0;  i <Result.Rows.Count-1;  i++)
                        {
                            rfc = Result.Rows[i][1].ToString();
                            
                          
                            if (decimal.Parse(Result.Rows[i][4].ToString()) > 0)
                            {
                                importe = (int)Math.Round(Convert.ToDouble(Result.Rows[i][4].ToString()), 0, MidpointRounding.ToEven);
                                escritor.WriteLine("04|85|" + rfc + "|||||" + importe + "||||||||||||||||");
                            }
                        }
                      

                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        //wb.Cells("Iva_Trasladado").Style.NumberFormat.Format = "C2";//$0.00
                        //wb.Cells("Base").Style.NumberFormat.Format = "C2";
                        //wb.Cells("Iva_Trasladado_Calculado").Style.NumberFormat.Format = "C2";

                       // wb.Cells().DataType = XLDataType.Number.ToString("C2"); 

                        wb.Worksheets.Add(dataview.ToTable());
                        wb.SaveAs(ruta);

                    }

                    MessageBoxEx.EnableGlass = false;
                    MessageBoxEx.Show("DIOT GENERADA CON EXITO" , "EKDIOT",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
          
           

        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new System.Drawing.Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new System.Drawing.Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void switchButton1_ValueChanged(object sender, EventArgs e)
        {
            LoadCompaniesProperties();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            ExcelForm excel = new ExcelForm();
            excel.ShowDialog();
        }


        //1 version
        private void command1_Executed(object sender, EventArgs e)
        {
            MessageBoxEx.EnableGlass = false;
            MessageBoxEx.Show("Ejercicio Elejido: " + ejercicio + "",
                "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PlantillaPrepolizaForm plantillaPrepoliza = new PlantillaPrepolizaForm();
            plantillaPrepoliza.ejercicio = ejercicio;
            plantillaPrepoliza.path = txtpath.Text;
            plantillaPrepoliza.cnx = cnx;
            plantillaPrepoliza.ShowDialog();
            return;
        }
        //2 version
        private void command2_Executed(object sender, EventArgs e)
        {
            MessageBoxEx.EnableGlass = false;
            MessageBoxEx.Show("Ejercicio Elejido: " + ejercicio + "",
                "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PolizaSatForm polizaSatForm = new PolizaSatForm();
            polizaSatForm.ejercicio = ejercicio;
            polizaSatForm.path = txtpath.Text;
            polizaSatForm.cnx = cnx;
            polizaSatForm.ShowDialog();
            return;
        }
        
        
        
        //NUEVA VERSION
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            VentanaForm ventanaForm = new VentanaForm();
            ventanaForm.ShowDialog();
        }
        //VERSION ANTERIOR
        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
