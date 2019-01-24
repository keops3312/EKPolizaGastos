

namespace EKPolizaGastos.Forms
{
   

    #region Libraries(librerias)
    using EKPolizaGastos.Context;
    using DevComponents.DotNetBar;
    using EKPolizaGastos.Common.Classes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    using System.Data.Entity;
    #endregion

    public partial class PlantillaPrepolizaForm : DevComponents.DotNetBar.Office2007Form
    {
        #region Context
        private SEMP_SATContext db;
        #endregion

        #region Properties
        ReadSATFactura readSATFactura;
        DataTable PolizaGrid;
        DataTable localidad;
        #endregion

        #region Attributes
        public string ejercicio;
        public string cnx;
        int indexGrid;
        int indexGridPosition=0;
        int totalFacturas=0;
        string file;
        //Poliza parameters

        string Proveedor;
        private string Proveedor_Completo;
        string RFC_proveedor;
        string IdF;
        int IdEmpresaEjercicio;
        string Proveedor_concepto;
        int IdEmpresa;

        string Cuenta_cargo_1;
        string Cuenta_cargo_2;
        string Cuenta_cargo_3;
        string Cuenta_cargo_Iva;
        string Cuenta_Abono_1;
        string Cuenta_Abono_2;
        string Cuenta_Abono_3;
        string Titulo_principal;
        string Titulo_secundario;
        string Titulo_tercero;
        string Departamento;
        string total;
        string iva;
        string isr_Retenido;
        string iva_Retenido;
        string Cuenta_isr_retenido;
        string Cuenta_iva_retenido;

        private string Importe;
        private string descripcionxml;
        private string baseX;
        private string importeX;
        private string impuestoX;
        private string tasaOCuotaX;
        private string tipoFactorX;
        private string TotalImpuestosTrasladados;
        private string UUID;
        public string path;//Para leer la factura
        private string Folio;
        private string primer_conccepto;
        private int IdLocalidad;
        #endregion

        #region Methods (metodos)
        public PlantillaPrepolizaForm()
        {
            InitializeComponent();

            db = new SEMP_SATContext();
            readSATFactura = new ReadSATFactura();
            localidad = new DataTable();


        }


        public void FillComboEmpresas()
        {

            localidad = readSATFactura.Localidades(cnx);

            cmbLocalidades.DataSource = localidad;
            cmbLocalidades.DisplayMember = "Localidad";
            cmbLocalidades.ValueMember = "IdLocalidad";

        }

        private string SearchMonth(string v)
        {
            string month = "";
            switch (v)
            {
                case "ENE":
                    month = "ENERO";
                    break;
                case "FEB":
                    month = "FEBRERO";
                    break;
                case "MAR":
                    month = "MARZO";
                    break;
                case "ABR":
                    month = "ABRIL";
                    break;
                case "MAY":
                    month = "MAYO";
                    break;
                case "JUN":
                    month = "JUNIO";
                    break;
                case "JUL":
                    month = "JULIO";
                    break;
                case "AGO":
                    month = "AGOSTO";
                    break;
                case "SEP":
                    month = "SEPTIEMBRE";
                    break;
                case "OCT":
                    month = "OCTUBRE";
                    break;
                case "NOV":
                    month = "NOVIEMBRE";
                    break;
                case "DIC":
                    month = "DICIEMBRE";
                    break;

                default:

                    break;


            }

            return month;
        }

        private string[] SearchMonthD(string v)
        {
            String[] month= new string[2];
            switch (v)
            {
                case "ENE":
                    month[0] = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 1).ToString();
                    month[1] = "01";
                     break;
                case "FEB":
                    month[0] = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 2).ToString();
                    month[1] = "02";
                    break;
                case "MAR":
                    month[0] = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 3).ToString();
                    month[1] = "03";
                    break;
                case "ABR":
                    month[0] = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 4).ToString();
                    month[1] = "04";
                    break;
                case "MAY":
                    month[0] = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 5).ToString();
                    month[1] = "05";
                    break;
                case "JUN":
                    month[0] = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 6).ToString();
                    month[1] = "06";
                    break;
                case "JUL":
                    month[0] = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 7).ToString();
                    month[1] = "07";
                    break;
                case "AGO":
                    month[0] = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 8).ToString();
                    month[1] = "08";
                    break;
                case "SEP":
                    month[0] = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 9).ToString();
                    month[1] = "09";
                    break;
                case "OCT":
                    month[0] = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 10).ToString();
                    month[1] = "10";
                    break;
                case "NOV":
                    month[0] = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 11).ToString();
                    month[1] = "11";
                    break;
                case "DIC":
                    month[0] = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 12).ToString();
                    month[1] = "12";
                    break;

                default:

                    break;


            }

            return month;
        }

        private void LoadF()
        {
            txtTipo.Text = "Eg";
            txtFecha.Text = "";

            cmbLocalidades.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbLocalidades.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbLocalidades.DropDownStyle = ComboBoxStyle.DropDownList;

            var datos = db.Empresas.Where(p => p.Letra == ejercicio.Substring(0, 3)).First();

            lblEmpresa.Text = "Empresa:  " + datos.Empresa;

            lblMes.Text = "Mes: " + SearchMonth(ejercicio.Substring(4, 3));

            lblAno.Text = "Año: " + ejercicio.Substring(7, 4);

            IdEmpresaEjercicio =datos.IdEmpresa;

            dataGridViewX1.DataSource = readSATFactura.listExercise(cnx, ejercicio);
            lblCantidad.Text = "Numero de CFDI cargados del mes: " + dataGridViewX1.Rows.Count;
            totalFacturas = dataGridViewX1.Rows.Count;

            string[] result = SearchMonthD(ejercicio.Substring(4, 3));

            FillComboEmpresas();
           
            StartPoliza();
          
        }

        public void StartPoliza()
        {
            DataTable facturas= new DataTable("Facturas");

            facturas = readSATFactura.listExercise(cnx, ejercicio);

            dataGridViewX1.DataSource = facturas;
            indexGrid = dataGridViewX1.Rows.Count;

            #region Lectura de Poliza
            dataGridViewX1.Rows[indexGridPosition].Selected = true;
            dataGridViewX1.CurrentCell = dataGridViewX1.Rows[indexGridPosition].Cells[0];


            Proveedor = dataGridViewX1.Rows[indexGridPosition].Cells[17].Value.ToString();
            Proveedor_Completo = dataGridViewX1.Rows[indexGridPosition].Cells[17].Value.ToString();
            RFC_proveedor = dataGridViewX1.Rows[indexGridPosition].Cells[19].Value.ToString();
            IdF = dataGridViewX1.Rows[indexGridPosition].Cells[0].Value.ToString();
            UUID = dataGridViewX1.Rows[indexGridPosition].Cells[26].Value.ToString();
            Folio = dataGridViewX1.Rows[indexGridPosition].Cells[2].Value.ToString();
            txtNumero.Text = dataGridViewX1.Rows[indexGridPosition].Cells[0].Value.ToString();

          

            //Buscamos si ya existe titulo para proovedor y de no existir se hace un generico
            Cuenta_cargo_1 = "0000-000-000";
            Cuenta_cargo_2 = "0000-000-000";
            Cuenta_cargo_3 = "0000-000-000";
            Cuenta_cargo_Iva = "0000-000-000";
            Cuenta_Abono_1 = "0000-000-000";
            Cuenta_Abono_2 = "0000-000-000";
            Cuenta_Abono_3 = "0000-000-000";
            Titulo_principal = "Proveedor X";
            Titulo_secundario = "RFCXXX";
            Titulo_tercero = "blabla";
            Departamento = "0";
            Cuenta_isr_retenido = "0000-000-000";
            Cuenta_iva_retenido = "0000-000-000";

            var proveedor = db.Proveedores.Where(p => p.RFC == RFC_proveedor &&
                                p.IdEmpresa == IdEmpresaEjercicio ).FirstOrDefault();//&& Departamento == txtDepto.Text
            //rev parte uno

            if (Folio.Length > 5)
            {
                Folio = Folio.Substring(0, 5);
            }

            if (proveedor == null)
            {
                ////tomamos la primera creacion de proveedores

                Titulo_principal = Proveedor + " " + RFC_proveedor; //proveedor a 40 caracteres + RFc

                Titulo_secundario = Proveedor;

                if (Proveedor.Length > 40)
                {
                    Titulo_principal = Proveedor.Substring(0, 40) + " " + RFC_proveedor; //proveedor a 40 caracteres + RFc
                }

                if (Proveedor.Length > 25)
                {
                    Titulo_secundario = Proveedor.Substring(0, 25); //proveedor a 25 caracteres + RFc
                }

                if (Proveedor.Length > 20)
                {
                    Titulo_tercero = "IVA-" + Proveedor.Substring(0, 20) + "-" + Folio; //proveedor a 25 caracteres + RFc
                }

            }
            else
            {

                //// Titulo_principal = proveedor.Titulo_principal + " " + proveedor.RFC;

                Cuenta_cargo_1 = proveedor.Cuenta_cargo_1;
                Cuenta_cargo_2 = proveedor.Cuenta_cargo_2;
                Cuenta_cargo_3 = proveedor.Cuenta_cargo_3;
                Cuenta_cargo_Iva = proveedor.Cuenta_Cargo_Iva;
                Cuenta_Abono_1 = proveedor.Cuenta_Abono_1;
                Cuenta_Abono_2 = proveedor.Cuenta_Abono_2;
                Cuenta_Abono_3 = proveedor.Cuenta_Abono_3;

                Cuenta_isr_retenido = proveedor.Isr_Retenido;//cuenta isr retenido
                Cuenta_iva_retenido = proveedor.Iva_Retenido;//cuenta iva retenido

                Titulo_principal = proveedor.Titulo_principal;//el concepto del encabezado
                Titulo_secundario = proveedor.Titulo_secundario;//el concepto del total
                Titulo_tercero = proveedor.Titulo_tercero; //el concepto del iva

                Departamento = txtDepto.Text;



                if (Cuenta_cargo_1.Length <= 1)
                {
                    Cuenta_cargo_1 = "0000-000-000";
                  
                }
                if (Cuenta_cargo_2.Length <= 1)
                {
                   
                    Cuenta_cargo_2 = "0000-000-000";
                   
                }
                if (Cuenta_cargo_3.Length <= 1)
                {
                   
                    Cuenta_cargo_3 = "0000-000-000";
                 
                }
                if (Cuenta_cargo_Iva.Length <= 1)
                {
                  
                    Cuenta_cargo_Iva = "0000-000-000";
                   
                }
                if (Cuenta_Abono_1.Length <= 1)
                {
                  
                    Cuenta_Abono_1 = "0000-000-000";
                   
                }
                if (Cuenta_Abono_2.Length <= 1)
                {
                    
                    Cuenta_Abono_2 = "0000-000-000";
                  
                }
                if (Cuenta_Abono_3.Length <= 1)
                {
                   
                    Cuenta_Abono_3 = "0000-000-000";
                   
                }
                if (Cuenta_isr_retenido.Length <= 1)
                {
                    
                    Cuenta_isr_retenido = "0000-000-000";
                   
                }
                if (Cuenta_iva_retenido.Length <= 1)
                {
                    Cuenta_iva_retenido = "0000-000-000";
                }


            }

            //Titulo en cabecera
            txtConcepto.Text = Titulo_principal;
            //Fecha de la factura
            txtFecha.Text = DateTime.Parse(dataGridViewX1.Rows[indexGridPosition].Cells[35].Value.ToString()).ToString("dd/MM/yyyy");
            //Departamento

             Departamento =txtDepto.Text ;


            //rev parte dos
          




            DataTable totalEiva = new DataTable();

            using (SqlConnection conn = new SqlConnection(cnx))
            {
                SqlCommand cmdD = new SqlCommand("SELECT Total, Importe as Iva FROM [" + ejercicio + "] " +
                "  where IdFactura='" + IdF + "'", conn);


                using (SqlDataAdapter a = new SqlDataAdapter(cmdD))
                {
                    a.Fill(totalEiva);

                    total = totalEiva.Rows[0][0].ToString();
                    iva = totalEiva.Rows[0][1].ToString();

                }

            }




            DataTable conceptos = new DataTable();

            using (SqlConnection conn = new SqlConnection(cnx))
            {
                SqlCommand cmdD = new SqlCommand("SELECT Descripcion, ImporteX as Subtotal  FROM [" + ejercicio + "Conceptos] " +
                "  where IdFactura='" + IdF + "'", conn);


                using (SqlDataAdapter a = new SqlDataAdapter(cmdD))
                {
                    a.Fill(conceptos);
                    //para tomar el primer concepto
                    primer_conccepto = conceptos.Rows[0][0].ToString();



                }

            }





            //Agregando los conceptos al grid
            string descripcion;
            string subtotal;

            XmlDocument VarDocumentoXML = new XmlDocument();

            file = @"" + path + "/" + ejercicio + "/" + UUID + ".xml";
            VarDocumentoXML.Load(file);
            XmlNodeList xTax = VarDocumentoXML.GetElementsByTagName("cfdi:Traslado");
            XmlNamespaceManager VarManager = new XmlNamespaceManager(VarDocumentoXML.NameTable);
            VarManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
            VarManager.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            VarManager.AddNamespace("implocal", "http://www.sat.gob.mx/implocal");
            VarManager.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");



            //Titulo_secundario = Proveedor;

            //if (Proveedor.Length > 24)
            //{
            //    Titulo_secundario = Proveedor.Substring(0, 25); //proveedor
            //}



            //El total de la poliza
            poliza.Rows.Insert(0, Cuenta_cargo_1, Titulo_secundario, "0.00", total, "TOTAL");


           // Titulo_tercero = "IVA-" + Proveedor + "-" + Folio;
            //if (Proveedor.Length > 20)
            //{
            //    Titulo_tercero = "IVA-" + Proveedor.Substring(0, 20) + "-" + Folio; //proveedor a 25 caracteres + RFc
            //}



            if (xTax.Count == 0)//Infonavit
            {
                iva = "0.00";
                poliza.Rows.Insert(1, Cuenta_cargo_Iva, Titulo_tercero, iva, "0.00", "IVA TRASLADADO");
            }
            else
            {


                TotalImpuestosTrasladados = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Impuestos/@TotalImpuestosTrasladados", VarManager).InnerText;
                iva = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Impuestos/@TotalImpuestosTrasladados", VarManager).InnerText;

            }

            decimal ISR = 0;//1
            decimal IVA = 0;//2
            decimal IEPS = 0;//3
            decimal SubtotalSumado = 0;//
            decimal TotalFactura = 0;
            string TrasladosXML = "";
            decimal sumaSubtotalSumadoConIvaIEPS;
            decimal diferenciaIEPS;
            //Para los RFC con renta
            string iva_trasladado;
            string isr_retenido;
            string iva_retenido;

            //Los Conceptos de la poliza
            if (xTax.Count == 0)//Infonavit
            {
                foreach (DataRow item in conceptos.Rows)
                {
                    descripcion = item[0].ToString();
                    subtotal = item[1].ToString();




                    if (descripcion.Length > 25)
                    {
                        descripcion = descripcion.Substring(0, 25);
                    }

                    poliza.Rows.Insert(2, Cuenta_cargo_3, descripcion, subtotal, "0.00", "CONCEPTO");
                }
            }
            else
            {



                //Total de la Factura
                TotalFactura = decimal.Parse(total);
               
                XmlNodeList VarConceptos =
                    VarDocumentoXML.SelectNodes("/cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto", VarManager);


                XmlDocument xml = new XmlDocument();
                XmlDocument xmlImpuestos = new XmlDocument();


                bool result = RFC_proveedor.Equals("REME5202139N1");
                if (result)
                {
                    foreach (XmlElement node in VarConceptos)
                    {

                        TrasladosXML = string.Empty;
                        TrasladosXML = node.InnerXml;//antes dos firschild

                        xmlImpuestos.LoadXml(TrasladosXML);




                        iva_trasladado = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Importe", VarManager).InnerText;
                        iva_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion[2]/@Importe", VarManager).InnerText;
                        isr_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@Importe", VarManager).InnerText;

                        poliza.Rows.Insert(1, Cuenta_isr_retenido, "ISR-RETENIDO", "0.00", isr_retenido, "ISR RETENIDO");
                        poliza.Rows.Insert(1, Cuenta_iva_retenido, "IVA-RETENIDO", "0.00", iva_retenido, "IVA RETENIDO");
                        poliza.Rows.Insert(1, Cuenta_cargo_Iva, "IVA-TRASLADADO", iva_trasladado, "0.00", "IVA TRASLADADO");

                    }

                }

                bool result2 = RFC_proveedor.Equals("GABL540419HA8");
                if (result2)
                {
                    foreach (XmlElement node in VarConceptos)
                    {

                        TrasladosXML = string.Empty;
                        TrasladosXML = node.InnerXml;//antes dos firschild

                        xmlImpuestos.LoadXml(TrasladosXML);


                        iva_trasladado = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Importe", VarManager).InnerText;
                        iva_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion[2]/@Importe", VarManager).InnerText;
                        isr_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@Importe", VarManager).InnerText;


                        poliza.Rows.Insert(1, Cuenta_isr_retenido, "ISR-RETENIDO", "0.00", isr_retenido, "ISR RETENIDO");
                        poliza.Rows.Insert(1, Cuenta_iva_retenido, "IVA-RETENIDO", "0.00", iva_retenido, "IVA RETENIDO");
                        poliza.Rows.Insert(1, Cuenta_cargo_Iva, "IVA-TRASLADADO", iva_trasladado, "0.00", "IVA TRASLADADO");




                    }

                }


                foreach (XmlElement node in VarConceptos)
                {



                    Importe = node.GetAttribute("Importe");
                    descripcionxml = node.GetAttribute("Descripcion");
                    subtotal = Importe;






                    try
                    {
                        TrasladosXML = string.Empty;
                        TrasladosXML = node.FirstChild.InnerXml;//antes dos firschild

                        xmlImpuestos.LoadXml(TrasladosXML);
                        //XmlNodeList xmlNL = xmlImpuestos.GetElementsByTagName("cfdi:Traslados");
                        //int total_nodos = xmlNL.Count;



                        if (!string.IsNullOrEmpty(TrasladosXML))
                        {



                            //// / cfdi:Traslado[2] / @Importe
                            baseX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[1]/@Base", VarManager).InnerText;
                            importeX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[1]/@Importe", VarManager).InnerText;
                            impuestoX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[1]/@Impuesto", VarManager).InnerText;

                            if (int.Parse(impuestoX) == 2)
                            {
                                subtotal = baseX;
                            }

                            if (int.Parse(impuestoX) == 1)//ISR
                            {

                                if (!string.IsNullOrEmpty(importeX) ||
                                    !string.IsNullOrEmpty(importeX) ||
                                    importeX == "")
                                {

                                    ISR = ISR + decimal.Parse(importeX);
                                }


                            }


                            if (int.Parse(impuestoX) == 2)//IVA
                            {

                                if (!string.IsNullOrEmpty(importeX) ||
                                    !string.IsNullOrEmpty(importeX) ||
                                    importeX == "")
                                {

                                    IVA = IVA + decimal.Parse(importeX);
                                }


                            }


                            if (int.Parse(impuestoX) == 3)//IEPS
                            {

                                if (!string.IsNullOrEmpty(importeX) ||
                                    !string.IsNullOrEmpty(importeX) ||
                                    importeX == "")
                                {

                                    IEPS = IEPS + decimal.Parse(importeX);
                                }


                            }




                            baseX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[2]/@Base", VarManager).InnerText;
                            importeX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[2]/@Importe", VarManager).InnerText;
                            impuestoX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[2]/@Impuesto", VarManager).InnerText;


                            if (int.Parse(impuestoX) == 2)
                            {
                                subtotal = baseX;
                            }


                            if (int.Parse(impuestoX) == 1)//ISR
                            {

                                if (!string.IsNullOrEmpty(importeX) ||
                                    !string.IsNullOrEmpty(importeX) ||
                                    importeX == "")
                                {

                                    ISR = ISR + decimal.Parse(importeX);
                                }


                            }


                            if (int.Parse(impuestoX) == 2)//IVA
                            {

                                if (!string.IsNullOrEmpty(importeX) ||
                                    !string.IsNullOrEmpty(importeX) ||
                                    importeX == "")
                                {

                                    IVA = IVA + decimal.Parse(importeX);
                                }


                            }


                            if (int.Parse(impuestoX) == 3)//IEPS
                            {

                                if (!string.IsNullOrEmpty(importeX) ||
                                    !string.IsNullOrEmpty(importeX) ||
                                    importeX == "")
                                {

                                    IEPS = IEPS + decimal.Parse(importeX);
                                }


                            }

                            #region trash
                            //xml.LoadXml(TrasladosXML);

                            //baseX = xml.DocumentElement.Attributes["Base"].Value;
                            //importeX = xml.DocumentElement.Attributes["Importe"].Value;
                            //impuestoX = xml.DocumentElement.Attributes["Impuesto"].Value;
                            //tasaOCuotaX = xml.DocumentElement.Attributes["TasaOCuota"].Value;
                            //tipoFactorX = xml.DocumentElement.Attributes["TipoFactor"].Value;



                            //if (int.Parse(impuestoX) == 1)//ISR
                            //{

                            //    if (!string.IsNullOrEmpty(importeX) ||
                            //        !string.IsNullOrEmpty(importeX) ||
                            //        importeX == "")
                            //    {

                            //        ISR = ISR + decimal.Parse(importeX);
                            //    }


                            //}


                            //if (int.Parse(impuestoX) == 2)//IVA
                            //{

                            //    if (!string.IsNullOrEmpty(importeX) ||
                            //        !string.IsNullOrEmpty(importeX) ||
                            //        importeX == "")
                            //    {

                            //        IVA = IVA + decimal.Parse(importeX);
                            //    }


                            //}


                            //if (int.Parse(impuestoX) == 3)//IEPS
                            //{

                            //    if (!string.IsNullOrEmpty(importeX) ||
                            //        !string.IsNullOrEmpty(importeX) ||
                            //        importeX == "")
                            //    {

                            //        IEPS = IEPS + decimal.Parse(importeX);
                            //    }


                            //}

                            #endregion



                        }




                    }
                    catch (Exception ex)
                    {

                        Console.Write(ex.Message);

                    }





                    //Suma del Debe (los conceptos)
                    SubtotalSumado += decimal.Parse(subtotal);

                    if (descripcionxml.Length > 25)
                    {
                        descripcionxml = descripcionxml.Substring(0, 25);
                    }

                    poliza.Rows.Insert(1, Cuenta_cargo_3, descripcionxml, subtotal, "0.00", "CONCEPTO");


                }


                if(Proveedor.Length>19)
                {
                    Proveedor = Proveedor.Substring(0, 18);
                }

                string leyenda_IVA = "IVA-" + Proveedor + "-" + Folio; ;//.Substring(0, 20)
                string leyenda_IEPS = "IEPS-" + Proveedor + "-" + Folio;
                string leyenda_ISR = "ISR-" + Proveedor + "-" + Folio;


                sumaSubtotalSumadoConIvaIEPS = SubtotalSumado + IVA + IEPS;


                if (IVA > 0)
                {
                    poliza.Rows.Insert(1, Cuenta_cargo_Iva, leyenda_IVA, IVA, "0.00", "IVA TRASLADADO");
                }

                if (ISR > 0)
                {
                    poliza.Rows.Insert(1, Cuenta_cargo_2, leyenda_ISR, ISR, "0.00", "ISR TRASLADADO");
                }

                if (IEPS > 0)
                {



                    if (sumaSubtotalSumadoConIvaIEPS == TotalFactura)//significa que agrego el IEPS en la Factura
                    {
                        //AGREGO IEPS
                        poliza.Rows.Insert(1, Cuenta_Abono_2, leyenda_IEPS, IEPS, "0.00", "IEPS TRASLADADO");
                    }


                    if (sumaSubtotalSumadoConIvaIEPS > TotalFactura)//significa que sobra el IEPS en la Factura
                    {
                        //NO AGREGO IEPS

                    }

                }


                if (sumaSubtotalSumadoConIvaIEPS < TotalFactura)//significa que el IEPS es necesario 
                {
                    //AGREGO IEPS CALCULADO
                    diferenciaIEPS = TotalFactura - sumaSubtotalSumadoConIvaIEPS;


                    poliza.Rows.Insert(1, Cuenta_Abono_2, leyenda_IEPS, diferenciaIEPS, "0.00", "IEPS TRASLADADO");
                }









            }



            //LLeno las cuentas de poliza
            foreach (DataGridViewRow item in poliza.Rows)
            {

                if (item.Cells[4].Value.ToString() == "TOTAL")
                {
                    item.Cells[0].Value = Cuenta_cargo_1;
                }
                if (item.Cells[4].Value.ToString() == "IVA TRASLADADO")
                {
                    item.Cells[0].Value = Cuenta_cargo_Iva;

                    
                  
                }
                if (item.Cells[4].Value.ToString() == "IVA RETENIDO")
                {
                    item.Cells[0].Value = Cuenta_iva_retenido;


                }
                if (item.Cells[4].Value.ToString() == "ISR RETENIDO")
                {
                    item.Cells[0].Value = Cuenta_isr_retenido;

                }
                if (item.Cells[4].Value.ToString() == "ISR TRASLADADO")
                {
                    item.Cells[0].Value = Cuenta_cargo_2;


                }
                if (item.Cells[4].Value.ToString() == "IEPS RETENIDO")
                {
                    item.Cells[0].Value = Cuenta_Abono_1;


                }
                if (item.Cells[4].Value.ToString() == "IEPS TRASLADADO")
                {
                    item.Cells[0].Value = Cuenta_Abono_2;

                }
                if (item.Cells[4].Value.ToString() == "CONCEPTO")
                {
                    item.Cells[0].Value =Cuenta_cargo_3;

                }



            }




            float Debe = 0;
            float haber = 0;
            foreach (DataGridViewRow row in poliza.Rows)
            {
                float valor = float.Parse(row.Cells[2].Value.ToString());
                Debe += valor;
            }
            foreach (DataGridViewRow row in poliza.Rows)
            {
                float valor = float.Parse(row.Cells[3].Value.ToString());
                haber += valor;
            }
            txtDebe.Text = Debe.ToString("N2");
            txtHaber.Text = haber.ToString("N2");

            //Actualizacion 17 enero 2019
            decimal diferencia;
            if (decimal.Parse(txtDebe.Text) > decimal.Parse(txtHaber.Text))
            {
                diferencia = decimal.Parse(txtDebe.Text) - decimal.Parse(txtHaber.Text);

                poliza.Rows.Insert(1, Cuenta_Abono_2, "OTROS", "0.00",diferencia, "IEPS TRASLADADO");
                RECALCULAR();
            }
            else if (decimal.Parse(txtDebe.Text) < decimal.Parse(txtHaber.Text))
            {
                diferencia = decimal.Parse(txtHaber.Text) - decimal.Parse(txtDebe.Text);

                poliza.Rows.Insert(1, Cuenta_Abono_2, "OTROS", diferencia, "0.00", "IEPS TRASLADADO");
                RECALCULAR();

            }

          
            #endregion

        }
      //RECALCULAR SUMA
      public void RECALCULAR()
      {
            float Debe = 0;
            float haber = 0;
            foreach (DataGridViewRow row in poliza.Rows)
            {
                float valor = float.Parse(row.Cells[2].Value.ToString());
                Debe += valor;
            }
            foreach (DataGridViewRow row in poliza.Rows)
            {
                float valor = float.Parse(row.Cells[3].Value.ToString());
                haber += valor;
            }
            txtDebe.Text = Debe.ToString("N2");
            txtHaber.Text = haber.ToString("N2");

        }
        public void CargarEmpresadatos()
        {
           
            IdLocalidad = int.Parse(cmbLocalidades.SelectedValue.ToString());
            var localidades = db.Localidades.Where(p => p.IdLocalidad == IdLocalidad).FirstOrDefault();
          
            IdEmpresa = Convert.ToInt32(localidades.IdEmpresa);
            txtDepto.Text =localidades.Departamento;

            try
            {
                if (poliza.Rows.Count > 0)
                {
                   
                    var proveedor = db.Proveedores.Where(p => p.RFC == RFC_proveedor &&
                                           p.IdEmpresa == IdEmpresa && p.IdLocalidad == IdLocalidad && p.Departamento == localidades.Departamento).FirstOrDefault();

                    foreach (DataGridViewRow item in poliza.Rows)
                    {

                        if (item.Cells[4].Value.ToString() == "TOTAL")
                        {
                            item.Cells[0].Value = proveedor.Cuenta_cargo_1;
                        }
                        if (item.Cells[4].Value.ToString() == "IVA TRASLADADO")
                        {
                            item.Cells[0].Value= proveedor.Cuenta_Cargo_Iva;
                           

                        }
                        if (item.Cells[4].Value.ToString() == "IVA RETENIDO")
                        {
                            item.Cells[0].Value = proveedor.Iva_Retenido;
                           

                        }
                        if (item.Cells[4].Value.ToString() == "ISR RETENIDO")
                        {
                          item.Cells[0].Value = proveedor.Isr_Retenido;
                          
                        }
                        if (item.Cells[4].Value.ToString() == "ISR TRASLADADO")
                        {
                            item.Cells[0].Value = proveedor.Cuenta_cargo_2;
                          
                          


                        }
                        if (item.Cells[4].Value.ToString() == "IEPS RETENIDO")
                        {
                            item.Cells[0].Value = Cuenta_Abono_1;
                          

                        }
                        if (item.Cells[4].Value.ToString() == "IEPS TRASLADADO")
                        {
                            item.Cells[0].Value = proveedor.Cuenta_Abono_2;
                           
                        }
                        if (item.Cells[4].Value.ToString() == "CONCEPTO")
                        {
                            item.Cells[0].Value = proveedor.Cuenta_cargo_3;

                        }



                    }
                  

                  
                }


            }
            catch (Exception ex)
            {

            }
         
        }

        #endregion

        #region Events (Eventos)

        //Event Fill First Poliza
        private void PlantillaPrepolizaForm_Load(object sender, EventArgs e)
        {
            LoadF();
        }
        //Pasar a la siguiente factura
        private void buttonX2_Click(object sender, EventArgs e)
        {
            MessageBoxEx.EnableGlass = false;
            if (string.IsNullOrEmpty(txtDepto.Text) || string.IsNullOrWhiteSpace(txtDepto.Text))
            {

                MessageBoxEx.Show("NO has ingresado un departamento!!!",
                                                       "EKPolizaGastos",
                                                       MessageBoxButtons.OK,
                                                       MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult pregunta = MessageBoxEx.Show("Generar Pre-Poliza?",
                                                       "EKPolizaGastos",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {



                //Crear carpeta con nombre dia CIS-NOV-2018_10dic2018
                string fecha_carpeta;
                string carpeta_ejercicio;
                string directorio_a_localizar;
                string numeroPolizaConvertido = "";
                int consecutivo;
                fecha_carpeta = Convert.ToDateTime(txtFecha.Text).ToString("ddMMMyyyy");
                carpeta_ejercicio = ejercicio + "_" + fecha_carpeta;

                directorio_a_localizar = path + "/" + ejercicio + "/Polizas";//+ carpeta_ejercicio;


                if (!Directory.Exists(directorio_a_localizar))
                {
                    Directory.CreateDirectory(directorio_a_localizar);
                }
                //path   y:cis/xxx
                //ejercicio  cis-nov-2018
                //obtengo el numero
                consecutivo = int.Parse(txtNumero.Text);
                if (consecutivo < 10)
                {
                    numeroPolizaConvertido = "00" + consecutivo;
                }

                if (consecutivo >= 10)
                {
                    numeroPolizaConvertido = "0" + consecutivo;
                }

                if (consecutivo >= 100)
                {
                    numeroPolizaConvertido = txtNumero.Text;
                }


                string nuevo = numeroPolizaConvertido + "_" +
                       Convert.ToDateTime(txtFecha.Text).ToString("yy") + "_" + RFC_proveedor;


                if (File.Exists(directorio_a_localizar + "/" + nuevo + ".xml"))
                {

                    File.Delete(directorio_a_localizar + "/" + nuevo + ".xml");//Si existe lo elimina y vulve a crear
                }

                //mover xml a su carpeta creada
                if (File.Exists(file))
                {

                    File.Copy(file, directorio_a_localizar + "/" + nuevo + ".xml");
                }

                //Creo el Bloc de Notas primero para poder editar
                string cuentaWrite;
                string tituloWrite;
                string importeWrite;

                if (File.Exists(directorio_a_localizar + "/" + nuevo + ".pol"))
                {

                    File.Delete(directorio_a_localizar + "/" + nuevo + ".pol");//Si existe lo elimina y vulve a crear
                }

                using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(directorio_a_localizar + "/" + nuevo + ".pol"))
                {
                    //Tipo
                    escritor.WriteLine(txtTipo.Text);
                    //Fecha
                    escritor.WriteLine(Convert.ToDateTime(txtFecha.Text).ToString("dd"));
                    //concepto
                    escritor.WriteLine(txtConcepto.Text);
                    //concepto segunda linea
                    escritor.WriteLine(primer_conccepto);
                    primer_conccepto = string.Empty;






                    //Ahora Creamos la Poliza
                    foreach (DataGridViewRow item in poliza.Rows)
                    {

                        if (item.Cells[4].Value.ToString() == "TOTAL")
                        {

                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                            tituloWrite = item.Cells[1].Value.ToString();
                            importeWrite = item.Cells[3].Value.ToString() + ",1.00";//haber

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine("");
                            escritor.WriteLine(importeWrite);
                            Titulo_principal = txtConcepto.Text;
                            Cuenta_cargo_1 = item.Cells[0].Value.ToString();
                        }
                        if (item.Cells[4].Value.ToString() == "IVA TRASLADADO")
                        {
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                            tituloWrite = item.Cells[1].Value.ToString();
                            importeWrite = item.Cells[2].Value.ToString() + ",1.00";

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine(importeWrite);
                            Cuenta_cargo_Iva = item.Cells[0].Value.ToString();
                        }
                        if (item.Cells[4].Value.ToString() == "IVA RETENIDO")
                        {
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                            tituloWrite = item.Cells[1].Value.ToString();
                            importeWrite = item.Cells[3].Value.ToString() + ",1.00";

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine("");
                            escritor.WriteLine(importeWrite);
                            iva_Retenido = item.Cells[0].Value.ToString();
                            Cuenta_iva_retenido = item.Cells[0].Value.ToString();
                        }
                        if (item.Cells[4].Value.ToString() == "ISR RETENIDO")
                        {
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                            tituloWrite = item.Cells[1].Value.ToString();
                            importeWrite = item.Cells[3].Value.ToString() + ",1.00";

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine("");
                            escritor.WriteLine(importeWrite);
                            Cuenta_isr_retenido = item.Cells[0].Value.ToString();
                        }
                        if (item.Cells[4].Value.ToString() == "ISR TRASLADADO")
                        {
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                            tituloWrite = item.Cells[1].Value.ToString();
                            importeWrite = item.Cells[3].Value.ToString() + ",1.00";

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine(importeWrite);
                            Cuenta_cargo_2 = item.Cells[0].Value.ToString();
                        }
                        if (item.Cells[4].Value.ToString() == "IEPS RETENIDO")
                        {
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                            tituloWrite = item.Cells[1].Value.ToString();
                            importeWrite = item.Cells[2].Value.ToString() + ",1.00";

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine("");
                            escritor.WriteLine(importeWrite);
                            Cuenta_Abono_1 = item.Cells[0].Value.ToString();
                        }
                        if (item.Cells[4].Value.ToString() == "IEPS TRASLADADO")
                        {
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                            tituloWrite = item.Cells[1].Value.ToString();
                            importeWrite = item.Cells[2].Value.ToString() + ",1.00";

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine(importeWrite);
                            Cuenta_Abono_2 = item.Cells[0].Value.ToString();
                        }
                        if (item.Cells[4].Value.ToString() == "CONCEPTO")
                        {
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                            tituloWrite = item.Cells[1].Value.ToString();
                            importeWrite = item.Cells[2].Value.ToString() + ",1.00";

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine(importeWrite);
                            Cuenta_cargo_3 = item.Cells[0].Value.ToString();
                        }



                    }
                    escritor.WriteLine("");
                    escritor.WriteLine("FIN");


                }

                #region Save Provedor

                ////Ahora guardo los datos del proveedor
                ///
                //1 comprubeo si existe empresa con este departamento
                var ExisteProovedor = db.Proveedores.Where(p => p.RFC == RFC_proveedor
                && p.IdEmpresa == IdEmpresa).FirstOrDefault();
                string numeroProvedorConvertido = "0";
                if (ExisteProovedor != null)
                {

                    numeroProvedorConvertido = Convert.ToString(ExisteProovedor.IdProveedor);




                    if (int.Parse(numeroProvedorConvertido) < 10)
                    {
                        numeroProvedorConvertido = "00" + numeroProvedorConvertido;

                    }
                    else if (int.Parse(numeroProvedorConvertido) >= 10 && int.Parse(numeroProvedorConvertido) <= 99)
                    {

                        numeroProvedorConvertido = "0" + numeroProvedorConvertido;
                    }

                }

                //2 si no existe lo agrego de lo contrario actualizo
                //Agrego Proveedor
                Proveedores proveedor = new Proveedores
                {
                    Proveedor = Proveedor_Completo,
                    RFC = RFC_proveedor,
                    NoProveedor = numeroProvedorConvertido,
                    IdEmpresa = IdEmpresa,
                    IdLocalidad = IdLocalidad,
                    Cuenta_cargo_1 = Cuenta_cargo_1,
                    Cuenta_cargo_2 = Cuenta_cargo_2,
                    Cuenta_cargo_3 = Cuenta_cargo_3,
                    Cuenta_Cargo_Iva = Cuenta_cargo_Iva,
                    Cuenta_Abono_1 = Cuenta_Abono_1,
                    Cuenta_Abono_2 = Cuenta_Abono_2,
                    Cuenta_Abono_3 = Cuenta_Abono_3,
                    Titulo_principal = Titulo_principal,
                    Titulo_secundario = Titulo_secundario,
                    Titulo_tercero = Titulo_tercero,
                    Departamento = txtDepto.Text,
                    Isr_Retenido = Cuenta_isr_retenido,
                    Iva_Retenido = Cuenta_iva_retenido,

                };
                if (ExisteProovedor == null)
                {


                    // Agregamos el objeto
                    db.Proveedores.Add(proveedor);

                    //Salvamos cambios en la base de datos

                    db.SaveChanges();

                }
               




                #endregion

                #region Update Ejercicio
                
                using (SqlConnection conn = new SqlConnection(cnx))
                {
                    conn.Open();
                    SqlCommand cmdD = new SqlCommand("UPDATE [" + ejercicio + "]  SET IdEstatus='1'" +
                    "  where IdFactura='" + IdF + "'", conn);
                    cmdD.ExecuteNonQuery();
                    conn.Close();
                }
                #endregion

            }

            //Continuar Finish


            if (indexGridPosition + 1 <= totalFacturas)
            {
                indexGridPosition++;

                poliza.Rows.Clear();

                #region Lectura de Poliza
                dataGridViewX1.Rows[indexGridPosition].Selected = true;
                dataGridViewX1.CurrentCell = dataGridViewX1.Rows[indexGridPosition].Cells[0];


                Proveedor = dataGridViewX1.Rows[indexGridPosition].Cells[17].Value.ToString();
                Proveedor_Completo = dataGridViewX1.Rows[indexGridPosition].Cells[17].Value.ToString();
                RFC_proveedor = dataGridViewX1.Rows[indexGridPosition].Cells[19].Value.ToString();
                IdF = dataGridViewX1.Rows[indexGridPosition].Cells[0].Value.ToString();
                UUID = dataGridViewX1.Rows[indexGridPosition].Cells[26].Value.ToString();
                Folio = dataGridViewX1.Rows[indexGridPosition].Cells[2].Value.ToString();
                txtNumero.Text = dataGridViewX1.Rows[indexGridPosition].Cells[0].Value.ToString();


                //Buscamos si ya existe titulo para proovedor y de no existir se hace un generico
                Cuenta_cargo_1 = "0000-000-000";
                Cuenta_cargo_2 = "0000-000-000";
                Cuenta_cargo_3 = "0000-000-000";
                Cuenta_cargo_Iva = "0000-000-000";
                Cuenta_Abono_1 = "0000-000-000";
                Cuenta_Abono_2 = "0000-000-000";
                Cuenta_Abono_3 = "0000-000-000";
                Titulo_principal = "Proveedor X";
                Titulo_secundario = "RFCXXX";
                Titulo_tercero = "blabla";
                Departamento = "0";
                Cuenta_isr_retenido = "0000-000-000";
                Cuenta_iva_retenido = "0000-000-000";
                Departamento = txtDepto.Text.Trim();

                var proveedor = db.Proveedores.Where(p => p.RFC == RFC_proveedor &&
                                    p.IdEmpresa == IdEmpresa).FirstOrDefault();//&& p.IdLocalidad == IdLocalidad && p.Departamento == Departamento

                if (Folio.Length > 5)
                {
                    Folio = Folio.Substring(0, 5);
                }

                if (proveedor == null)
                {
                    //tomamos la primera creacion de proveedores

                    Titulo_principal = Proveedor + " " + RFC_proveedor; //proveedor a 40 caracteres + RFc

                    Titulo_secundario = Proveedor;

                    if (Proveedor.Length > 40)
                    {
                        Titulo_principal = Proveedor.Substring(0, 40) + " " + RFC_proveedor; //proveedor a 40 caracteres + RFc
                    }

                    if (Proveedor.Length > 25)
                    {
                        Titulo_secundario = Proveedor.Substring(0, 25); //proveedor a 25 caracteres + RFc
                    }

                    if (Proveedor.Length > 20)
                    {
                        Titulo_tercero = "IVA-" + Proveedor.Substring(0, 20) + "-" + Folio; //proveedor a 25 caracteres + RFc
                    }

                }
                else
                {

                    //Titulo_principal = proveedor.Titulo_principal + " " + proveedor.RFC;

                    Cuenta_cargo_1 = proveedor.Cuenta_cargo_1;
                    Cuenta_cargo_2 = proveedor.Cuenta_cargo_2;
                    Cuenta_cargo_3 = proveedor.Cuenta_cargo_3;
                    Cuenta_cargo_Iva = proveedor.Cuenta_Cargo_Iva;
                    Cuenta_Abono_1 = proveedor.Cuenta_Abono_1;
                    Cuenta_Abono_2 = proveedor.Cuenta_Abono_2;
                    Cuenta_Abono_3 = proveedor.Cuenta_Abono_3;

                    Cuenta_isr_retenido = proveedor.Isr_Retenido;//cuenta isr retenido
                    Cuenta_iva_retenido = proveedor.Iva_Retenido;//cuenta iva retenido

                    Titulo_principal = proveedor.Titulo_principal;//el concepto del encabezado
                    Titulo_secundario = proveedor.Titulo_secundario;//el concepto del total
                    Titulo_tercero = proveedor.Titulo_tercero; //el concepto del iva

                    Departamento = txtDepto.Text;



                    if (Cuenta_cargo_1.Length <= 1)
                    {
                        Cuenta_cargo_1 = "0000-000-000";

                    }
                    if (Cuenta_cargo_2.Length <= 1)
                    {

                        Cuenta_cargo_2 = "0000-000-000";

                    }
                    if (Cuenta_cargo_3.Length <= 1)
                    {

                        Cuenta_cargo_3 = "0000-000-000";

                    }
                    if (Cuenta_cargo_Iva.Length <= 1)
                    {

                        Cuenta_cargo_Iva = "0000-000-000";

                    }
                    if (Cuenta_Abono_1.Length <= 1)
                    {

                        Cuenta_Abono_1 = "0000-000-000";

                    }
                    if (Cuenta_Abono_2.Length <= 1)
                    {

                        Cuenta_Abono_2 = "0000-000-000";

                    }
                    if (Cuenta_Abono_3.Length <= 1)
                    {

                        Cuenta_Abono_3 = "0000-000-000";

                    }
                    if (Cuenta_isr_retenido == "" || string.IsNullOrEmpty(Cuenta_isr_retenido))
                    {

                        Cuenta_isr_retenido = "0000-000-000";

                    }
                    if (Cuenta_iva_retenido == "" || string.IsNullOrEmpty(Cuenta_iva_retenido))
                    {
                        Cuenta_iva_retenido = "0000-000-000";
                    }


                }

                //Titulo en cabecera
                txtConcepto.Text = Titulo_principal;
                //Fecha de la factura
                txtFecha.Text = DateTime.Parse(dataGridViewX1.Rows[indexGridPosition].Cells[35].Value.ToString()).ToString("dd/MM/yyyy");
                //Departamento
                Departamento = txtDepto.Text;



                DataTable totalEiva = new DataTable();

                using (SqlConnection conn = new SqlConnection(cnx))
                {
                    SqlCommand cmdD = new SqlCommand("SELECT Total, Importe as Iva FROM [" + ejercicio + "] " +
                    "  where IdFactura='" + IdF + "'", conn);


                    using (SqlDataAdapter a = new SqlDataAdapter(cmdD))
                    {
                        a.Fill(totalEiva);

                        total = totalEiva.Rows[0][0].ToString();
                        iva = totalEiva.Rows[0][1].ToString();

                    }

                }

                DataTable conceptos = new DataTable();

                using (SqlConnection conn = new SqlConnection(cnx))
                {
                    SqlCommand cmdD = new SqlCommand("SELECT Descripcion, ImporteX as Subtotal  FROM [" + ejercicio + "Conceptos] " +
                    "  where IdFactura='" + IdF + "'", conn);


                    using (SqlDataAdapter a = new SqlDataAdapter(cmdD))
                    {
                        a.Fill(conceptos);
                        //para tomar el primer concepto
                        primer_conccepto = conceptos.Rows[0][0].ToString();



                    }

                }






                //Agregando los conceptos al grid
                string descripcion;
                string subtotal;

                XmlDocument VarDocumentoXML = new XmlDocument();

                file = @"" + path + "/" + ejercicio + "/" + UUID + ".xml";
                VarDocumentoXML.Load(file);
                XmlNodeList xTax = VarDocumentoXML.GetElementsByTagName("cfdi:Traslado");
                XmlNamespaceManager VarManager = new XmlNamespaceManager(VarDocumentoXML.NameTable);
                VarManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                VarManager.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
                VarManager.AddNamespace("implocal", "http://www.sat.gob.mx/implocal");
                VarManager.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");

                //El total de la poliza
                poliza.Rows.Insert(0, Cuenta_cargo_1, Titulo_secundario, "0.00", total, "TOTAL");

                if (xTax.Count == 0)//Infonavit
                {
                    iva = "0.00";
                    poliza.Rows.Insert(1, Cuenta_cargo_Iva, Titulo_tercero, iva, "0.00", "IVA TRASLADADO");
                }
                else
                {

                    try
                    {
                        TotalImpuestosTrasladados = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Impuestos/@TotalImpuestosTrasladados", VarManager).InnerText;
                        iva = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Impuestos/@TotalImpuestosTrasladados", VarManager).InnerText;
                    }
                    catch(Exception ex)
                    {

                    }
                }

                decimal ISR = 0;//1
                decimal IVA = 0;//2
                decimal IEPS = 0;//3
                decimal SubtotalSumado = 0;//
                decimal TotalFactura = 0;
                string TrasladosXML = "";
                decimal sumaSubtotalSumadoConIvaIEPS;
                decimal diferenciaIEPS;
                //Para los RFC con renta
                string iva_trasladado;
                string isr_retenido;
                string iva_retenido;


                //

                //Los Conceptos de la poliza
                if (xTax.Count == 0)//Infonavit
                {
                    foreach (DataRow item in conceptos.Rows)
                    {
                        descripcion = item[0].ToString();
                        subtotal = item[1].ToString();




                        if (descripcion.Length > 25)
                        {
                            descripcion = descripcion.Substring(0, 25);
                        }

                        poliza.Rows.Insert(2, Cuenta_cargo_3, descripcion, subtotal, "0.00", "CONCEPTO");
                    }
                }
                else
                {



                    //Total de la Factura
                    TotalFactura = decimal.Parse(total);
                    //VarDocumentoXML.GetElementsByTagName("cfdi:Concepto");
                    XmlNodeList VarConceptos =
                        VarDocumentoXML.SelectNodes("/cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto", VarManager);


                    XmlDocument xml = new XmlDocument();
                    XmlDocument xmlImpuestos = new XmlDocument();


                    bool result = RFC_proveedor.Equals("REME5202139N1");
                    if (result)
                    {
                        foreach (XmlElement node in VarConceptos)
                        {

                            TrasladosXML = string.Empty;
                            TrasladosXML = node.InnerXml;//antes dos firschild

                            xmlImpuestos.LoadXml(TrasladosXML);




                            iva_trasladado = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Importe", VarManager).InnerText;
                            iva_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion[2]/@Importe", VarManager).InnerText;
                            isr_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@Importe", VarManager).InnerText;

                            poliza.Rows.Insert(1, Cuenta_isr_retenido, "ISR-RETENIDO", "0.00", isr_retenido, "ISR RETENIDO");
                            poliza.Rows.Insert(1, Cuenta_iva_retenido, "IVA-RETENIDO", "0.00", iva_retenido, "IVA RETENIDO");
                            poliza.Rows.Insert(1, Cuenta_cargo_Iva, "IVA-TRASLADADO", iva_trasladado, "0.00", "IVA TRASLADADO");

                        }

                    }

                    bool result2 = RFC_proveedor.Equals("GABL540419HA8");
                    if (result2)
                    {
                        foreach (XmlElement node in VarConceptos)
                        {

                            TrasladosXML = string.Empty;
                            TrasladosXML = node.InnerXml;//antes dos firschild

                            xmlImpuestos.LoadXml(TrasladosXML);


                            iva_trasladado = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Importe", VarManager).InnerText;
                            iva_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion[2]/@Importe", VarManager).InnerText;
                            isr_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@Importe", VarManager).InnerText;


                            poliza.Rows.Insert(1, Cuenta_isr_retenido, "ISR-RETENIDO", "0.00", isr_retenido, "ISR RETENIDO");
                            poliza.Rows.Insert(1, Cuenta_iva_retenido, "IVA-RETENIDO", "0.00", iva_retenido, "IVA RETENIDO");
                            poliza.Rows.Insert(1, Cuenta_cargo_Iva, "IVA-TRASLADADO", iva_trasladado, "0.00", "IVA TRASLADADO");




                        }

                    }


                    foreach (XmlElement node in VarConceptos)
                    {



                        Importe = node.GetAttribute("Importe");
                        descripcionxml = node.GetAttribute("Descripcion");
                        subtotal = Importe;






                        try
                        {
                            TrasladosXML = string.Empty;
                            TrasladosXML = node.FirstChild.InnerXml;//antes dos firschild

                            xmlImpuestos.LoadXml(TrasladosXML);
                           
                            if (!string.IsNullOrEmpty(TrasladosXML))
                            {



                                
                                baseX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[1]/@Base", VarManager).InnerText;
                                importeX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[1]/@Importe", VarManager).InnerText;
                                impuestoX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[1]/@Impuesto", VarManager).InnerText;

                                if (int.Parse(impuestoX) == 2)
                                {
                                    subtotal = baseX;
                                }

                                if (int.Parse(impuestoX) == 1)//ISR
                                {

                                    if (!string.IsNullOrEmpty(importeX) ||
                                        !string.IsNullOrEmpty(importeX) ||
                                        importeX == "")
                                    {

                                        ISR = ISR + decimal.Parse(importeX);
                                    }


                                }


                                if (int.Parse(impuestoX) == 2)//IVA
                                {

                                    if (!string.IsNullOrEmpty(importeX) ||
                                        !string.IsNullOrEmpty(importeX) ||
                                        importeX == "")
                                    {

                                        IVA = IVA + decimal.Parse(importeX);
                                    }


                                }


                                if (int.Parse(impuestoX) == 3)//IEPS
                                {

                                    if (!string.IsNullOrEmpty(importeX) ||
                                        !string.IsNullOrEmpty(importeX) ||
                                        importeX == "")
                                    {

                                        IEPS = IEPS + decimal.Parse(importeX);
                                    }


                                }




                                baseX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[2]/@Base", VarManager).InnerText;
                                importeX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[2]/@Importe", VarManager).InnerText;
                                impuestoX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[2]/@Impuesto", VarManager).InnerText;


                                if (int.Parse(impuestoX) == 2)
                                {
                                    subtotal = baseX;
                                }


                                if (int.Parse(impuestoX) == 1)//ISR
                                {

                                    if (!string.IsNullOrEmpty(importeX) ||
                                        !string.IsNullOrEmpty(importeX) ||
                                        importeX == "")
                                    {

                                        ISR = ISR + decimal.Parse(importeX);
                                    }


                                }


                                if (int.Parse(impuestoX) == 2)//IVA
                                {

                                    if (!string.IsNullOrEmpty(importeX) ||
                                        !string.IsNullOrEmpty(importeX) ||
                                        importeX == "")
                                    {

                                        IVA = IVA + decimal.Parse(importeX);
                                    }


                                }


                                if (int.Parse(impuestoX) == 3)//IEPS
                                {

                                    if (!string.IsNullOrEmpty(importeX) ||
                                        !string.IsNullOrEmpty(importeX) ||
                                        importeX == "")
                                    {

                                        IEPS = IEPS + decimal.Parse(importeX);
                                    }


                                }

                             
                            }




                        }
                        catch (Exception ex)
                        {

                            Console.Write(ex.Message);

                        }





                        //Suma del Debe (los conceptos)
                        SubtotalSumado += decimal.Parse(subtotal);

                        if (descripcionxml.Length > 25)
                        {
                            descripcionxml = descripcionxml.Substring(0, 25);
                        }

                        poliza.Rows.Insert(1, Cuenta_cargo_3, descripcionxml, subtotal, "0.00", "CONCEPTO");


                    }


                    string leyenda_IVA = "IVA-" + Proveedor + "-" + Folio; ;//.Substring(0, 20)
                    string leyenda_IEPS = "IEPS-" + Proveedor + "-" + Folio;
                    string leyenda_ISR = "ISR-" + Proveedor + "-" + Folio;


                    sumaSubtotalSumadoConIvaIEPS = SubtotalSumado + IVA + IEPS;


                    if (IVA > 0)
                    {
                        poliza.Rows.Insert(1, Cuenta_cargo_Iva, leyenda_IVA, IVA, "0.00", "IVA TRASLADADO");
                    }

                    if (ISR > 0)
                    {
                        poliza.Rows.Insert(1, Cuenta_cargo_Iva, leyenda_ISR, ISR, "0.00", "ISR TRASLADADO");
                    }

                    if (IEPS > 0)
                    {



                        if (sumaSubtotalSumadoConIvaIEPS == TotalFactura)//significa que agrego el IEPS en la Factura
                        {
                            //AGREGO IEPS
                            poliza.Rows.Insert(1, Cuenta_Abono_2, leyenda_IEPS, IEPS, "0.00", "IEPS TRASLADADO");
                        }


                        if (sumaSubtotalSumadoConIvaIEPS > TotalFactura)//significa que sobra el IEPS en la Factura
                        {
                            //NO AGREGO IEPS

                        }

                    }


                    if (sumaSubtotalSumadoConIvaIEPS < TotalFactura)//significa que el IEPS es necesario 
                    {
                        //AGREGO IEPS CALCULADO
                        diferenciaIEPS = TotalFactura - sumaSubtotalSumadoConIvaIEPS;


                        poliza.Rows.Insert(1, Cuenta_Abono_2, leyenda_IEPS, diferenciaIEPS, "0.00", "IEPS TRASLADADO");
                    }









                }





                //LLeno las cuentas de poliza
                foreach (DataGridViewRow item in poliza.Rows)
                {

                    if (item.Cells[4].Value.ToString() == "TOTAL")
                    {
                        item.Cells[0].Value = Cuenta_cargo_1;
                    }
                    if (item.Cells[4].Value.ToString() == "IVA TRASLADADO")
                    {
                        item.Cells[0].Value = Cuenta_cargo_Iva;



                    }
                    if (item.Cells[4].Value.ToString() == "IVA RETENIDO")
                    {
                        item.Cells[0].Value = Cuenta_iva_retenido;


                    }
                    if (item.Cells[4].Value.ToString() == "ISR RETENIDO")
                    {
                        item.Cells[0].Value = Cuenta_isr_retenido;

                    }
                    if (item.Cells[4].Value.ToString() == "ISR TRASLADADO")
                    {
                        item.Cells[0].Value = Cuenta_cargo_2;


                    }
                    if (item.Cells[4].Value.ToString() == "IEPS RETENIDO")
                    {
                        item.Cells[0].Value = Cuenta_Abono_1;


                    }
                    if (item.Cells[4].Value.ToString() == "IEPS TRASLADADO")
                    {
                        item.Cells[0].Value = Cuenta_Abono_2;

                    }
                    if (item.Cells[4].Value.ToString() == "CONCEPTO")
                    {
                        item.Cells[0].Value = Cuenta_cargo_3;

                    }



                }





                float Debe = 0;
                float haber = 0;
                foreach (DataGridViewRow row in poliza.Rows)
                {
                    float valor = float.Parse(row.Cells[2].Value.ToString());
                    Debe += valor;
                }
                foreach (DataGridViewRow row in poliza.Rows)
                {
                    float valor = float.Parse(row.Cells[3].Value.ToString());
                    haber += valor;
                }
                txtDebe.Text = Debe.ToString("N2");
                txtHaber.Text = haber.ToString("N2");


                //Actualizacion 17 enero 2019
                decimal diferencia;
                if (decimal.Parse(txtDebe.Text) > decimal.Parse(txtHaber.Text))
                {
                    diferencia = decimal.Parse(txtDebe.Text) - decimal.Parse(txtHaber.Text);

                    poliza.Rows.Insert(1, Cuenta_Abono_2, "OTROS", "0.00",diferencia, "IEPS TRASLADADO");
                    RECALCULAR();
                }
                else if (decimal.Parse(txtDebe.Text) < decimal.Parse(txtHaber.Text))
                {
                    diferencia = decimal.Parse(txtHaber.Text) - decimal.Parse(txtDebe.Text);

                    poliza.Rows.Insert(1, Cuenta_Abono_2, "OTROS", diferencia, "0.00", "IEPS TRASLADADO");
                    RECALCULAR();

                }

              


                #endregion
            }
            else
            {
                MessageBoxEx.Show("Fin del Ejercicio del Mes!" +
                                    "\n" + "Muchas Gracias! ;)",
                                                       "EKPolizaGastos",
                                                       MessageBoxButtons.OK,
                                                       MessageBoxIcon.Exclamation);
                this.Close();

            }





        }
        //Refresca Datos de las cuentas por departamento, sucursal y provedor
        private void cmbLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEmpresadatos();
        }





        //trash
        private void buttonX1_Click(object sender, EventArgs e)
        {
           
        }

       

        private void LoadFacturas(string Fecha)
        {
            try
            {

             
                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("NO tengo CFDIS cargados ese dia!",
                    "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;

            }
            catch (Exception ex)
            {

                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show(ex.Message,
                    "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Lectura_de_factura()
        {
            if (indexGridPosition + 1 <= totalFacturas)
            {
                indexGridPosition++;

                poliza.Rows.Clear();

                #region Lectura de Poliza
                dataGridViewX1.Rows[indexGridPosition].Selected = true;
                dataGridViewX1.CurrentCell = dataGridViewX1.Rows[indexGridPosition].Cells[0];


                Proveedor = dataGridViewX1.Rows[indexGridPosition].Cells[17].Value.ToString();
                RFC_proveedor = dataGridViewX1.Rows[indexGridPosition].Cells[19].Value.ToString();
                IdF = dataGridViewX1.Rows[indexGridPosition].Cells[0].Value.ToString();
                UUID = dataGridViewX1.Rows[indexGridPosition].Cells[26].Value.ToString();
                Folio = dataGridViewX1.Rows[indexGridPosition].Cells[2].Value.ToString();
                txtNumero.Text = dataGridViewX1.Rows[indexGridPosition].Cells[0].Value.ToString();

                if (Folio.Length > 5)
                {
                    Folio = Folio.Substring(0, 5);
                }

                //Buscamos si ya existe titulo para proovedor y de no existir se hace un generico
                Cuenta_cargo_1 = "0000-000-000";
                Cuenta_cargo_2 = "0000-000-000";
                Cuenta_cargo_3 = "0000-000-000";
                Cuenta_cargo_Iva = "0000-000-000";
                Cuenta_Abono_1 = "0000-000-000";
                Cuenta_Abono_2 = "0000-000-000";
                Cuenta_Abono_3 = "0000-000-000";
                Titulo_principal = "PROVEEDOR";
                Titulo_secundario = "RFC PROVEEDOR";
                Titulo_tercero = "IVA CONCEPTO";
                Departamento = txtDepto.Text.Trim();

                var proveedor = db.Proveedores.Where(p => p.RFC == RFC_proveedor &&
                                    p.IdEmpresa == IdEmpresa && p.IdLocalidad == IdLocalidad && p.Departamento == Departamento).FirstOrDefault();


                if (proveedor == null)
                {
                    //tomamos la primera creacion de proveedores

                    Titulo_principal = Proveedor + " " + RFC_proveedor; //proveedor a 40 caracteres + RFc

                    Titulo_secundario = Proveedor;

                    if (Proveedor.Length > 40)
                    {
                        Titulo_principal = Proveedor.Substring(0, 40) + " " + RFC_proveedor + "/n" + "articulo primero"; //proveedor a 40 caracteres + RFc
                    }

                    if (Proveedor.Length > 24)
                    {
                        Titulo_secundario = Proveedor.Substring(0, 25); //proveedor a 25 caracteres + RFc
                    }

                    if (Proveedor.Length > 24)
                    {
                        Titulo_tercero = "IVA-" + Proveedor.Substring(0, 20) + "-" + Folio; //proveedor a 25 caracteres + RFc
                    }

                }
                else
                {

                    //Titulo_principal = proveedor.Titulo_principal + " " + proveedor.RFC;

                    Cuenta_cargo_1 = proveedor.Cuenta_cargo_1;
                    Cuenta_cargo_2 = proveedor.Cuenta_cargo_2;
                    Cuenta_cargo_3 = proveedor.Cuenta_cargo_3;
                    Cuenta_cargo_Iva = proveedor.Cuenta_Cargo_Iva;
                    Cuenta_Abono_1 = proveedor.Cuenta_Abono_1;
                    Cuenta_Abono_2 = proveedor.Cuenta_Abono_2;
                    Cuenta_Abono_3 = proveedor.Cuenta_Abono_3;
                    Titulo_principal = proveedor.Titulo_principal;//CONCEPTO DE ENCABEZADO//
                    Titulo_secundario = proveedor.Titulo_secundario;//EL CONCEPTO DEL TOTAL//
                    Titulo_tercero = proveedor.Titulo_tercero; //EL CONCEPTO DEL IVA//

                    Departamento = txtDepto.Text;

                }

                //Titulo en cabecera
                txtConcepto.Text = Titulo_principal;
                //Fecha de la factura
                txtFecha.Text = DateTime.Parse(dataGridViewX1.Rows[indexGridPosition].Cells[35].Value.ToString()).ToString("dd/MM/yyyy");
                //Departamento
                Departamento = txtDepto.Text;





                DataTable totalEiva = new DataTable();

                using (SqlConnection conn = new SqlConnection(cnx))
                {
                    SqlCommand cmdD = new SqlCommand("SELECT Total, Importe as Iva FROM [" + ejercicio + "] " +
                    "  where IdFactura='" + IdF + "'", conn);


                    using (SqlDataAdapter a = new SqlDataAdapter(cmdD))
                    {
                        a.Fill(totalEiva);

                        total = totalEiva.Rows[0][0].ToString();
                        iva = totalEiva.Rows[0][1].ToString();

                    }

                }

                DataTable conceptos = new DataTable();

                using (SqlConnection conn = new SqlConnection(cnx))
                {
                    SqlCommand cmdD = new SqlCommand("SELECT Descripcion, ImporteX as Subtotal  FROM [" + ejercicio + "Conceptos] " +
                    "  where IdFactura='" + IdF + "'", conn);


                    using (SqlDataAdapter a = new SqlDataAdapter(cmdD))
                    {
                        a.Fill(conceptos);
                        //para tomar el primer concepto
                        primer_conccepto = conceptos.Rows[0][0].ToString();



                    }

                }


                //Agregando los conceptos al grid
                string descripcion;
                string subtotal;

                XmlDocument VarDocumentoXML = new XmlDocument();

                file = @"" + path + "/" + ejercicio + "/" + UUID + ".xml";
                VarDocumentoXML.Load(file);
                XmlNodeList xTax = VarDocumentoXML.GetElementsByTagName("cfdi:Traslado");
                XmlNamespaceManager VarManager = new XmlNamespaceManager(VarDocumentoXML.NameTable);
                VarManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                VarManager.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
                VarManager.AddNamespace("implocal", "http://www.sat.gob.mx/implocal");
                VarManager.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");



                Titulo_secundario = Proveedor;

                if (Proveedor.Length > 24)
                {
                    Titulo_secundario = Proveedor.Substring(0, 25); //proveedor
                }



                //El total de la poliza
                poliza.Rows.Insert(0, Cuenta_cargo_1, Titulo_secundario, "0.00", total, "TOTAL");


                Titulo_tercero = "IVA-" + Proveedor + "-" + Folio;
                if (Proveedor.Length > 20)
                {
                    Titulo_tercero = "IVA-" + Proveedor.Substring(0, 20) + "-" + Folio; //proveedor a 25 caracteres + RFc
                }



                if (xTax.Count == 0)//Infonavit
                {
                    iva = "0.00";
                    poliza.Rows.Insert(1, Cuenta_cargo_Iva, Titulo_tercero, iva, "0.00", "IVA TRASLADADO");
                }
                else
                {


                    TotalImpuestosTrasladados = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Impuestos/@TotalImpuestosTrasladados", VarManager).InnerText;
                    iva = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Impuestos/@TotalImpuestosTrasladados", VarManager).InnerText;

                }

                decimal ISR = 0;//1
                decimal IVA = 0;//2
                decimal IEPS = 0;//3
                decimal SubtotalSumado = 0;//
                decimal TotalFactura = 0;
                string TrasladosXML = "";
                decimal sumaSubtotalSumadoConIvaIEPS;
                decimal diferenciaIEPS;
                //Para los RFC con renta
                string iva_trasladado;
                string isr_retenido;
                string iva_retenido;


                //

                //Los Conceptos de la poliza
                if (xTax.Count == 0)//Infonavit
                {
                    foreach (DataRow item in conceptos.Rows)
                    {
                        descripcion = item[0].ToString();
                        subtotal = item[1].ToString();




                        if (descripcion.Length > 25)
                        {
                            descripcion = descripcion.Substring(0, 25);
                        }

                        poliza.Rows.Insert(2, Cuenta_cargo_3, descripcion, subtotal, "0.00", "CONCEPTO");
                    }
                }
                else
                {



                    //Total de la Factura
                    TotalFactura = decimal.Parse(total);
                    //VarDocumentoXML.GetElementsByTagName("cfdi:Concepto");
                    XmlNodeList VarConceptos =
                        VarDocumentoXML.SelectNodes("/cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto", VarManager);


                    XmlDocument xml = new XmlDocument();
                    XmlDocument xmlImpuestos = new XmlDocument();


                    bool result = RFC_proveedor.Equals("REME5202139N1");
                    if (result)
                    {
                        foreach (XmlElement node in VarConceptos)
                        {

                            TrasladosXML = string.Empty;
                            TrasladosXML = node.InnerXml;//antes dos firschild

                            xmlImpuestos.LoadXml(TrasladosXML);




                            iva_trasladado = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Importe", VarManager).InnerText;
                            iva_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion[2]/@Importe", VarManager).InnerText;
                            isr_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@Importe", VarManager).InnerText;

                            poliza.Rows.Insert(1, "0000-000-000", "ISR-RETENIDO", "0.00", isr_retenido, "ISR RETENIDO");
                            poliza.Rows.Insert(1, "0000-000-000", "IVA-RETENIDO", "0.00", iva_retenido, "IVA RETENIDO");
                            poliza.Rows.Insert(1, "0000-000-000", "IVA-TRASLADADO", iva_trasladado, "0.00", "IVA TRASLADADO");

                        }

                    }

                    bool result2 = RFC_proveedor.Equals("GABL540419HA8");
                    if (result2)
                    {
                        foreach (XmlElement node in VarConceptos)
                        {

                            TrasladosXML = string.Empty;
                            TrasladosXML = node.InnerXml;//antes dos firschild

                            xmlImpuestos.LoadXml(TrasladosXML);


                            iva_trasladado = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Importe", VarManager).InnerText;
                            iva_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion[2]/@Importe", VarManager).InnerText;
                            isr_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@Importe", VarManager).InnerText;


                            poliza.Rows.Insert(1, "0000-000-000", "ISR-RETENIDO", "0.00", isr_retenido, "ISR RETENIDO");
                            poliza.Rows.Insert(1, "0000-000-000", "IVA-RETENIDO", "0.00", iva_retenido, "IVA RETENIDO");
                            poliza.Rows.Insert(1, "0000-000-000", "IVA-TRASLADADO", iva_trasladado, "0.00", "IVA TRASLADADO");




                        }

                    }


                    foreach (XmlElement node in VarConceptos)
                    {



                        Importe = node.GetAttribute("Importe");
                        descripcionxml = node.GetAttribute("Descripcion");
                        subtotal = Importe;






                        try
                        {
                            TrasladosXML = string.Empty;
                            TrasladosXML = node.FirstChild.InnerXml;//antes dos firschild

                            xmlImpuestos.LoadXml(TrasladosXML);
                            //XmlNodeList xmlNL = xmlImpuestos.GetElementsByTagName("cfdi:Traslados");
                            //int total_nodos = xmlNL.Count;



                            if (!string.IsNullOrEmpty(TrasladosXML))
                            {



                                //// / cfdi:Traslado[2] / @Importe
                                baseX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[1]/@Base", VarManager).InnerText;
                                importeX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[1]/@Importe", VarManager).InnerText;
                                impuestoX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[1]/@Impuesto", VarManager).InnerText;

                                if (int.Parse(impuestoX) == 2)
                                {
                                    subtotal = baseX;
                                }

                                if (int.Parse(impuestoX) == 1)//ISR
                                {

                                    if (!string.IsNullOrEmpty(importeX) ||
                                        !string.IsNullOrEmpty(importeX) ||
                                        importeX == "")
                                    {

                                        ISR = ISR + decimal.Parse(importeX);
                                    }


                                }


                                if (int.Parse(impuestoX) == 2)//IVA
                                {

                                    if (!string.IsNullOrEmpty(importeX) ||
                                        !string.IsNullOrEmpty(importeX) ||
                                        importeX == "")
                                    {

                                        IVA = IVA + decimal.Parse(importeX);
                                    }


                                }


                                if (int.Parse(impuestoX) == 3)//IEPS
                                {

                                    if (!string.IsNullOrEmpty(importeX) ||
                                        !string.IsNullOrEmpty(importeX) ||
                                        importeX == "")
                                    {

                                        IEPS = IEPS + decimal.Parse(importeX);
                                    }


                                }




                                baseX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[2]/@Base", VarManager).InnerText;
                                importeX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[2]/@Importe", VarManager).InnerText;
                                impuestoX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[2]/@Impuesto", VarManager).InnerText;


                                if (int.Parse(impuestoX) == 2)
                                {
                                    subtotal = baseX;
                                }


                                if (int.Parse(impuestoX) == 1)//ISR
                                {

                                    if (!string.IsNullOrEmpty(importeX) ||
                                        !string.IsNullOrEmpty(importeX) ||
                                        importeX == "")
                                    {

                                        ISR = ISR + decimal.Parse(importeX);
                                    }


                                }


                                if (int.Parse(impuestoX) == 2)//IVA
                                {

                                    if (!string.IsNullOrEmpty(importeX) ||
                                        !string.IsNullOrEmpty(importeX) ||
                                        importeX == "")
                                    {

                                        IVA = IVA + decimal.Parse(importeX);
                                    }


                                }


                                if (int.Parse(impuestoX) == 3)//IEPS
                                {

                                    if (!string.IsNullOrEmpty(importeX) ||
                                        !string.IsNullOrEmpty(importeX) ||
                                        importeX == "")
                                    {

                                        IEPS = IEPS + decimal.Parse(importeX);
                                    }


                                }


                            }




                        }
                        catch (Exception ex)
                        {

                            Console.Write(ex.Message);

                        }





                        //Suma del Debe (los conceptos)
                        SubtotalSumado += decimal.Parse(subtotal);

                        if (descripcionxml.Length > 25)
                        {
                            descripcionxml = descripcionxml.Substring(0, 25);
                        }

                        poliza.Rows.Insert(1, Cuenta_cargo_3, descripcionxml, subtotal, "0.00", "CONCEPTO");


                    }


                    string leyenda_IVA = "IVA-" + Proveedor + "-" + Folio; ;//.Substring(0, 20)
                    string leyenda_IEPS = "IEPS-" + Proveedor + "-" + Folio;
                    string leyenda_ISR = "ISR-" + Proveedor + "-" + Folio;


                    sumaSubtotalSumadoConIvaIEPS = SubtotalSumado + IVA + IEPS;


                    if (IVA > 0)
                    {
                        poliza.Rows.Insert(1, Cuenta_cargo_Iva, leyenda_IVA, IVA, "0.00", "IVA TRASLADADO");
                    }

                    if (ISR > 0)
                    {
                        poliza.Rows.Insert(1, Cuenta_cargo_Iva, leyenda_ISR, ISR, "0.00", "ISR TRASLADADO");
                    }

                    if (IEPS > 0)
                    {



                        if (sumaSubtotalSumadoConIvaIEPS == TotalFactura)//significa que agrego el IEPS en la Factura
                        {
                            //AGREGO IEPS
                            poliza.Rows.Insert(1, Cuenta_cargo_Iva, leyenda_IEPS, IEPS, "0.00", "IEPS TRASLADADO");
                        }


                        if (sumaSubtotalSumadoConIvaIEPS > TotalFactura)//significa que sobra el IEPS en la Factura
                        {
                            //NO AGREGO IEPS

                        }

                    }


                    if (sumaSubtotalSumadoConIvaIEPS < TotalFactura)//significa que el IEPS es necesario 
                    {
                        //AGREGO IEPS CALCULADO
                        diferenciaIEPS = TotalFactura - sumaSubtotalSumadoConIvaIEPS;


                        poliza.Rows.Insert(1, Cuenta_cargo_Iva, leyenda_IEPS, diferenciaIEPS, "0.00", "IEPS TRASLADADO");
                    }









                }








                float Debe = 0;
                float haber = 0;
                foreach (DataGridViewRow row in poliza.Rows)
                {
                    float valor = float.Parse(row.Cells[2].Value.ToString());
                    Debe += valor;
                }
                foreach (DataGridViewRow row in poliza.Rows)
                {
                    float valor = float.Parse(row.Cells[3].Value.ToString());
                    haber += valor;
                }
                txtDebe.Text = Debe.ToString("C2");
                txtHaber.Text = haber.ToString("C2");
                #endregion
            }
        }





        #endregion
        //Actualizar datos de proovedor en proceso


        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (txtDepto.Text != "")
            {
                //1 comprubeo si existe empresa con este departamento
                var ExisteProovedor = db.Proveedores.Where(p => p.RFC == RFC_proveedor
                && p.IdEmpresa == IdEmpresa).FirstOrDefault();
                string numeroProvedorConvertido = "0";
                if (ExisteProovedor != null)
                {

                    numeroProvedorConvertido = Convert.ToString(ExisteProovedor.IdProveedor);




                    if (int.Parse(numeroProvedorConvertido) < 10)
                    {
                        numeroProvedorConvertido = "00" + numeroProvedorConvertido;

                    }
                    else if (int.Parse(numeroProvedorConvertido) >= 10 && int.Parse(numeroProvedorConvertido) <= 99)
                    {

                        numeroProvedorConvertido = "0" + numeroProvedorConvertido;
                    }


                    MessageBoxEx.EnableGlass = false;

                    DialogResult actualizarProveedor = MessageBoxEx.Show("¡Este Proveedor ya existe ! \n" +
                                                                       "¿Desea Actualizar datos de Proveedor?",
                                                        "EKPolizaGastos",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

                    if (actualizarProveedor == DialogResult.Yes)
                    {

                        Proveedores proveedoresM = new Proveedores();
                        proveedoresM = ExisteProovedor;

                        proveedoresM.Proveedor = Proveedor_Completo;
                        proveedoresM.RFC = RFC_proveedor;
                        proveedoresM.NoProveedor = numeroProvedorConvertido;
                        proveedoresM.IdEmpresa = IdEmpresa;
                        proveedoresM.IdLocalidad = IdLocalidad;
                        proveedoresM.Cuenta_cargo_1 = Cuenta_cargo_1;
                        proveedoresM.Cuenta_cargo_2 = Cuenta_cargo_2;
                        proveedoresM.Cuenta_cargo_3 = Cuenta_cargo_3;
                        proveedoresM.Cuenta_Cargo_Iva = Cuenta_cargo_Iva;
                        proveedoresM.Cuenta_Abono_1 = Cuenta_Abono_1;
                        proveedoresM.Cuenta_Abono_2 = Cuenta_Abono_2;
                        proveedoresM.Cuenta_Abono_3 = Cuenta_Abono_3;
                        proveedoresM.Titulo_principal = Titulo_principal;
                        proveedoresM.Titulo_secundario = Titulo_secundario;
                        proveedoresM.Titulo_tercero = Titulo_tercero;

                        proveedoresM.Departamento = txtDepto.Text;
                        proveedoresM.Isr_Retenido = Cuenta_isr_retenido;
                        proveedoresM.Iva_Retenido = Cuenta_iva_retenido;
                        //modifico las propiedades
                        db.Proveedores.Attach(proveedoresM);
                        db.Entry(proveedoresM).State =
                            EntityState.Modified;
                        db.SaveChanges();

                        MessageBoxEx.EnableGlass = false;
                        MessageBoxEx.Show("Proveedor Actualizado con Exito!",
                                                       "EKPolizaGastos",
                                                       MessageBoxButtons.OK,
                                                       MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBoxEx.EnableGlass = false;
                    MessageBoxEx.Show("¡Este Proveedor NO existe ! \n" +
                                                                       "Termine la poliza para guardar Por favor",
                                                        "EKPolizaGastos",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("¡No Ha Seleccionado un Departamento!\n" +
                                                                   "Seleccione una localidad Por Favor",
                                                    "EKPolizaGastos",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
            }



           

         


        }
    }
}
