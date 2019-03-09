using ClosedXML.Excel;
using DevComponents.DotNetBar;
using EKPolizaGastos.Common.Classes;
using EKPolizaGastos.Context;
using EKPolizaGastos.Data;
using EKPolizaGastos.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EKPolizaGastos.Forms
{
    public partial class VentanaForm : DevComponents.DotNetBar.Office2007Form
    {
        #region Context
        private SEMP_SATContext db;
        private ReadSATFactura readSATFactura;
        private FolderBrowserDialog folderBrowserDialog;
        private ReadSatNominas readSatNominas;
        private ReadSatFactura2 readSatFactura2;
        private diotClass diot;
        #endregion

        private string ejercicio;
        public VentanaForm()
        {
           
            db = new SEMP_SATContext();
            folderBrowserDialog = new FolderBrowserDialog();
            readSATFactura = new ReadSATFactura();
            readSatNominas = new ReadSatNominas();
            readSatFactura2 = new ReadSatFactura2();
            diot = new diotClass();
            InitializeComponent();
        }
        private void LoadF()
        {

            DataRow myNewRow;
            DataTable dataTable = new DataTable("TiposFacturas");
            DataColumn colInt32 = new DataColumn("IdTipo");
            colInt32.DataType = System.Type.GetType("System.Int32");

            DataColumn colString = new DataColumn("Tipo");
            colString.DataType = System.Type.GetType("System.String");

            dataTable.Columns.Add(colInt32);
            dataTable.Columns.Add(colString);

            myNewRow = dataTable.NewRow();
            myNewRow["IdTipo"] = 1;
            myNewRow["Tipo"] = "Recibidas";
            dataTable.Rows.Add(myNewRow);

            myNewRow = dataTable.NewRow();
            myNewRow["IdTipo"] = 2;
            myNewRow["Tipo"] = "Emitidas";
            dataTable.Rows.Add(myNewRow);

            myNewRow = dataTable.NewRow();
            myNewRow["IdTipo"] = 3;
            myNewRow["Tipo"] = "Nomina";
            dataTable.Rows.Add(myNewRow);



            cmbTipoFactura.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTipoFactura.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTipoFactura.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbEmpresa.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbEmpresa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;


            cmbAno.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbAno.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAno.DropDownStyle = ComboBoxStyle.DropDownList;


            cmbMes.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbMes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMes.DropDownStyle = ComboBoxStyle.DropDownList;



            cmbTipoFactura.DataSource = dataTable;
            cmbTipoFactura.DisplayMember = "Tipo";
            cmbTipoFactura.ValueMember = "IdTipo";


            cmbEmpresa.DataSource = db.Empresas.ToList();
            cmbEmpresa.DisplayMember = "Empresa";
            cmbEmpresa.ValueMember = "IdEmpresa";
        }
        private void VentanaForm_Load(object sender, EventArgs e)
        {
            LoadF();

        }

      

        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadAnosCargados();
        }

        private void loadAnosCargados()
        {
            try
            {
                int NoEmpresa = int.Parse(cmbEmpresa.SelectedValue.ToString());
                int tipoFacturas = int.Parse(cmbTipoFactura.SelectedValue.ToString());

                var empresa = db.Empresas.Where(p => p.IdEmpresa == NoEmpresa).FirstOrDefault();
                if (cmbAno.Items.Count > 0)
                {

                    cmbAno.Items.Clear();
                }


                if (tipoFacturas == 1)
                {
                    if (empresa.Letra.Trim() == "CIS")
                    {
                        var Resultado = (from s in db.CISFACTRECIBIDAS
                                         select s.Ano).Distinct();
                        cmbAno.DataSource = Resultado.ToList();
                        loadMesesCargados();
                    }

                    if (empresa.Letra.Trim() == "MRO")
                    {
                        var Resultado = (from s in db.MROFACTRECIBIDAS
                                         select s.Ano).Distinct();
                        cmbAno.DataSource = Resultado.ToList();
                        loadMesesCargados();
                    }

                    if (empresa.Letra.Trim() == "CMG")
                    {
                        var Resultado = (from s in db.CMGFACTRECIBIDAS
                                         select s.Ano).Distinct();
                        cmbAno.DataSource = Resultado.ToList();
                        loadMesesCargados();
                    }

                    if (empresa.Letra.Trim() == "DDR")
                    {
                        var Resultado = (from s in db.DDRFACTRECIBIDAS
                                         select s.Ano).Distinct();
                        cmbAno.DataSource = Resultado.ToList();

                        loadMesesCargados();

                    }

                    if (empresa.Letra.Trim() == "JMR")
                    {
                        var Resultado = (from s in db.JMRFACTRECIBIDAS
                                         select s.Ano).Distinct();
                        cmbAno.DataSource = Resultado.ToList();
                        //los meses
                        loadMesesCargados();

                    }



                }

                //EMITIDAS
                if (tipoFacturas == 2)
                {
                    if (empresa.Letra.Trim() == "CIS")
                    {
                        var Resultado = (from s in db.CISFACTSEMITIDAS
                                         select s.Ano).Distinct();
                        cmbAno.DataSource = Resultado.ToList();
                        loadMesesCargados();
                    }

                    if (empresa.Letra.Trim() == "MRO")
                    {
                        var Resultado = (from s in db.MROFACTSEMITIDAS
                                         select s.Ano).Distinct();
                        cmbAno.DataSource = Resultado.ToList();
                        loadMesesCargados();
                    }

                    if (empresa.Letra.Trim() == "CMG")
                    {
                        var Resultado = (from s in db.CMGFACTSEMITIDAS
                                         select s.Ano).Distinct();
                        cmbAno.DataSource = Resultado.ToList();
                        loadMesesCargados();
                    }

                    if (empresa.Letra.Trim() == "DDR")
                    {
                        var Resultado = (from s in db.DDRFACTSEMITIDAS
                                         select s.Ano).Distinct();
                        cmbAno.DataSource = Resultado.ToList();

                        loadMesesCargados();

                    }

                    if (empresa.Letra.Trim() == "JMR")
                    {
                        var Resultado = (from s in db.JMRFACTSEMITIDAS
                                         select s.Ano).Distinct();
                        cmbAno.DataSource = Resultado.ToList();
                        //los meses
                        loadMesesCargados();

                    }



                }

                //NOMINA

            }
            catch (Exception)
            {
                //MessageBoxEx.EnableGlass = false;
                //MessageBoxEx.Show("Esta Empresa No Contiene Ejercicios",
                //"EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void loadMesesCargados()
        {

            try
            {
                int NoEmpresa = int.Parse(cmbEmpresa.SelectedValue.ToString());
                int tipoFacturas = int.Parse(cmbTipoFactura.SelectedValue.ToString());

                var empresa = db.Empresas.Where(p => p.IdEmpresa == NoEmpresa).FirstOrDefault();
                int ano = int.Parse(cmbAno.Text);

                if (cmbMes.Items.Count > 0)
                {

                    cmbMes.Items.Clear();
                }

                if (tipoFacturas == 1)
                {
                    if (empresa.Letra.Trim() == "CIS")
                    {
                        var Resultado = (from s in db.CISFACTRECIBIDAS
                                         where s.Ano == ano
                                         select s.Mes).Distinct();

                        foreach (var item in Resultado)
                        {
                            mesConvertido(item.Value);
                        }



                    }

                    if (empresa.Letra.Trim() == "MRO")
                    {
                        var Resultado = (from s in db.MROFACTRECIBIDAS
                                         where s.Ano == ano
                                         select s.Mes).Distinct();

                        foreach (var item in Resultado)
                        {
                            mesConvertido(item.Value);
                        }

                    }

                    if (empresa.Letra.Trim() == "CMG")
                    {
                        var Resultado = (from s in db.CMGFACTRECIBIDAS
                                         where s.Ano == ano
                                         select s.Mes).Distinct();

                        foreach (var item in Resultado)
                        {
                            mesConvertido(item.Value);
                        }

                    }

                    if (empresa.Letra.Trim() == "DDR")
                    {
                        var Resultado = (from s in db.DDRFACTRECIBIDAS
                                         where s.Ano == ano
                                         select s.Mes).Distinct();

                        foreach (var item in Resultado)
                        {
                            mesConvertido(item.Value);
                        }


                    }

                    if (empresa.Letra.Trim() == "JMR")
                    {
                        var Resultado = (from s in db.JMRFACTRECIBIDAS
                                         where s.Ano == ano
                                         select s.Mes).Distinct();

                        foreach (var item in Resultado)
                        {
                            mesConvertido(item.Value);
                        }

                    }



                }

                //EMITIDAS
                if (tipoFacturas == 2)
                {
                    if (empresa.Letra.Trim() == "CIS")
                    {
                        var Resultado = (from s in db.CISFACTSEMITIDAS
                                         where s.Ano == ano
                                         select s.Mes).Distinct();

                        foreach (var item in Resultado)
                        {
                            mesConvertido(item.Value);
                        }



                    }

                    if (empresa.Letra.Trim() == "MRO")
                    {
                        var Resultado = (from s in db.MROFACTSEMITIDAS
                                         where s.Ano == ano
                                         select s.Mes).Distinct();

                        foreach (var item in Resultado)
                        {
                            mesConvertido(item.Value);
                        }

                    }

                    if (empresa.Letra.Trim() == "CMG")
                    {
                        var Resultado = (from s in db.CMGFACTSEMITIDAS
                                         where s.Ano == ano
                                         select s.Mes).Distinct();

                        foreach (var item in Resultado)
                        {
                            mesConvertido(item.Value);
                        }

                    }

                    if (empresa.Letra.Trim() == "DDR")
                    {
                        var Resultado = (from s in db.DDRFACTSEMITIDAS
                                         where s.Ano == ano
                                         select s.Mes).Distinct();

                        foreach (var item in Resultado)
                        {
                            mesConvertido(item.Value);
                        }


                    }

                    if (empresa.Letra.Trim() == "JMR")
                    {
                        var Resultado = (from s in db.JMRFACTSEMITIDAS
                                         where s.Ano == ano
                                         select s.Mes).Distinct();

                        foreach (var item in Resultado)
                        {
                            mesConvertido(item.Value);
                        }

                    }



                }

                //NOMINA
            }
            catch (Exception)
            {
                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("Esta Empresa No Contiene Ejercicios",
                "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void mesConvertido(int Value)
        {
            if (Value == 1)
            {
                cmbMes.Items.Add("ENERO");
            }
            if (Value == 2)
            {
                cmbMes.Items.Add("FEBRERO");
            }
            if (Value == 3)
            {
                cmbMes.Items.Add("MARZO");
            }
            if (Value == 4)
            {
                cmbMes.Items.Add("ABRIL");
            }
            if (Value == 5)
            {
                cmbMes.Items.Add("MAYO");
            }
            if (Value == 6)
            {
                cmbMes.Items.Add("JUNIO");
            }
            if (Value == 7)
            {
                cmbMes.Items.Add("JULIO");
            }
            if (Value == 8)
            {
                cmbMes.Items.Add("AGOSTO");
            }
            if (Value == 9)
            {
                cmbMes.Items.Add("SEPTIEMBRE");
            }
            if (Value == 10)
            {
                cmbMes.Items.Add("OCTUBRE");
            }
            if (Value == 11)
            {
                cmbMes.Items.Add("NOVIEMBRE");
            }
            if (Value == 12)
            {
                cmbMes.Items.Add("DICIEMBRE");
            }
        }


        private void cmbEmpresa_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
           // loadAnosCargados();
        }

        private void cmbAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMesesCargados();
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }
        //MANDO EL EJERCICIO 
        private void btnComenzar_Click(object sender, EventArgs e)
        {
          
            int idEmpresa =int.Parse(cmbEmpresa.SelectedValue.ToString());
            var empresa = db.Empresas.Where(p => p.IdEmpresa == idEmpresa).FirstOrDefault();
            int tipoFacturas = int.Parse(cmbTipoFactura.SelectedValue.ToString());

            if(empresa!=null && cmbMes.Text!="" && cmbAno.Text != "")
            {
                ejercicio = empresa.Letra.Trim() + "-" + cmbMes.Text.Substring(0, 3) + cmbAno.Text;

                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("Ejercicio Elejido: " + ejercicio + "",
                    "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PolizaSatForm polizaSatForm = new PolizaSatForm();
                polizaSatForm.ejercicio = ejercicio;
                if (tipoFacturas == 1)
                {
                    polizaSatForm.path = empresa.Path;
                }
                if (tipoFacturas == 2)
                {
                    polizaSatForm.path = empresa.PathNomina;
                    //JMR_EMI_ENE2018
                }
                this.Hide();
                string cnx = readSATFactura.CheckDataConection();
                polizaSatForm.tipoDeBase = cmbTipoFactura.Text;
                polizaSatForm.cnx = cnx;
                polizaSatForm.ShowDialog();
                //this.Close();
                return;

            }
            else
            {

                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("NO has seleccionado bien el Ejercicio!",
                    "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

         
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OpcionVersionForm opcionVersionForm = new OpcionVersionForm();
            opcionVersionForm.p= 1;
            opcionVersionForm.Show();
            this.Close();
        }

        private void btnDiot_Click(object sender, EventArgs e)
        {
           
            int idEmpresa = int.Parse(cmbEmpresa.SelectedValue.ToString());
            var empresa = db.Empresas.Where(p => p.IdEmpresa == idEmpresa).FirstOrDefault();
            if (empresa != null && cmbMes.Text != "" && cmbAno.Text != "")
            {
                ejercicio = empresa.Letra.Trim() + "-" + cmbMes.Text.Substring(0, 3) + cmbAno.Text;


               
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
                MessageBoxEx.Show("NO has seleccionado bien el Ejercicio!",
                    "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }








        }

        private void BeginDiot()
        {
            try
            {
                string value = ".16";
                string cnx = readSATFactura.CheckDataConection();
                int NoEmpresa = int.Parse(cmbEmpresa.SelectedValue.ToString());
                if (InputBox("Generacion de DIOT", "Ingrese el valor del IVA:", ref value) == DialogResult.OK)
                {
                    if (decimal.Parse(value) > 0)
                    {

                        DataTable resultados = new DataTable();
                       
                        //ejercicio CIS-ENE2018 CIC ENE 2018
                        int no = NoEmpresa;
                        var rfc = db.Empresas.Where(p => p.IdEmpresa == no).First();
                        resultados = readSatFactura2.ToListPRV(ejercicio, cnx, value, rfc.RFC, ejercicio.Substring(4, 3), ejercicio.Substring(7, 4));

                        DataTable result = new DataTable();
                        result = readSatFactura2.DIOT(resultados, ejercicio, cnx, value, no.ToString(), ejercicio.Substring(4, 3), ejercicio.Substring(7, 4));

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

            int idEmpresa = int.Parse(cmbEmpresa.SelectedValue.ToString());
            var empresa = db.Empresas.Where(p => p.IdEmpresa == idEmpresa).FirstOrDefault();
           
          
            Result.TableName="DIOT";
            DiotForm diotForm = new DiotForm();
            diotForm.Resultado = Result;
            diotForm.empresa = empresa.Empresa;
            diotForm.mes = cmbMes.Text;
            diotForm.ano = cmbAno.Text;
            diotForm.rfc = empresa.RFC;
            diotForm.ShowDialog();


            //string ruta;
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            //saveFileDialog1.FilterIndex = 2;
            //saveFileDialog1.RestoreDirectory = true;

            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{

            //    ruta = saveFileDialog1.FileName;

            //    if (string.IsNullOrEmpty(ruta))
            //    {
            //        MessageBoxEx.EnableGlass = false;
            //        MessageBoxEx.Show("No hay directorio Seleccionado",
            //            "EKDIOT", MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //    }
            //    else
            //    {

            //        DiotForm diotForm = new DiotForm();
            //        diotForm.Resultado = Result;



            //        //LocalidadModel localidadModel = new LocalidadModel();
            //        //localidadModel.localidadResult(loc);
            //        //ob.SetParameterValue("tipos", leyendaTipos);
            //        //ob.SetParameterValue("estatus", leyendaEstatus);
            //        //ob.SetParameterValue("rangos", leyendaRango);
            //        //ob.SetParameterValue("modoOrden", mode);

            //        //ob.SetParameterValue("sucursal", localidadModel.sucursal);
            //        //ob.SetParameterValue("marca", localidadModel.marca);
            //        //ob.SetParameterValue("empresa", localidadModel.empresa);
            //        //ob.SetParameterValue("localidad", localidadModel.localidad);
            //        //ob.SetParameterValue("encargado", localidadModel.encargado);
            //        //ob.SetParameterValue("logo", localidadModel.logotipo);



            //        //crystalReportViewer1.ReportSource = ob;
            //        //crystalReportViewer1.Refresh();
            //        //Formato a las filas
            //        //Result.Columns[3].DataType = System.Type.GetType("System.Decimal");
            //        //Result.Columns[4].DataType = System.Type.GetType("System.Decimal");
            //        //Result.Columns[5].DataType = System.Type.GetType("System.Decimal");

            //        //DataView dataview = new DataView(Result);



            //        ////ALTERNAMENTE DISEÑAMOS EL BLOC DE NOTAS
            //        //using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(ruta + ".txt"))
            //        //{
            //        //    int Base;
            //        //    int NoGrabanIVA;
            //        //    int IvaRetenido;
            //        //    int IvaEgreso;

            //        //    string tipo;
            //        //    string rfc;

            //        //  //  ResultadoDIOT.Rows.Add(RFC_Emisor, Proveedor_Emisor, iva_calculado,
            //        //  //Iva_trasladado , BaseR , conceptoSinIva, IdEmpresa, Mes, Periodo);
            //        //    for (int i = 0; i < Result.Rows.Count; i++)
            //        //    {
            //        //        rfc = Result.Rows[i][0].ToString();
            //        //        tipo= Result.Rows[i][14].ToString();

                           
            //        //        Base = (int)Math.Round(Convert.ToDouble(Result.Rows[i][4].ToString()), 0, MidpointRounding.ToEven);
            //        //        IvaRetenido = (int)Math.Round(Convert.ToDouble(Result.Rows[i][5].ToString()), 0, MidpointRounding.ToEven);
            //        //        NoGrabanIVA = (int)Math.Round(Convert.ToDouble(Result.Rows[i][7].ToString()), 0, MidpointRounding.ToEven);
            //        //        IvaEgreso =(int)Math.Round(Convert.ToDouble(Result.Rows[i][8].ToString()), 0, MidpointRounding.ToEven);

            //        //        string batch;
            //        //        batch = "04|85|" + rfc + "|||||" + Base + "||||||||||||" + NoGrabanIVA + "||" + IvaRetenido + "|"+IvaEgreso+"|";

            //        //        escritor.WriteLine(batch);
                         
            //        //      //checar con ingeniero las notas de credito con devoluciones y compensaciones esto deberia
            //        //      //ir en el campo 23, es decir el ultimo y la base como cero


                                
            //        //    }


            //        //}

            //        //using (XLWorkbook wb = new XLWorkbook())
            //        //{
                       
            //        //    wb.Worksheets.Add(dataview.ToTable());
            //        //    wb.SaveAs(ruta);

            //        //}

            //        //MessageBoxEx.EnableGlass = false;
            //        //MessageBoxEx.Show("DIOT GENERADA CON EXITO", "EKDIOT",
            //        //MessageBoxButtons.OK, MessageBoxIcon.Information);


            //    }
            //}



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

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            ExcelForm excel = new ExcelForm();
            excel.ShowDialog();
        }
    }
}
