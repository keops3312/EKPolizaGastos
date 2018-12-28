


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
    #endregion



    public partial class Form1 : DevComponents.DotNetBar.Office2007Form 
    {

        #region Context
        private SEMP_SATConetxt db;
        #endregion

        #region Attributtes
        private FolderBrowserDialog folderBrowserDialog;
        private ReadSATFactura readSATFactura;
        
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
        
        #endregion

        #region Methods


        public Form1()
        {
            InitializeComponent();
            db = new SEMP_SATConetxt();
            folderBrowserDialog = new FolderBrowserDialog();
            readSATFactura = new ReadSATFactura();

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

            ReadSATFactura readSATFactura = new ReadSATFactura();

            TotalRegistrosEnNuevaTabla = readSATFactura.Scan(path,cnx,nameFile);

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

            if (!String.IsNullOrEmpty(letra))
            {
                var empresa = db.Empresas.Where(p => p.Letra == letra).First();

                txtpath.Text = empresa.Path;
                lblEmpresa.Text = "Empresa Seleccionada: " + empresa.Empresa;
                //Buscamos archivos zip comprimidos y agregamos a la lista

                 dirs = Directory.GetFiles(empresa.Path, "*.zip");

                cantidad = dirs.Length;

                ExistZipFiles();

              
            }

            DataTable list = new DataTable();
            list=readSATFactura.ToListDTB(letra.Trim(), cnx);

           // listTables.Items.Clear();
            listBox1.Items.Clear();
            foreach (DataRow item in list.Rows)
            {
               // listTables.Items.Add(item[0].ToString());

                listBox1.Items.Add(item[0].ToString());
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
                    listZip.Items.Add(zip.Substring(13));
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
                listXML.Items.Add(item.Substring(26));

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

                MessageBoxEx.Show("No has seleccionado un archivo para descomprimir",
                    "EK Poliza Gastos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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



        private void Form1_Load(object sender, EventArgs e)
        {
            
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
            PlantillaPrepolizaForm plantillaPrepoliza = new PlantillaPrepolizaForm();
            plantillaPrepoliza.ShowDialog();

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

            readSATFactura.ToExcel(nameFile, path,cnx,txtpath.Text);
            LoadCompaniesProperties();
            listXML.Items.Clear();
            lblMessage.Text = "-";
            


          
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
    }
}
