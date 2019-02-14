

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
        DataTable empresas;
        SuperTooltipInfo superTooltip;
        #endregion

        #region Attributes
        public string ejercicio;
        public string cnx;
        int indexGrid;
        int indexGridPosition=0;
        int totalFacturas=0;
        string file;
        int Fila_actualizar_cargo;
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
        private int IdEmpresas;//variable agregada
        private int IdLocalidad;
        private string Cuenta_isr_trasladado;
        private string Cuenta_ieps_retenido;
        private string Cuenta_ieps_trasladado;
        #endregion

        #region Methods (metodos)
        //CARGO LAS CLASES
        public PlantillaPrepolizaForm()
        {
            InitializeComponent();

            db = new SEMP_SATContext();
            readSATFactura = new ReadSATFactura();
            localidad = new DataTable();
            empresas = new DataTable();
            superTooltip = new SuperTooltipInfo();
        }
        //COMBO DE EMPRESAS
        public void FillComboEmpresas()
        {
            empresas = readSATFactura.Empresas(cnx);
            cmbLocalidades.DataSource = empresas;
            cmbLocalidades.DisplayMember = "Empresa";
            cmbLocalidades.ValueMember = "IdEmpresa";
          

        }
        //BUSQUEDA DEL MES
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
        //TRADUCCION DE MES LETRA
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
        //DURANTE EL LOAD
        private void LoadF()
        {


            //Configuracion de los tool tip para botones

            #region  Tooltips buttons
            //superTooltip.HeaderText = "EKPolizaGastos";
            //superTooltip.BodyText = "<strong>Agregar nuevo concepto</strong><strong> + </strong>  ";
            //superTooltip.FooterText = "selecciona si es de tipo cargo ó abono el concepto nuevo";
            //superTooltip1.SetSuperTooltip(buttonX4, superTooltip);


            //Super Tooltips can have multiple lines of text.\r\n\r\nTo better explain functionalit
            superTooltip1.SetSuperTooltip(buttonX4, new DevComponents.DotNetBar.SuperTooltipInfo("EKPolizaGastos",
                "<strong>Agregar nuevo concepto</strong>",
                "\n Seleccione si sera de tipo cargo ó abono!"
           , null, ((System.Drawing.Image)(EKPolizaGastos.Properties.Resources.iconToolTip_fw)),
                DevComponents.DotNetBar.eTooltipColor.Blue));
            // //
            superTooltip1.SetSuperTooltip(buttonX5, new DevComponents.DotNetBar.SuperTooltipInfo("EKPolizaGastos",
              "<strong>Cuentas de Abono</strong>",
              "\n Seleccione ó Actualize cuentas de Abono!"
         , null, ((System.Drawing.Image)(EKPolizaGastos.Properties.Resources.iconToolTip_fw)),
              DevComponents.DotNetBar.eTooltipColor.Green));

            superTooltip1.SetSuperTooltip(buttonX6, new DevComponents.DotNetBar.SuperTooltipInfo("EKPolizaGastos",
            "<strong>Cuentas de Cargo</strong>",
            "\n  Seleccione ó Actualize cuentas de Cargo!"
       , null, ((System.Drawing.Image)(EKPolizaGastos.Properties.Resources.iconToolTip_fw)),
            DevComponents.DotNetBar.eTooltipColor.Green));

            superTooltip1.SetSuperTooltip(buttonX7, new DevComponents.DotNetBar.SuperTooltipInfo("EKPolizaGastos",
            "<strong>Catalogo de Cuentas</strong>", ""
       , null, ((System.Drawing.Image)(EKPolizaGastos.Properties.Resources.iconToolTip_fw)),
            DevComponents.DotNetBar.eTooltipColor.Red));

            superTooltip1.SetSuperTooltip(buttonX3, new DevComponents.DotNetBar.SuperTooltipInfo("EKPolizaGastos",
          "<strong>Actualizar cuentas de proveedor</strong>", ""
     , null, ((System.Drawing.Image)(EKPolizaGastos.Properties.Resources.iconToolTip_fw)),
          DevComponents.DotNetBar.eTooltipColor.Gray));

            superTooltip1.SetSuperTooltip(buttonX2, new DevComponents.DotNetBar.SuperTooltipInfo("EKPolizaGastos",
         "<strong>Generar Poliza!</strong>", ""
    , null, ((System.Drawing.Image)(EKPolizaGastos.Properties.Resources.iconToolTip_fw)),
         DevComponents.DotNetBar.eTooltipColor.Gray)); 
            #endregion

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

            cmbLocalidades.SelectedValue = datos.IdEmpresa;
            cmbLocalidades.SelectedText = datos.Empresa;

            StartPoliza();
          
        }
        //LEE LA PRIMER FACTURA
        public void StartPoliza()
        {
            DataTable facturas= new DataTable("Facturas");

            facturas = readSATFactura.listExercise(cnx, ejercicio);

            dataGridViewX1.DataSource = facturas;
            indexGrid = dataGridViewX1.Rows.Count;

            if (indexGrid > 0)
            {
                Lectura_de_factura();
            }
            else
            {
                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("No hay facturas pendientes por generar poliza! ;)",
                                                       "EKPolizaGastos",
                                                       MessageBoxButtons.OK,
                                                       MessageBoxIcon.Exclamation);
            }


            #region Lectura de Poliza
           // dataGridViewX1.Rows[indexGridPosition].Selected = true;
           // dataGridViewX1.CurrentCell = dataGridViewX1.Rows[indexGridPosition].Cells[0];


           // Proveedor = dataGridViewX1.Rows[indexGridPosition].Cells[17].Value.ToString();
           // Proveedor_Completo = dataGridViewX1.Rows[indexGridPosition].Cells[17].Value.ToString();
           // RFC_proveedor = dataGridViewX1.Rows[indexGridPosition].Cells[19].Value.ToString();
           // IdF = dataGridViewX1.Rows[indexGridPosition].Cells[0].Value.ToString();
           // UUID = dataGridViewX1.Rows[indexGridPosition].Cells[26].Value.ToString();
           // Folio = dataGridViewX1.Rows[indexGridPosition].Cells[2].Value.ToString();
           // txtNumero.Text = dataGridViewX1.Rows[indexGridPosition].Cells[0].Value.ToString();

          

           // //Buscamos si ya existe titulo para proovedor y de no existir se hace un generico
           // Cuenta_cargo_1 = "0000-000-000";
           // Cuenta_cargo_2 = "0000-000-000";
           // Cuenta_cargo_3 = "0000-000-000";
           // Cuenta_cargo_Iva = "0000-000-000";
           // Cuenta_Abono_1 = "0000-000-000";
           // Cuenta_Abono_2 = "0000-000-000";
           // Cuenta_Abono_3 = "0000-000-000";
           // Titulo_principal = "Proveedor X";
           // Titulo_secundario = "RFCXXX";
           // Titulo_tercero = "blabla";
           // Departamento = "0";
           // Cuenta_isr_retenido = "0000-000-000";
           // Cuenta_iva_retenido = "0000-000-000";

           // var proveedor = db.Proveedores.Where(p => p.RFC == RFC_proveedor &&
           //                     p.IdEmpresa == IdEmpresaEjercicio ).FirstOrDefault();//&& Departamento == txtDepto.Text
           // //rev parte uno

           // if (Folio.Length > 5)
           // {
           //     Folio = Folio.Substring(0, 5);
           // }

           // if (proveedor == null)
           // {
           //     ////tomamos la primera creacion de proveedores

           //     Titulo_principal = Proveedor + " " + RFC_proveedor; //proveedor a 40 caracteres + RFc

           //     Titulo_secundario = Proveedor;

           //     if (Proveedor.Length > 40)
           //     {
           //         Titulo_principal = Proveedor.Substring(0, 40) + " " + RFC_proveedor; //proveedor a 40 caracteres + RFc
           //     }

           //     if (Proveedor.Length > 25)
           //     {
           //         Titulo_secundario = Proveedor.Substring(0, 25); //proveedor a 25 caracteres + RFc
           //     }

           //     if (Proveedor.Length > 20)
           //     {
           //         Titulo_tercero = "IVA-" + Proveedor.Substring(0, 20) + "-" + Folio; //proveedor a 25 caracteres + RFc
           //     }

           // }
           // else
           // {

           //     //// Titulo_principal = proveedor.Titulo_principal + " " + proveedor.RFC;

           //     Cuenta_cargo_1 = proveedor.Cuenta_cargo_1;
           //     Cuenta_cargo_2 = proveedor.Cuenta_cargo_2;
           //     Cuenta_cargo_3 = proveedor.Cuenta_cargo_3;
           //     Cuenta_cargo_Iva = proveedor.Cuenta_Cargo_Iva;
           //     Cuenta_Abono_1 = proveedor.Cuenta_Abono_1;
           //     Cuenta_Abono_2 = proveedor.Cuenta_Abono_2;
           //     Cuenta_Abono_3 = proveedor.Cuenta_Abono_3;

           //     Cuenta_isr_retenido = proveedor.Isr_Retenido;//cuenta isr retenido
           //     Cuenta_iva_retenido = proveedor.Iva_Retenido;//cuenta iva retenido

           //     Titulo_principal = proveedor.Titulo_principal;//el concepto del encabezado
           //     Titulo_secundario = proveedor.Titulo_secundario;//el concepto del total
           //     Titulo_tercero = proveedor.Titulo_tercero; //el concepto del iva

           //     Departamento = txtDepto.Text;



           //     if (Cuenta_cargo_1.Length <= 1)
           //     {
           //         Cuenta_cargo_1 = "0000-000-000";
                  
           //     }
           //     if (Cuenta_cargo_2.Length <= 1)
           //     {
                   
           //         Cuenta_cargo_2 = "0000-000-000";
                   
           //     }
           //     if (Cuenta_cargo_3.Length <= 1)
           //     {
                   
           //         Cuenta_cargo_3 = "0000-000-000";
                 
           //     }
           //     if (Cuenta_cargo_Iva.Length <= 1)
           //     {
                  
           //         Cuenta_cargo_Iva = "0000-000-000";
                   
           //     }
           //     if (Cuenta_Abono_1.Length <= 1)
           //     {
                  
           //         Cuenta_Abono_1 = "0000-000-000";
                   
           //     }
           //     if (Cuenta_Abono_2.Length <= 1)
           //     {
                    
           //         Cuenta_Abono_2 = "0000-000-000";
                  
           //     }
           //     if (Cuenta_Abono_3.Length <= 1)
           //     {
                   
           //         Cuenta_Abono_3 = "0000-000-000";
                   
           //     }
           //     if (Cuenta_isr_retenido.Length <= 1)
           //     {
                    
           //         Cuenta_isr_retenido = "0000-000-000";
                   
           //     }
           //     if (Cuenta_iva_retenido.Length <= 1)
           //     {
           //         Cuenta_iva_retenido = "0000-000-000";
           //     }


           // }

           // //Titulo en cabecera
           // txtConcepto.Text = Titulo_principal;
           // //Fecha de la factura
           // txtFecha.Text = DateTime.Parse(dataGridViewX1.Rows[indexGridPosition].Cells[35].Value.ToString()).ToString("dd/MM/yyyy");
           // //Departamento

           //  Departamento =txtDepto.Text ;


           // //rev parte dos
          




           // DataTable totalEiva = new DataTable();

           // using (SqlConnection conn = new SqlConnection(cnx))
           // {
           //     SqlCommand cmdD = new SqlCommand("SELECT Total, Importe as Iva FROM [" + ejercicio + "] " +
           //     "  where IdFactura='" + IdF + "'", conn);


           //     using (SqlDataAdapter a = new SqlDataAdapter(cmdD))
           //     {
           //         a.Fill(totalEiva);

           //         total = totalEiva.Rows[0][0].ToString();
           //         iva = totalEiva.Rows[0][1].ToString();

           //     }

           // }




           // DataTable conceptos = new DataTable();

           // using (SqlConnection conn = new SqlConnection(cnx))
           // {
           //     SqlCommand cmdD = new SqlCommand("SELECT Descripcion, ImporteX as Subtotal  FROM [" + ejercicio + "Conceptos] " +
           //     "  where IdFactura='" + IdF + "'", conn);


           //     using (SqlDataAdapter a = new SqlDataAdapter(cmdD))
           //     {
           //         a.Fill(conceptos);
           //         //para tomar el primer concepto
           //         primer_conccepto = conceptos.Rows[0][0].ToString();



           //     }

           // }





           // //Agregando los conceptos al grid
           // string descripcion;
           // string subtotal;

           // XmlDocument VarDocumentoXML = new XmlDocument();

           // file = @"" + path + "/" + ejercicio + "/" + UUID + ".xml";
           // VarDocumentoXML.Load(file);
           // XmlNodeList xTax = VarDocumentoXML.GetElementsByTagName("cfdi:Traslado");
           // XmlNamespaceManager VarManager = new XmlNamespaceManager(VarDocumentoXML.NameTable);
           // VarManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
           // VarManager.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
           // VarManager.AddNamespace("implocal", "http://www.sat.gob.mx/implocal");
           // VarManager.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");



           // //Titulo_secundario = Proveedor;

           // //if (Proveedor.Length > 24)
           // //{
           // //    Titulo_secundario = Proveedor.Substring(0, 25); //proveedor
           // //}



           // //El total de la poliza
           // poliza.Rows.Insert(0, Cuenta_cargo_1, Titulo_secundario, "0.00", total, "TOTAL");


           //// Titulo_tercero = "IVA-" + Proveedor + "-" + Folio;
           // //if (Proveedor.Length > 20)
           // //{
           // //    Titulo_tercero = "IVA-" + Proveedor.Substring(0, 20) + "-" + Folio; //proveedor a 25 caracteres + RFc
           // //}



           // if (xTax.Count == 0)//Infonavit
           // {
           //     iva = "0.00";
           //     poliza.Rows.Insert(1, Cuenta_cargo_Iva, Titulo_tercero, iva, "0.00", "IVA TRASLADADO");
           // }
           // else
           // {


           //     TotalImpuestosTrasladados = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Impuestos/@TotalImpuestosTrasladados", VarManager).InnerText;
           //     iva = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Impuestos/@TotalImpuestosTrasladados", VarManager).InnerText;

           // }

           // decimal ISR = 0;//1
           // decimal IVA = 0;//2
           // decimal IEPS = 0;//3
           // decimal SubtotalSumado = 0;//
           // decimal TotalFactura = 0;
           // string TrasladosXML = "";
           // decimal sumaSubtotalSumadoConIvaIEPS;
           // decimal diferenciaIEPS;
           // //Para los RFC con renta
           // string iva_trasladado;
           // string isr_retenido;
           // string iva_retenido;

           // //Los Conceptos de la poliza
           // if (xTax.Count == 0)//Infonavit
           // {
           //     foreach (DataRow item in conceptos.Rows)
           //     {
           //         descripcion = item[0].ToString();
           //         subtotal = item[1].ToString();




           //         if (descripcion.Length > 25)
           //         {
           //             descripcion = descripcion.Substring(0, 25);
           //         }

           //         poliza.Rows.Insert(2, Cuenta_cargo_3, descripcion, subtotal, "0.00", "CONCEPTO");
           //     }
           // }
           // else
           // {



           //     //Total de la Factura
           //     TotalFactura = decimal.Parse(total);
               
           //     XmlNodeList VarConceptos =
           //         VarDocumentoXML.SelectNodes("/cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto", VarManager);


           //     XmlDocument xml = new XmlDocument();
           //     XmlDocument xmlImpuestos = new XmlDocument();


           //     bool result = RFC_proveedor.Equals("REME5202139N1");
           //     if (result)
           //     {
           //         foreach (XmlElement node in VarConceptos)
           //         {

           //             TrasladosXML = string.Empty;
           //             TrasladosXML = node.InnerXml;//antes dos firschild

           //             xmlImpuestos.LoadXml(TrasladosXML);




           //             iva_trasladado = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Importe", VarManager).InnerText;
           //             iva_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion[2]/@Importe", VarManager).InnerText;
           //             isr_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@Importe", VarManager).InnerText;

           //             poliza.Rows.Insert(1, Cuenta_isr_retenido, "ISR-RETENIDO", "0.00", isr_retenido, "ISR RETENIDO");
           //             poliza.Rows.Insert(1, Cuenta_iva_retenido, "IVA-RETENIDO", "0.00", iva_retenido, "IVA RETENIDO");
           //             poliza.Rows.Insert(1, Cuenta_cargo_Iva, "IVA-TRASLADADO", iva_trasladado, "0.00", "IVA TRASLADADO");

           //         }

           //     }

           //     bool result2 = RFC_proveedor.Equals("GABL540419HA8");
           //     if (result2)
           //     {
           //         foreach (XmlElement node in VarConceptos)
           //         {

           //             TrasladosXML = string.Empty;
           //             TrasladosXML = node.InnerXml;//antes dos firschild

           //             xmlImpuestos.LoadXml(TrasladosXML);


           //             iva_trasladado = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Importe", VarManager).InnerText;
           //             iva_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion[2]/@Importe", VarManager).InnerText;
           //             isr_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@Importe", VarManager).InnerText;


           //             poliza.Rows.Insert(1, Cuenta_isr_retenido, "ISR-RETENIDO", "0.00", isr_retenido, "ISR RETENIDO");
           //             poliza.Rows.Insert(1, Cuenta_iva_retenido, "IVA-RETENIDO", "0.00", iva_retenido, "IVA RETENIDO");
           //             poliza.Rows.Insert(1, Cuenta_cargo_Iva, "IVA-TRASLADADO", iva_trasladado, "0.00", "IVA TRASLADADO");




           //         }

           //     }


           //     foreach (XmlElement node in VarConceptos)
           //     {



           //         Importe = node.GetAttribute("Importe");
           //         descripcionxml = node.GetAttribute("Descripcion");
           //         subtotal = Importe;






           //         try
           //         {
           //             TrasladosXML = string.Empty;
           //             TrasladosXML = node.FirstChild.InnerXml;//antes dos firschild

           //             xmlImpuestos.LoadXml(TrasladosXML);
           //             //XmlNodeList xmlNL = xmlImpuestos.GetElementsByTagName("cfdi:Traslados");
           //             //int total_nodos = xmlNL.Count;



           //             if (!string.IsNullOrEmpty(TrasladosXML))
           //             {



           //                 //// / cfdi:Traslado[2] / @Importe
           //                 baseX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[1]/@Base", VarManager).InnerText;
           //                 importeX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[1]/@Importe", VarManager).InnerText;
           //                 impuestoX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[1]/@Impuesto", VarManager).InnerText;

           //                 if (int.Parse(impuestoX) == 2)
           //                 {
           //                     subtotal = baseX;
           //                 }

           //                 if (int.Parse(impuestoX) == 1)//ISR
           //                 {

           //                     if (!string.IsNullOrEmpty(importeX) ||
           //                         !string.IsNullOrEmpty(importeX) ||
           //                         importeX == "")
           //                     {

           //                         ISR = ISR + decimal.Parse(importeX);
           //                     }


           //                 }


           //                 if (int.Parse(impuestoX) == 2)//IVA
           //                 {

           //                     if (!string.IsNullOrEmpty(importeX) ||
           //                         !string.IsNullOrEmpty(importeX) ||
           //                         importeX == "")
           //                     {

           //                         IVA = IVA + decimal.Parse(importeX);
           //                     }


           //                 }


           //                 if (int.Parse(impuestoX) == 3)//IEPS
           //                 {

           //                     if (!string.IsNullOrEmpty(importeX) ||
           //                         !string.IsNullOrEmpty(importeX) ||
           //                         importeX == "")
           //                     {

           //                         IEPS = IEPS + decimal.Parse(importeX);
           //                     }


           //                 }




           //                 baseX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[2]/@Base", VarManager).InnerText;
           //                 importeX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[2]/@Importe", VarManager).InnerText;
           //                 impuestoX = xmlImpuestos.SelectSingleNode("/cfdi:Traslados/cfdi:Traslado[2]/@Impuesto", VarManager).InnerText;


           //                 if (int.Parse(impuestoX) == 2)
           //                 {
           //                     subtotal = baseX;
           //                 }


           //                 if (int.Parse(impuestoX) == 1)//ISR
           //                 {

           //                     if (!string.IsNullOrEmpty(importeX) ||
           //                         !string.IsNullOrEmpty(importeX) ||
           //                         importeX == "")
           //                     {

           //                         ISR = ISR + decimal.Parse(importeX);
           //                     }


           //                 }


           //                 if (int.Parse(impuestoX) == 2)//IVA
           //                 {

           //                     if (!string.IsNullOrEmpty(importeX) ||
           //                         !string.IsNullOrEmpty(importeX) ||
           //                         importeX == "")
           //                     {

           //                         IVA = IVA + decimal.Parse(importeX);
           //                     }


           //                 }


           //                 if (int.Parse(impuestoX) == 3)//IEPS
           //                 {

           //                     if (!string.IsNullOrEmpty(importeX) ||
           //                         !string.IsNullOrEmpty(importeX) ||
           //                         importeX == "")
           //                     {

           //                         IEPS = IEPS + decimal.Parse(importeX);
           //                     }


           //                 }

           //                 #region trash
           //                 //xml.LoadXml(TrasladosXML);

           //                 //baseX = xml.DocumentElement.Attributes["Base"].Value;
           //                 //importeX = xml.DocumentElement.Attributes["Importe"].Value;
           //                 //impuestoX = xml.DocumentElement.Attributes["Impuesto"].Value;
           //                 //tasaOCuotaX = xml.DocumentElement.Attributes["TasaOCuota"].Value;
           //                 //tipoFactorX = xml.DocumentElement.Attributes["TipoFactor"].Value;



           //                 //if (int.Parse(impuestoX) == 1)//ISR
           //                 //{

           //                 //    if (!string.IsNullOrEmpty(importeX) ||
           //                 //        !string.IsNullOrEmpty(importeX) ||
           //                 //        importeX == "")
           //                 //    {

           //                 //        ISR = ISR + decimal.Parse(importeX);
           //                 //    }


           //                 //}


           //                 //if (int.Parse(impuestoX) == 2)//IVA
           //                 //{

           //                 //    if (!string.IsNullOrEmpty(importeX) ||
           //                 //        !string.IsNullOrEmpty(importeX) ||
           //                 //        importeX == "")
           //                 //    {

           //                 //        IVA = IVA + decimal.Parse(importeX);
           //                 //    }


           //                 //}


           //                 //if (int.Parse(impuestoX) == 3)//IEPS
           //                 //{

           //                 //    if (!string.IsNullOrEmpty(importeX) ||
           //                 //        !string.IsNullOrEmpty(importeX) ||
           //                 //        importeX == "")
           //                 //    {

           //                 //        IEPS = IEPS + decimal.Parse(importeX);
           //                 //    }


           //                 //}

           //                 #endregion



           //             }




           //         }
           //         catch (Exception ex)
           //         {

           //             Console.Write(ex.Message);

           //         }





           //         //Suma del Debe (los conceptos)
           //         SubtotalSumado += decimal.Parse(subtotal);

           //         if (descripcionxml.Length > 25)
           //         {
           //             descripcionxml = descripcionxml.Substring(0, 25);
           //         }

           //         poliza.Rows.Insert(1, Cuenta_cargo_3, descripcionxml, subtotal, "0.00", "CONCEPTO");


           //     }


           //     if(Proveedor.Length>19)
           //     {
           //         Proveedor = Proveedor.Substring(0, 18);
           //     }

           //     string leyenda_IVA = "IVA-" + Proveedor + "-" + Folio; ;//.Substring(0, 20)
           //     string leyenda_IEPS = "IEPS-" + Proveedor + "-" + Folio;
           //     string leyenda_ISR = "ISR-" + Proveedor + "-" + Folio;


           //     sumaSubtotalSumadoConIvaIEPS = SubtotalSumado + IVA + IEPS;


           //     if (IVA > 0)
           //     {
           //         poliza.Rows.Insert(1, Cuenta_cargo_Iva, leyenda_IVA, IVA, "0.00", "IVA TRASLADADO");
           //     }

           //     if (ISR > 0)
           //     {
           //         poliza.Rows.Insert(1, Cuenta_cargo_2, leyenda_ISR, ISR, "0.00", "ISR TRASLADADO");
           //     }

           //     if (IEPS > 0)
           //     {



           //         if (sumaSubtotalSumadoConIvaIEPS == TotalFactura)//significa que agrego el IEPS en la Factura
           //         {
           //             //AGREGO IEPS
           //             poliza.Rows.Insert(1, Cuenta_Abono_2, leyenda_IEPS, IEPS, "0.00", "IEPS TRASLADADO");
           //         }


           //         if (sumaSubtotalSumadoConIvaIEPS > TotalFactura)//significa que sobra el IEPS en la Factura
           //         {
           //             //NO AGREGO IEPS

           //         }

           //     }


           //     if (sumaSubtotalSumadoConIvaIEPS < TotalFactura)//significa que el IEPS es necesario 
           //     {
           //         //AGREGO IEPS CALCULADO
           //         diferenciaIEPS = TotalFactura - sumaSubtotalSumadoConIvaIEPS;


           //         poliza.Rows.Insert(1, Cuenta_Abono_2, leyenda_IEPS, diferenciaIEPS, "0.00", "IEPS TRASLADADO");
           //     }









           // }



           // //LLeno las cuentas de poliza
           // foreach (DataGridViewRow item in poliza.Rows)
           // {

           //     if (item.Cells[4].Value.ToString() == "TOTAL")
           //     {
           //         item.Cells[0].Value = Cuenta_cargo_1;
           //     }
           //     if (item.Cells[4].Value.ToString() == "IVA TRASLADADO")
           //     {
           //         item.Cells[0].Value = Cuenta_cargo_Iva;

                    
                  
           //     }
           //     if (item.Cells[4].Value.ToString() == "IVA RETENIDO")
           //     {
           //         item.Cells[0].Value = Cuenta_iva_retenido;


           //     }
           //     if (item.Cells[4].Value.ToString() == "ISR RETENIDO")
           //     {
           //         item.Cells[0].Value = Cuenta_isr_retenido;

           //     }
           //     if (item.Cells[4].Value.ToString() == "ISR TRASLADADO")
           //     {
           //         item.Cells[0].Value = Cuenta_cargo_2;


           //     }
           //     if (item.Cells[4].Value.ToString() == "IEPS RETENIDO")
           //     {
           //         item.Cells[0].Value = Cuenta_Abono_1;


           //     }
           //     if (item.Cells[4].Value.ToString() == "IEPS TRASLADADO")
           //     {
           //         item.Cells[0].Value = Cuenta_Abono_2;

           //     }
           //     if (item.Cells[4].Value.ToString() == "CONCEPTO")
           //     {
           //         item.Cells[0].Value =Cuenta_cargo_3;

           //     }



           // }




           // float Debe = 0;
           // float haber = 0;
           // foreach (DataGridViewRow row in poliza.Rows)
           // {
           //     float valor = float.Parse(row.Cells[2].Value.ToString());
           //     Debe += valor;
           // }
           // foreach (DataGridViewRow row in poliza.Rows)
           // {
           //     float valor = float.Parse(row.Cells[3].Value.ToString());
           //     haber += valor;
           // }
           // txtDebe.Text = Debe.ToString("N2");
           // txtHaber.Text = haber.ToString("N2");

           // //Actualizacion 17 enero 2019
           // decimal diferencia;
           // if (decimal.Parse(txtDebe.Text) > decimal.Parse(txtHaber.Text))
           // {
           //     diferencia = decimal.Parse(txtDebe.Text) - decimal.Parse(txtHaber.Text);

           //     poliza.Rows.Insert(1, Cuenta_Abono_2, "OTROS", "0.00",diferencia, "IEPS TRASLADADO");
           //     RECALCULAR();
           // }
           // else if (decimal.Parse(txtDebe.Text) < decimal.Parse(txtHaber.Text))
           // {
           //     diferencia = decimal.Parse(txtHaber.Text) - decimal.Parse(txtDebe.Text);

           //     poliza.Rows.Insert(1, Cuenta_Abono_2, "OTROS", diferencia, "0.00", "IEPS TRASLADADO");
           //     RECALCULAR();

           // }

          
            #endregion

        }
         //RECALCULAR SUMA
        public void RECALCULAR()
        {
            try
            {
                float Debe = 0;
                float haber = 0;
                float valor1 = 0;
                float valor = 0;
                foreach (DataGridViewRow row in poliza.Rows)
                {
                    if (row.Cells[2].Value != null)
                    {
                        valor1 = float.Parse(row.Cells[2].Value.ToString());
                        Debe += valor1;
                    }

                }

                foreach (DataGridViewRow row in poliza.Rows)
                {

                    if (row.Cells[3].Value != null)
                    {
                        valor = float.Parse(row.Cells[3].Value.ToString());
                        haber += valor;
                    }
                }
                txtDebe.Text = Debe.ToString("N2");
                txtHaber.Text = haber.ToString("N2");

            }
            catch (Exception ex)
            {

            }
               

        }
        public void CargarEmpresadatos()
        {
            IdEmpresas = int.Parse(cmbLocalidades.SelectedValue.ToString());
            var empresas = db.Empresas.Where(p => p.IdEmpresa == IdEmpresas).FirstOrDefault();

            IdEmpresa = empresas.IdEmpresa;//Convert.ToInt32(localidades.IdEmpresa);
            txtDepto.Text = "2";//localidades.Departamento;


            var proveedor = db.Proveedores.Where(p => p.RFC == RFC_proveedor &&
                                         p.IdEmpresa == IdEmpresa).FirstOrDefault();

            int empresa = int.Parse(cmbLocalidades.SelectedValue.ToString());

            btnAbono.Text = string.Empty;
            buttonItem2.Text = string.Empty;
            buttonItem3.Text = string.Empty;

            buttonItem4.Text = string.Empty;
            buttonItem5.Text = string.Empty;
            buttonItem6.Text = string.Empty;

           
            if (proveedor != null)
            {


                //boton de cuentas abono

                var leyendaCuenta = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                        empresa && p.Cuenta.Trim() == proveedor.Cuenta_Abono_1.Trim()).FirstOrDefault();

                var leyendaCuenta2 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                     empresa && p.Cuenta.Trim() == proveedor.Cuenta_Abono_2.Trim()).FirstOrDefault();

                var leyendaCuenta3 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                     empresa && p.Cuenta.Trim() == proveedor.Cuenta_Abono_3.Trim()).FirstOrDefault();





                if (leyendaCuenta != null)
                {
                    btnAbono.Text = "Cuenta Abono: " + proveedor.Cuenta_Abono_1 + " -" + leyendaCuenta.Descripcion;

                }
                else
                {
                    Cuenta_Abono_1 = proveedor.Cuenta_Abono_1;

                    btnAbono.Text = "Cuenta Abono: " + Cuenta_Abono_1;

                }
                if (leyendaCuenta2 != null)
                {
                    buttonItem2.Text = "Cuenta Abono: " + proveedor.Cuenta_Abono_2 + " -" + leyendaCuenta2.Descripcion;

                }
                else
                {

                    Cuenta_Abono_2 = proveedor.Cuenta_Abono_2;

                    buttonItem2.Text = "Cuenta Abono: " + Cuenta_Abono_2;

                }
                if (leyendaCuenta3 != null)
                {
                    buttonItem3.Text = "Cuenta Abono: " + proveedor.Cuenta_Abono_3 + " -" + leyendaCuenta3.Descripcion;
                }
                else
                {

                    Cuenta_Abono_3 = proveedor.Cuenta_Abono_3;

                    buttonItem3.Text = "Cuenta Abono: " + Cuenta_Abono_3;
                }

                //boton de cuentas de cargo
                var leyendaCuenta4 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                 empresa && p.Cuenta.Trim() == proveedor.Cuenta_cargo_1.Trim()).FirstOrDefault();

                var leyendaCuenta5 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                     empresa && p.Cuenta.Trim() == proveedor.Cuenta_cargo_2.Trim()).FirstOrDefault();

                var leyendaCuenta6 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                     empresa && p.Cuenta.Trim() == proveedor.Cuenta_cargo_3.Trim()).FirstOrDefault();

                if (leyendaCuenta4 != null)
                {
                    buttonItem4.Text = "Cuenta Cargo: " + proveedor.Cuenta_cargo_1 + " -" + leyendaCuenta4.Descripcion;

                }
                else
                {
                    Cuenta_cargo_1 = proveedor.Cuenta_cargo_1;

                    buttonItem4.Text = "Cuenta Cargo: " + Cuenta_cargo_1;

                }
                if (leyendaCuenta5 != null)
                {
                    buttonItem5.Text = "Cuenta Cargo: " + proveedor.Cuenta_cargo_2 + " -" + leyendaCuenta5.Descripcion;

                }
                else
                {

                    Cuenta_cargo_2 = proveedor.Cuenta_cargo_2;

                    buttonItem5.Text = "Cuenta Cargo: " + Cuenta_cargo_2;

                }
                if (leyendaCuenta6 != null)
                {
                    buttonItem6.Text = "Cuenta Cargo: " + proveedor.Cuenta_cargo_3 + " -" + leyendaCuenta6.Descripcion;
                }
                else
                {

                    Cuenta_cargo_3 = proveedor.Cuenta_cargo_3;

                    buttonItem6.Text = "Cuenta Cargo: " + Cuenta_cargo_3;
                }





              

            }
            else
            {
                Cuenta_Abono_1 = "0000-000-000";
                Cuenta_Abono_2 = "0000-000-000";
                Cuenta_Abono_3 = "0000-000-000";
                btnAbono.Text = "Cuenta Abono: " + Cuenta_Abono_1;
                buttonItem2.Text = "Cuenta Abono: " + Cuenta_Abono_2;
                buttonItem3.Text = "Cuenta Abono: " + Cuenta_Abono_3;

                Cuenta_cargo_1 = "0000-000-000";
                Cuenta_cargo_2 = "0000-000-000";
                Cuenta_cargo_3 = "0000-000-000";
                buttonItem4.Text = "Cuenta Cargo: " + Cuenta_cargo_1;
                buttonItem5.Text = "Cuenta Cargo: " + Cuenta_cargo_2;
                buttonItem6.Text = "Cuenta Cargo: " + Cuenta_cargo_3;
            }


            try
            {
                if (poliza.Rows.Count > 0)
                {


                    foreach (DataGridViewRow item in poliza.Rows)
                    {

                        if (item.Cells[4].Value.ToString() == "TOTAL")
                        {
                            item.Cells[0].Value = proveedor.Cuenta_Abono_1;
                        }
                        if (item.Cells[4].Value.ToString() == "IVA TRASLADADO")
                        {
                            item.Cells[0].Value = proveedor.Cuenta_Cargo_Iva;


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
                            item.Cells[0].Value = proveedor.Isr_Trasladado;




                        }
                        if (item.Cells[4].Value.ToString() == "IEPS RETENIDO")
                        {
                            item.Cells[0].Value = proveedor.Ieps_Retenido;


                        }
                        if (item.Cells[4].Value.ToString() == "IEPS TRASLADADO")
                        {
                            item.Cells[0].Value = proveedor.Ieps_Trasladado;

                        }
                        if (item.Cells[4].Value.ToString() == "CONCEPTO")
                        {
                            item.Cells[0].Value = proveedor.Cuenta_cargo_1;

                        }



                    }


                    #region test

                    ////CARGA DE DATOS PARA LOS CARGOS
                    //if (proveedor != null)
                    //{


                    //    //boton de cuentas abono

                    //    var leyendaCuenta = db.CuentasGastos.Where(p => p.IdEmpresa ==
                    //                            empresa && p.Cuenta.Trim() == proveedor.Cuenta_Abono_1.Trim()).FirstOrDefault();

                    //    var leyendaCuenta2 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                    //                         empresa && p.Cuenta.Trim() == proveedor.Cuenta_Abono_2.Trim()).FirstOrDefault();

                    //    var leyendaCuenta3 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                    //                         empresa && p.Cuenta.Trim() == proveedor.Cuenta_Abono_3.Trim()).FirstOrDefault();





                    //    if (leyendaCuenta != null)
                    //    {
                    //        btnAbono.Text = "Cuenta Abono: " + proveedor.Cuenta_Abono_1 + " -" + leyendaCuenta.Descripcion;

                    //    }
                    //    else
                    //    {
                    //        Cuenta_Abono_1 = "0000-000-000";

                    //        btnAbono.Text = "Cuenta Abono: " + Cuenta_Abono_1;

                    //    }
                    //    if (leyendaCuenta2 != null)
                    //    {
                    //        buttonItem2.Text = "Cuenta Abono: " + proveedor.Cuenta_Abono_2 + " -" + leyendaCuenta2.Descripcion;

                    //    }
                    //    else
                    //    {

                    //        Cuenta_Abono_2 = "0000-000-000";

                    //        buttonItem2.Text = "Cuenta Abono: " + Cuenta_Abono_2;

                    //    }
                    //    if (leyendaCuenta3 != null)
                    //    {
                    //        buttonItem3.Text = "Cuenta Abono: " + proveedor.Cuenta_Abono_3 + " -" + leyendaCuenta3.Descripcion;
                    //    }
                    //    else
                    //    {

                    //        Cuenta_Abono_3 = "0000-000-000";

                    //        buttonItem3.Text = "Cuenta Abono: " + Cuenta_Abono_3;
                    //    }

                    //    //boton de cuentas de cargo
                    //    var leyendaCuenta4 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                    //                     empresa && p.Cuenta.Trim() == proveedor.Cuenta_cargo_1.Trim()).FirstOrDefault();

                    //    var leyendaCuenta5 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                    //                         empresa && p.Cuenta.Trim() == proveedor.Cuenta_cargo_2.Trim()).FirstOrDefault();

                    //    var leyendaCuenta6 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                    //                         empresa && p.Cuenta.Trim() == proveedor.Cuenta_cargo_3.Trim()).FirstOrDefault();

                    //    if (leyendaCuenta4 != null)
                    //    {
                    //        buttonItem4.Text = "Cuenta Cargo: " + proveedor.Cuenta_cargo_1 + " -" + leyendaCuenta4.Descripcion;

                    //    }
                    //    else
                    //    {
                    //        Cuenta_cargo_1 = "0000-000-000";

                    //        buttonItem4.Text = "Cuenta Cargo: " + Cuenta_cargo_1;

                    //    }
                    //    if (leyendaCuenta5 != null)
                    //    {
                    //        buttonItem5.Text = "Cuenta Cargo: " + proveedor.Cuenta_cargo_2 + " -" + leyendaCuenta5.Descripcion;

                    //    }
                    //    else
                    //    {

                    //        Cuenta_cargo_2 = "0000-000-000";

                    //        buttonItem5.Text = "Cuenta Cargo: " + Cuenta_cargo_2;

                    //    }
                    //    if (leyendaCuenta6 != null)
                    //    {
                    //        buttonItem6.Text = "Cuenta Cargo: " + proveedor.Cuenta_cargo_3 + " -" + leyendaCuenta6.Descripcion;
                    //    }
                    //    else
                    //    {

                    //        Cuenta_cargo_3 = "0000-000-000";

                    //        buttonItem6.Text = "Cuenta Cargo: " + Cuenta_cargo_3;
                    //    }







                    //}
                    //else
                    //{
                    //    Cuenta_Abono_1 = "0000-000-000";
                    //    Cuenta_Abono_2 = "0000-000-000";
                    //    Cuenta_Abono_3 = "0000-000-000";
                    //    btnAbono.Text = "Cuenta Abono: " + Cuenta_Abono_1;
                    //    buttonItem2.Text = "Cuenta Abono: " + Cuenta_Abono_2;
                    //    buttonItem3.Text = "Cuenta Abono: " + Cuenta_Abono_3;

                    //    Cuenta_cargo_1 = "0000-000-000";
                    //    Cuenta_cargo_2 = "0000-000-000";
                    //    Cuenta_cargo_3 = "0000-000-000";
                    //    buttonItem4.Text = "Cuenta Cargo: " + Cuenta_cargo_1;
                    //    buttonItem5.Text = "Cuenta Cargo: " + Cuenta_cargo_2;
                    //    buttonItem6.Text = "Cuenta Cargo: " + Cuenta_cargo_3;
                    //}



                    #endregion

                }
            }
            catch (Exception ex)
            {

            }
         
        }

        //Recargar Datos de cuentas
        public void CargarDatosCuentas(int empresa, int opc, string cuenta)
        {
            //boton de cuentas abono
           

            if (opc == 1)
            {
                btnAbono.Text = "Cuenta Abono: " + cuenta;
                Cuenta_Abono_1 = cuenta;

                var leyendaCuenta = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                        empresa && p.Cuenta.Trim() == cuenta.Trim()).FirstOrDefault();

                if (leyendaCuenta != null)
                {
                    btnAbono.Text = "Cuenta Abono: " + cuenta + " -" + leyendaCuenta.Descripcion;


                }
               
            }
            if (opc == 2)
            {

                buttonItem2.Text = "Cuenta Abono: " + cuenta;
                Cuenta_Abono_2 = cuenta;
                var leyendaCuenta2 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                    empresa && p.Cuenta.Trim() == cuenta.Trim()).FirstOrDefault();

                if (leyendaCuenta2 != null)
                {
                    buttonItem2.Text = "Cuenta Abono: " + cuenta + " -" + leyendaCuenta2.Descripcion;

                }
                
            }
            if (opc == 3)
            {
                buttonItem3.Text = "Cuenta Abono: " + cuenta;
                Cuenta_Abono_3 = cuenta;
                var leyendaCuenta3 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                    empresa && p.Cuenta.Trim() == cuenta.Trim()).FirstOrDefault();
                if (leyendaCuenta3 != null)
                {
                    buttonItem3.Text = "Cuenta Abono: " + cuenta + " -" + leyendaCuenta3.Descripcion;
                }

               
            }

           
           
           

        }

        public void CargarDatosCuentas2(int empresa, int opc, string cuenta)
        {
            //boton de cuentas de cargos


            if (opc == 1)
            {
               buttonItem4.Text = "Cuenta Cargo: " + cuenta;
               Cuenta_cargo_1 = cuenta;

                var leyendaCuenta = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                        empresa && p.Cuenta.Trim() == cuenta.Trim()).FirstOrDefault();

                if (leyendaCuenta != null)
                {
                    buttonItem4.Text = "Cuenta Cargo: " + cuenta + " -" + leyendaCuenta.Descripcion;


                }

            }
            if (opc == 2)
            {

                buttonItem5.Text = "Cuenta Cargo: " + cuenta;
                Cuenta_cargo_2 = cuenta;

                var leyendaCuenta2 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                    empresa && p.Cuenta.Trim() == cuenta.Trim()).FirstOrDefault();

                if (leyendaCuenta2 != null)
                {
                    buttonItem5.Text = "Cuenta Cargo: " + cuenta + " -" + leyendaCuenta2.Descripcion;

                }

            }
            if (opc == 3)
            {
                buttonItem6.Text = "Cuenta Cargo: " + cuenta;
                Cuenta_cargo_3 = cuenta;

                var leyendaCuenta3 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                    empresa && p.Cuenta.Trim() == cuenta.Trim()).FirstOrDefault();
                if (leyendaCuenta3 != null)
                {
                    buttonItem6.Text = "Cuenta Cargo: " + cuenta + " -" + leyendaCuenta3.Descripcion;
                }


            }





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
        //LECTURA DE FACTURA
        private void Lectura_de_factura()
        {
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

            Cuenta_isr_retenido = "0000-000-000";
            Cuenta_iva_retenido = "0000-000-000";
            Cuenta_isr_trasladado = "0000-000-000";
            Cuenta_ieps_trasladado = "0000-000-000";
            Cuenta_ieps_retenido = "0000-000-000";

            Titulo_principal = "Proveedor X";
            Titulo_secundario = "RFCXXX";
            Titulo_tercero = "SIN TITULO";
           // Departamento = "2";
            Departamento = txtDepto.Text.Trim();

         

            var proveedor = db.Proveedores.Where(p => p.RFC == RFC_proveedor && p.IdEmpresa==IdEmpresaEjercicio).FirstOrDefault();

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
                Cuenta_iva_retenido = proveedor.Iva_Retenido;
                Cuenta_Abono_1 = proveedor.Cuenta_Abono_1;
                Cuenta_Abono_2 = proveedor.Cuenta_Abono_2;
                Cuenta_Abono_3 = proveedor.Cuenta_Abono_3;

                Cuenta_isr_retenido = proveedor.Isr_Retenido;//cuenta isr retenido
                Cuenta_isr_trasladado = proveedor.Isr_Trasladado;

             

                Titulo_principal = proveedor.Titulo_principal;//el concepto del encabezado
                Titulo_secundario = proveedor.Titulo_secundario;//el concepto del total
                Titulo_tercero = proveedor.Titulo_tercero; //el concepto del iva

                //NUEVAS CUENTAS
                Cuenta_ieps_trasladado = proveedor.Ieps_Trasladado;
                Cuenta_ieps_retenido = proveedor.Ieps_Retenido;
               
               

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
                if (Cuenta_ieps_trasladado == "" || string.IsNullOrEmpty(Cuenta_ieps_trasladado))
                {
                    Cuenta_ieps_trasladado = "0000-000-000";
                }
                if (Cuenta_isr_trasladado == "" || string.IsNullOrEmpty(Cuenta_isr_trasladado))
                {
                    Cuenta_isr_trasladado = "0000-000-000";
                }
                if (Cuenta_iva_retenido == "" || string.IsNullOrEmpty(Cuenta_iva_retenido))
                {
                    Cuenta_iva_retenido = "0000-000-000";
                }
                if (Cuenta_ieps_retenido == "" || string.IsNullOrEmpty(Cuenta_ieps_retenido))
                {
                    Cuenta_ieps_retenido = "0000-000-000";
                }


             


            }
            //

            //boton de cuentas abono
            int empresa =int.Parse(cmbLocalidades.SelectedValue.ToString());
            var leyendaCuenta = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                    empresa && p.Cuenta.Trim() == Cuenta_Abono_1.Trim()).FirstOrDefault();

            var leyendaCuenta2 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                 empresa && p.Cuenta.Trim() == Cuenta_Abono_2.Trim()).FirstOrDefault();

            var leyendaCuenta3 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                 empresa && p.Cuenta.Trim() == Cuenta_Abono_3.Trim()).FirstOrDefault();


            var leyendaCuenta4 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                   empresa && p.Cuenta.Trim() == Cuenta_cargo_1.Trim()).FirstOrDefault();

            var leyendaCuenta5 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                 empresa && p.Cuenta.Trim() == Cuenta_cargo_2.Trim()).FirstOrDefault();

            var leyendaCuenta6 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                 empresa && p.Cuenta.Trim() == Cuenta_cargo_3.Trim()).FirstOrDefault();



            btnAbono.Text = "Cuenta Abono: " + Cuenta_Abono_1;
            buttonItem2.Text = "Cuenta Abono: " + Cuenta_Abono_2;
            buttonItem3.Text = "Cuenta Abono: " + Cuenta_Abono_3;

            buttonItem4.Text = "Cuenta Cargo: " + Cuenta_cargo_1;
            buttonItem5.Text = "Cuenta Cargo: " + Cuenta_cargo_2;
            buttonItem6.Text = "Cuenta Cargo: " + Cuenta_cargo_3;

            if (leyendaCuenta != null)
            {
                btnAbono.Text = "Cuenta Abono: " + Cuenta_Abono_1 + " -" + leyendaCuenta.Descripcion;
               
            }
            if (leyendaCuenta2 != null)
            {
                buttonItem2.Text = "Cuenta Abono: " + Cuenta_Abono_2 + " -" + leyendaCuenta2.Descripcion;
               
            }
            if (leyendaCuenta3 != null)
            {
                buttonItem3.Text = "Cuenta Abono: " + Cuenta_Abono_3 + " -" + leyendaCuenta3.Descripcion;
            }

            if (leyendaCuenta4 != null)
            {
                buttonItem4.Text = "Cuenta Cargo: " + Cuenta_cargo_1 + " - " + leyendaCuenta4.Descripcion;

            }
            if (leyendaCuenta5 != null)
            {
                buttonItem5.Text = "Cuenta Cargo: " + Cuenta_cargo_2 + " -" + leyendaCuenta5.Descripcion;

            }
            if (leyendaCuenta6 != null)
            {
                buttonItem6.Text = "Cuenta Cargo: " + Cuenta_cargo_3 + " -" + leyendaCuenta6.Descripcion;
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
            poliza.Rows.Insert(0, Cuenta_Abono_1, Titulo_secundario, "0.00", total, "TOTAL");

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
                catch (Exception ex)
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

                 
                    poliza.Rows.Insert(2, Cuenta_cargo_1, descripcion, subtotal, "0.00", "CONCEPTO");
                   

                   
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
                        try
                        {
                            TrasladosXML = string.Empty;
                            TrasladosXML = node.InnerXml;//antes dos firschild

                            xmlImpuestos.LoadXml(TrasladosXML);


                            iva_trasladado = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_cargo_Iva, "IVA-TRASLADADO", iva_trasladado, "0.00", "IVA TRASLADADO");
                            isr_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_isr_retenido, "ISR-RETENIDO", "0.00", isr_retenido, "ISR RETENIDO");
                            iva_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion[2]/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_iva_retenido, "IVA-RETENIDO", "0.00", iva_retenido, "IVA RETENIDO");


                        }
                        catch (Exception)
                        {

                        }





                    }

                }

                bool result2 = RFC_proveedor.Equals("GABL540419HA8");
                if (result2)
                {
                    foreach (XmlElement node in VarConceptos)
                    {
                        try
                        {
                            TrasladosXML = string.Empty;
                            TrasladosXML = node.InnerXml;//antes dos firschild

                            xmlImpuestos.LoadXml(TrasladosXML);


                            iva_trasladado = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_cargo_Iva, "IVA-TRASLADADO", iva_trasladado, "0.00", "IVA TRASLADADO");
                            isr_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_isr_retenido, "ISR-RETENIDO", "0.00", isr_retenido, "ISR RETENIDO");
                            iva_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion[2]/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_iva_retenido, "IVA-RETENIDO", "0.00", iva_retenido, "IVA RETENIDO");


                        }
                        catch (Exception)
                        {

                        }





                    }

                }

                bool result3 = RFC_proveedor.Equals("RUMM4612043H4");
                if (result3)
                {
                    foreach (XmlElement node in VarConceptos)
                    {
                        try
                        {
                            TrasladosXML = string.Empty;
                            TrasladosXML = node.InnerXml;//antes dos firschild

                            xmlImpuestos.LoadXml(TrasladosXML);


                            iva_trasladado = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_cargo_Iva, "IVA-TRASLADADO", iva_trasladado, "0.00", "IVA TRASLADADO");
                            isr_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_isr_retenido, "ISR-RETENIDO", "0.00", isr_retenido, "ISR RETENIDO");
                            iva_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion[2]/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_iva_retenido, "IVA-RETENIDO", "0.00", iva_retenido, "IVA RETENIDO");


                        }
                        catch (Exception)
                        {

                        }





                    }
                }

                bool result4 = RFC_proveedor.Equals("COTI4112249D3");
                if (result4)
                {
                    foreach (XmlElement node in VarConceptos)
                    {
                        try
                        {
                            TrasladosXML = string.Empty;
                            TrasladosXML = node.InnerXml;//antes dos firschild

                            xmlImpuestos.LoadXml(TrasladosXML);


                            iva_trasladado = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_cargo_Iva, "IVA-TRASLADADO", iva_trasladado, "0.00", "IVA TRASLADADO");
                            isr_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_isr_retenido, "ISR-RETENIDO", "0.00", isr_retenido, "ISR RETENIDO");
                            iva_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion[2]/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_iva_retenido, "IVA-RETENIDO", "0.00", iva_retenido, "IVA RETENIDO");


                        }
                        catch (Exception)
                        {

                        }





                    }
                }

                bool result5 = RFC_proveedor.Equals("SIAM480401GF4");
                if (result5)
                {
                    foreach (XmlElement node in VarConceptos)
                    {
                        try
                        {
                            TrasladosXML = string.Empty;
                            TrasladosXML = node.InnerXml;//antes dos firschild

                            xmlImpuestos.LoadXml(TrasladosXML);


                            iva_trasladado = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_cargo_Iva, "IVA-TRASLADADO", iva_trasladado, "0.00", "IVA TRASLADADO");
                            isr_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_isr_retenido, "ISR-RETENIDO", "0.00", isr_retenido, "ISR RETENIDO");
                            iva_retenido = xmlImpuestos.SelectSingleNode("/cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion[2]/@Importe", VarManager).InnerText;
                            poliza.Rows.Insert(1, Cuenta_iva_retenido, "IVA-RETENIDO", "0.00", iva_retenido, "IVA RETENIDO");


                        }
                        catch (Exception)
                        {

                        }





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

                 
                    poliza.Rows.Insert(1, Cuenta_cargo_1, descripcionxml, subtotal, "0.00", "CONCEPTO");
                   


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
                    poliza.Rows.Insert(1, Cuenta_isr_trasladado, leyenda_ISR, ISR, "0.00", "ISR TRASLADADO");
                }

                if (IEPS > 0)
                {



                    if (sumaSubtotalSumadoConIvaIEPS == TotalFactura)//significa que agrego el IEPS en la Factura
                    {
                        //AGREGO IEPS
                        poliza.Rows.Insert(1, Cuenta_ieps_trasladado, leyenda_IEPS, IEPS, "0.00", "IEPS TRASLADADO");
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


                    poliza.Rows.Insert(1, Cuenta_ieps_trasladado, leyenda_IEPS, diferenciaIEPS, "0.00", "IEPS TRASLADADO");
                }









            }





            ////LLeno las cuentas de poliza
            //foreach (DataGridViewRow item in poliza.Rows)
            //{

            //    if (item.Cells[4].Value.ToString() == "TOTAL")
            //    {
            //        item.Cells[0].Value = Cuenta_Abono_1;
            //    }
            //    if (item.Cells[4].Value.ToString() == "IVA TRASLADADO")
            //    {
            //        item.Cells[0].Value = Cuenta_cargo_Iva;



            //    }
            //    if (item.Cells[4].Value.ToString() == "IVA RETENIDO")
            //    {
            //        item.Cells[0].Value = Cuenta_iva_retenido;


            //    }
            //    if (item.Cells[4].Value.ToString() == "ISR RETENIDO")
            //    {
            //        item.Cells[0].Value = Cuenta_isr_retenido;

            //    }
            //    if (item.Cells[4].Value.ToString() == "ISR TRASLADADO")
            //    {
            //        item.Cells[0].Value = Cuenta_isr_trasladado;


            //    }
            //    if (item.Cells[4].Value.ToString() == "IEPS RETENIDO")
            //    {
            //        item.Cells[0].Value = Cuenta_ieps_retenido;


            //    }
            //    if (item.Cells[4].Value.ToString() == "IEPS TRASLADADO")
            //    {
            //        item.Cells[0].Value = Cuenta_ieps_trasladado;

            //    }
            //    if (item.Cells[4].Value.ToString() == "CONCEPTO")
            //    {
            //        item.Cells[0].Value = Cuenta_cargo_3;

            //    }



            //}





            float Debe = 0;
            float haber = 0;
            float valor1=0;
            float valor = 0;
            foreach (DataGridViewRow row in poliza.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    valor1 = float.Parse(row.Cells[2].Value.ToString());
                    Debe += valor1;
                }
               
            }
            
            foreach (DataGridViewRow row in poliza.Rows)
            {
               
                if (row.Cells[3].Value != null)
                {
                    valor = float.Parse(row.Cells[3].Value.ToString());
                    haber += valor;
                }
            }
            txtDebe.Text = Debe.ToString("N2");
            txtHaber.Text = haber.ToString("N2");


            //Actualizacion 17 enero 2019
            decimal diferencia;
            if (decimal.Parse(txtDebe.Text) > decimal.Parse(txtHaber.Text))
            {
                diferencia = decimal.Parse(txtDebe.Text) - decimal.Parse(txtHaber.Text);

                poliza.Rows.Insert(1, Cuenta_ieps_trasladado, "OTROS", "0.00", diferencia, "IEPS TRASLADADO");
                RECALCULAR();
            }
            else if (decimal.Parse(txtDebe.Text) < decimal.Parse(txtHaber.Text))
            {
                diferencia = decimal.Parse(txtHaber.Text) - decimal.Parse(txtDebe.Text);

                poliza.Rows.Insert(1, Cuenta_ieps_trasladado, "OTROS", diferencia, "0.00", "IEPS TRASLADADO");
                RECALCULAR();

            }




            #endregion
        }
        //AGREGAR NUEVA FILA
        private void agregarFila(int tipo)
         {
            if (tipo == 1)//cargo
            {
                int i = poliza.Rows.Count;
                //i = i;

                poliza.Rows.Insert(i, "0000-000-000", "INGRESE CARGO", 0.00, 0.00, "CONCEPTO");
                poliza.FirstDisplayedScrollingRowIndex = poliza.RowCount - 1;
                poliza.Rows[i].Selected = true;

            }
            else//Abono
            {

                int i = poliza.Rows.Count;
                //i = i;

                poliza.Rows.Insert(i, "0000-000-000", "INGRESE ABONO", 0.00, 0.00, "IEPS TRASLADADO");
                poliza.FirstDisplayedScrollingRowIndex = poliza.RowCount - 1;
                poliza.Rows[i].Selected = true;
            }

           
        }
        #endregion

        #region Events (Eventos)

        //LOAD
        private void PlantillaPrepolizaForm_Load(object sender, EventArgs e)
        {
            LoadF();
        }
        //PASAR A LA SIGUIENTE NOMINA
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


            if (decimal.Parse(txtDebe.Text) != decimal.Parse(txtHaber.Text))
            {

                MessageBoxEx.Show("Tu poliza no esta Cuadrada!",
                                                       "EKPolizaGastos",
                                                       MessageBoxButtons.OK,
                                                       MessageBoxIcon.Exclamation);
                return;
            }

            if (decimal.Parse(txtDebe.Text) == decimal.Parse(txtHaber.Text))
            {
               
                foreach (DataGridViewRow item in poliza.Rows)
                {
                    
                    if (item.Cells[0].Value==null)
                    {
                        MessageBoxEx.EnableGlass = false;
                        MessageBoxEx.Show("Tu poliza tiene cuentas en blanco, Verifica!",
                                                      "EKPolizaGastos",
                                                      MessageBoxButtons.OK,
                                                      MessageBoxIcon.Exclamation);
                        return;
                    }

                }
               
                
            }

            if (decimal.Parse(txtDebe.Text) == decimal.Parse(txtHaber.Text))
            {

                foreach (DataGridViewRow item in poliza.Rows)
                {

                    if (item.Cells[1].Value == null)
                    {
                      
                            MessageBoxEx.EnableGlass = false;
                            MessageBoxEx.Show("Tu poliza tiene conceptos en blanco, Verifica!",
                                                          "EKPolizaGastos",
                                                          MessageBoxButtons.OK,
                                                          MessageBoxIcon.Exclamation);
                            return;
                      

                    }


                }
            }

            if (decimal.Parse(txtDebe.Text) == decimal.Parse(txtHaber.Text))
            {
               
                foreach (DataGridViewRow item in poliza.Rows)
                {
                    if (item.Cells[2].Value == null)
                    {
                        
                        MessageBoxEx.EnableGlass = false;
                        MessageBoxEx.Show("Tu poliza tiene cargos en blanco, Verifica!",
                                                      "EKPolizaGastos",
                                                      MessageBoxButtons.OK,
                                                      MessageBoxIcon.Exclamation);
                        return;
                    }

                }


            }

            if (decimal.Parse(txtDebe.Text) == decimal.Parse(txtHaber.Text))
            {
               
                foreach (DataGridViewRow item in poliza.Rows)
                {
                    if (item.Cells[3].Value == null)
                    {
                        
                        MessageBoxEx.EnableGlass = false;
                        MessageBoxEx.Show("Tu poliza tiene abonos en blanco, Verifica!",
                                                      "EKPolizaGastos",
                                                      MessageBoxButtons.OK,
                                                      MessageBoxIcon.Exclamation);
                        return;
                    }

                }


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
                    if (primer_conccepto.Length >= 60)
                    {
                        primer_conccepto = primer_conccepto.Substring(0, 59);
                    }
                    escritor.WriteLine(primer_conccepto);
                    primer_conccepto = string.Empty;






                    //Ahora Creamos la Poliza
                    string comparar_cuenta = "";
                    int indice = 1;
                    string cuentaBase = "0000-000-000";
                    foreach (DataGridViewRow item in poliza.Rows)
                    {

                        if (item.Cells[4].Value.ToString() == "TOTAL")
                        {
                            tituloWrite = item.Cells[1].Value.ToString();
                            if (item.Cells[1].Value.ToString().Length >= 30)
                            {
                                tituloWrite = item.Cells[1].Value.ToString().Substring(0, 29);
                            }
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                           // tituloWrite = item.Cells[1].Value.ToString();
                            importeWrite = item.Cells[3].Value.ToString() + ",1.00";//haber

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine("");
                            escritor.WriteLine(importeWrite);
                            Titulo_principal = txtConcepto.Text;
                            Cuenta_Abono_1 = item.Cells[0].Value.ToString();
                        }
                        if (item.Cells[4].Value.ToString() == "IVA TRASLADADO")
                        {
                            tituloWrite = item.Cells[1].Value.ToString();
                            if (item.Cells[1].Value.ToString().Length >= 30)
                            {
                                tituloWrite = item.Cells[1].Value.ToString().Substring(0, 29);
                            }
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                           
                            importeWrite = item.Cells[2].Value.ToString() + ",1.00";

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine(importeWrite);
                            Cuenta_cargo_Iva = item.Cells[0].Value.ToString();
                        }
                        if (item.Cells[4].Value.ToString() == "IVA RETENIDO")
                        {
                            tituloWrite = item.Cells[1].Value.ToString();
                            if (item.Cells[1].Value.ToString().Length >= 30)
                            {
                                tituloWrite = item.Cells[1].Value.ToString().Substring(0, 29);
                            }
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                            //tituloWrite = item.Cells[1].Value.ToString();
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
                            tituloWrite = item.Cells[1].Value.ToString();
                            if (item.Cells[1].Value.ToString().Length >= 30)
                            {
                                tituloWrite = item.Cells[1].Value.ToString().Substring(0, 29);
                            }
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                           // tituloWrite = item.Cells[1].Value.ToString();
                            importeWrite = item.Cells[3].Value.ToString() + ",1.00";

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine("");
                            escritor.WriteLine(importeWrite);
                            Cuenta_isr_retenido = item.Cells[0].Value.ToString();
                        }
                        if (item.Cells[4].Value.ToString() == "ISR TRASLADADO")
                        {
                            tituloWrite = item.Cells[1].Value.ToString();
                            if (item.Cells[1].Value.ToString().Length >= 30)
                            {
                                tituloWrite = item.Cells[1].Value.ToString().Substring(0, 29);
                            }
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                           // tituloWrite = item.Cells[1].Value.ToString();
                            importeWrite = item.Cells[3].Value.ToString() + ",1.00";

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine(importeWrite);
                            Cuenta_isr_trasladado = item.Cells[0].Value.ToString();
                        }
                        if (item.Cells[4].Value.ToString() == "IEPS RETENIDO")
                        {
                            tituloWrite = item.Cells[1].Value.ToString();
                            if (item.Cells[1].Value.ToString().Length >= 30)
                            {
                                tituloWrite = item.Cells[1].Value.ToString().Substring(0, 29);
                            }
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                           // tituloWrite = item.Cells[1].Value.ToString();
                            importeWrite = item.Cells[2].Value.ToString() + ",1.00";

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine("");
                            escritor.WriteLine(importeWrite);
                           Cuenta_ieps_retenido = item.Cells[0].Value.ToString();
                        }
                        if (item.Cells[4].Value.ToString() == "IEPS TRASLADADO")
                        {
                            tituloWrite = item.Cells[1].Value.ToString();
                            if (item.Cells[1].Value.ToString().Length >= 30)
                            {
                                tituloWrite = item.Cells[1].Value.ToString().Substring(0, 29);
                            }
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                            //tituloWrite = item.Cells[1].Value.ToString();
                            importeWrite = item.Cells[2].Value.ToString() + ",1.00";

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine(importeWrite);
                           Cuenta_ieps_trasladado = item.Cells[0].Value.ToString();
                        }
                        if (item.Cells[4].Value.ToString() == "CONCEPTO")
                        {
                            tituloWrite = item.Cells[1].Value.ToString();
                            if (item.Cells[1].Value.ToString().Length >= 30)
                            {
                                tituloWrite = item.Cells[1].Value.ToString().Substring(0, 29);
                            }
                            cuentaWrite = item.Cells[0].Value.ToString() + "                ,  " + txtDepto.Text.Trim();
                            
                            
                            importeWrite = item.Cells[2].Value.ToString() + ",1.00";

                            escritor.WriteLine(cuentaWrite);
                            escritor.WriteLine(tituloWrite);
                            escritor.WriteLine(importeWrite);
                            
                            cuentaBase= item.Cells[0].Value.ToString();

                            if (indice == 1)
                            {
                                Cuenta_cargo_1 = cuentaBase;
                                comparar_cuenta = Cuenta_cargo_1;
                                indice += 1;
                            }
                            if (indice == 2)
                            {
                                //comparar
                                if (comparar_cuenta != cuentaBase && cuentaBase != Cuenta_cargo_1)
                                {
                                    Cuenta_cargo_2 = cuentaBase;
                                    comparar_cuenta = cuentaBase;
                                    indice += 1;
                                }

                            }
                            if (indice == 3)
                            {
                                //comparar
                                if (comparar_cuenta != cuentaBase && cuentaBase != Cuenta_cargo_1 && cuentaBase != Cuenta_cargo_2)
                                {
                                    Cuenta_cargo_3 = cuentaBase;
                                    indice += 1;
                                }

                            }
                           

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
                    IdLocalidad = 1,//IdLocalidad,
                    Cuenta_cargo_1 = Cuenta_cargo_1,//TOTAL
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
                    Isr_Trasladado=Cuenta_isr_trasladado,
                    Ieps_Retenido=Cuenta_ieps_retenido,
                    Ieps_Trasladado=Cuenta_ieps_trasladado,

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


            if (indexGridPosition + 1 < totalFacturas)//antes <=
            {
                indexGridPosition++;

                poliza.Rows.Clear();
                Lectura_de_factura();
               
            }
            else
            {
                MessageBoxEx.EnableGlass = false;
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

        //BUTTON TRASH SN FUNCION
        private void buttonX1_Click(object sender, EventArgs e)
        {
           
        }

        //ACTUALIZAR DATOS DE PROVEEDOR
        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (txtDepto.Text != "")
            {

                int empresa =int.Parse( cmbLocalidades.SelectedValue.ToString());
                var empresas = db.Empresas.Where(p => p.IdEmpresa == empresa).FirstOrDefault();

               
                var ExisteProovedor = db.Proveedores.Where(p => p.RFC == RFC_proveedor
                && p.IdEmpresa ==empresas.IdEmpresa).FirstOrDefault() ;

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
                    if (Cuenta_ieps_trasladado == "" || string.IsNullOrEmpty(Cuenta_ieps_trasladado))
                    {
                        Cuenta_ieps_trasladado = "0000-000-000";
                    }
                    if (Cuenta_isr_trasladado == "" || string.IsNullOrEmpty(Cuenta_isr_trasladado))
                    {
                        Cuenta_isr_trasladado = "0000-000-000";
                    }
                    if (Cuenta_iva_retenido == "" || string.IsNullOrEmpty(Cuenta_iva_retenido))
                    {
                        Cuenta_iva_retenido = "0000-000-000";
                    }
                    if (Cuenta_ieps_retenido == "" || string.IsNullOrEmpty(Cuenta_ieps_retenido))
                    {
                        Cuenta_ieps_retenido = "0000-000-000";
                    }


                    if (actualizarProveedor == DialogResult.Yes)
                    {
                       
                        foreach (DataGridViewRow item in poliza.Rows)
                        {

                            if (item.Cells[4].Value.ToString() == "TOTAL")
                            {
                              
                                Cuenta_Abono_1 = item.Cells[0].Value.ToString();
                            }
                            if (item.Cells[4].Value.ToString() == "IVA TRASLADADO")
                            {
                               
                                Cuenta_cargo_Iva = item.Cells[0].Value.ToString();
                            }
                            if (item.Cells[4].Value.ToString() == "IVA RETENIDO")
                            {
                               
                                Cuenta_iva_retenido = item.Cells[0].Value.ToString();
                            }
                            if (item.Cells[4].Value.ToString() == "ISR RETENIDO")
                            {
                             
                                Cuenta_isr_retenido = item.Cells[0].Value.ToString();
                            }
                            if (item.Cells[4].Value.ToString() == "ISR TRASLADADO")
                            {

                                //Cuenta_cargo_2 = item.Cells[0].Value.ToString();
                                Cuenta_isr_trasladado = item.Cells[0].Value.ToString();
                            }
                            if (item.Cells[4].Value.ToString() == "IEPS RETENIDO")
                            {

                                //Cuenta_Abono_1 = item.Cells[0].Value.ToString();
                                Cuenta_ieps_retenido = item.Cells[0].Value.ToString();
                            }
                            if (item.Cells[4].Value.ToString() == "IEPS TRASLADADO")//EN DESCRIPCIONPUEDE DECIR OTROS
                            {

                                //  Cuenta_Abono_2 = item.Cells[0].Value.ToString();
                                Cuenta_ieps_trasladado = item.Cells[0].Value.ToString();
                            }
                          



                        }

                        string comparar_cuenta = "";
                        int indice = 1;
                        string cuentaBase = "0000-000-000";
                        foreach (DataGridViewRow item in poliza.Rows)
                        {
                            if (item.Cells[4].Value.ToString() == "CONCEPTO")
                            {

                                cuentaBase = item.Cells[0].Value.ToString().Trim();



                                if (indice == 1)
                                {
                                    Cuenta_cargo_1 = cuentaBase;
                                    comparar_cuenta = Cuenta_cargo_1;
                                    indice += 1;
                                }
                                if (indice == 2)
                                {
                                    //comparar
                                    if (comparar_cuenta != cuentaBase && cuentaBase != Cuenta_cargo_1)
                                    {
                                        Cuenta_cargo_2 = cuentaBase;
                                        comparar_cuenta = cuentaBase;
                                        indice += 1;
                                    }
                                   
                                }
                                if (indice == 3)
                                {
                                    //comparar
                                    if (comparar_cuenta != cuentaBase && cuentaBase != Cuenta_cargo_1 && cuentaBase != Cuenta_cargo_2)
                                    {
                                        Cuenta_cargo_3 = cuentaBase;
                                        indice += 1;
                                    }

                                }
                               
                            }
                        }

                        if (Cuenta_cargo_1 == "0000-000-000")
                        {
                            Cuenta_cargo_1 = ExisteProovedor.Cuenta_cargo_1;
                        }
                        if (Cuenta_cargo_2 == "0000-000-000")
                        {
                            Cuenta_cargo_2 = ExisteProovedor.Cuenta_cargo_2;
                        }
                        if (Cuenta_cargo_3 == "0000-000-000")
                        {
                            Cuenta_cargo_3 = ExisteProovedor.Cuenta_cargo_3;
                        }

                        if (Cuenta_cargo_Iva == "0000-000-000")
                        {
                            Cuenta_cargo_Iva = ExisteProovedor.Cuenta_Cargo_Iva;
                        }


                        if (Cuenta_Abono_1 == "0000-000-000")
                        {
                            Cuenta_Abono_1 = ExisteProovedor.Cuenta_Abono_1;
                        }
                        if (Cuenta_Abono_2 == "0000-000-000")
                        {
                            Cuenta_Abono_2 = ExisteProovedor.Cuenta_Abono_2;
                        }
                        if (Cuenta_Abono_3 == "0000-000-000")
                        {
                            Cuenta_Abono_3 = ExisteProovedor.Cuenta_Abono_3;
                        }


                        if (Cuenta_isr_retenido == "0000-000-000")
                        {
                            Cuenta_isr_retenido = ExisteProovedor.Isr_Retenido;
                        }
                        if (Cuenta_isr_trasladado == "0000-000-000")
                        {
                            Cuenta_isr_trasladado = ExisteProovedor.Isr_Trasladado;
                        }


                        if (Cuenta_iva_retenido == "0000-000-000")
                        {
                            Cuenta_iva_retenido = ExisteProovedor.Iva_Retenido;
                        }
                        if (Cuenta_ieps_trasladado == "0000-000-000")
                        {
                            Cuenta_ieps_trasladado = ExisteProovedor.Ieps_Trasladado;
                        }
                        if (Cuenta_ieps_retenido == "0000-000-000")
                        {
                            Cuenta_ieps_retenido = ExisteProovedor.Ieps_Retenido;
                        }





                      
                       
                       
                        
                      

                        var listaProveedores = db.Proveedores.Where(C => C.RFC == RFC_proveedor && C.IdEmpresa==empresa).ToList();
                        Proveedores proveedoresM = new Proveedores();
                        foreach (var item in listaProveedores)
                        {
                            //proveedoresM = ExisteProovedor;

                            item.Proveedor = Proveedor_Completo;
                            item.RFC = RFC_proveedor;
                            item.NoProveedor = item.IdProveedor.ToString();
                            item.IdEmpresa = empresas.IdEmpresa;
                            item.Departamento = txtDepto.Text;
                            item.IdLocalidad = 1;

                            item.Cuenta_cargo_1 = Cuenta_cargo_1;
                            item.Cuenta_cargo_2 = Cuenta_cargo_2;
                            item.Cuenta_cargo_3 = Cuenta_cargo_3;
                            item.Cuenta_Cargo_Iva = Cuenta_cargo_Iva;

                            item.Cuenta_Abono_1 = Cuenta_Abono_1;
                            item.Cuenta_Abono_2 = Cuenta_Abono_2;
                            item.Cuenta_Abono_3 = Cuenta_Abono_3;


                            item.Isr_Retenido = Cuenta_isr_retenido;
                            item.Isr_Trasladado = Cuenta_isr_trasladado;
                            item.Iva_Retenido = Cuenta_iva_retenido;
                            item.Ieps_Trasladado = Cuenta_ieps_trasladado;
                            item.Ieps_Retenido = Cuenta_ieps_retenido;

                            item.Titulo_principal = Titulo_principal;
                            item.Titulo_secundario = Titulo_secundario;
                            item.Titulo_tercero = Titulo_tercero;

                          

                            //MODIFICAR SOLO UNA ENTIDAD CON  ENTY FRAMEWORK

                            db.Proveedores.Attach(item);

                            db.Entry(item).State =
                                EntityState.Modified;
                            db.SaveChanges();
                            //ACTUALIZAR VARIAS ENTIDADES CON ENTITY FRAMEWORK
                            //db.SaveChanges();
                            CargarEmpresadatos();
                        }

                       
                       






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
        //RECALCULA AL CAMBIAR VALOR DE CELDA
        private void poliza_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RECALCULAR();
        }
        //RECALCULA AL CAMBIAR VALOR DE CELDA
        private void poliza_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RECALCULAR();

        }
        //AGREGAR FILA NUEVA
        private void buttonX4_Click(object sender, EventArgs e)
        {
           // agregarFila();
        }

        //ACTUALIZAR CON CUENTA ABONO 1
        private void btnAbono_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in poliza.Rows)
            {

                if (item.Cells[4].Value.ToString() == "TOTAL")
                {
                    item.Cells[0].Value = Cuenta_Abono_1;
                }
            }


        }
        //ACTUALIZAR CON CUENTA ABONO 2
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in poliza.Rows)
            {

                if (item.Cells[4].Value.ToString() == "TOTAL")
                {
                    item.Cells[0].Value = Cuenta_Abono_2;
                }
            }
        }
        //ACTUALIZAR CON CUENTA ABONO 3
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in poliza.Rows)
            {

                if (item.Cells[4].Value.ToString() == "TOTAL")
                {
                    item.Cells[0].Value = Cuenta_Abono_3;
                }
            }

        }



        //Actualizar cuentas de Abono para este proveedor

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            int empresa = int.Parse(cmbLocalidades.SelectedValue.ToString());


            CuentasForm cuentas = new CuentasForm();
            cuentas.RfcDeProveedor = RFC_proveedor;
            cuentas.idEmpresa = Convert.ToString(empresa).ToString();
            cuentas.CuentaCapturada = poliza.Rows[0].Cells[0].Value.ToString();
            PlantillaPrepolizaForm actual = new PlantillaPrepolizaForm();
            actual = this;
            cuentas.plantilla = actual;
            cuentas.Show();
        }



        //ACTUALIZAR CON CUENTA CARGO 1
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            try
            {
                poliza.Rows[Fila_actualizar_cargo].Cells[0].Value = Cuenta_cargo_1;

            }
            catch (Exception ex)
            {

            }


        }

        //ACTUALIZAR CON CUENTA CARGO 2
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            try
            {
                poliza.Rows[Fila_actualizar_cargo].Cells[0].Value = Cuenta_cargo_2;

            }
            catch (Exception ex)
            {

            }
        }

        //ACTUALIZAR CON CUENTA CARGO 3
        private void buttonItem6_Click(object sender, EventArgs e)
        {
            try
            {
                poliza.Rows[Fila_actualizar_cargo].Cells[0].Value = Cuenta_cargo_3;

            }
            catch (Exception ex)
            {

            }
        }


        //Actualizar las cuentas de Cargos
        private void buttonItem7_Click(object sender, EventArgs e)
        {
            int empresa = int.Parse(cmbLocalidades.SelectedValue.ToString());


            CargosForm cuentas = new CargosForm();
            cuentas.RfcDeProveedor = RFC_proveedor;
            cuentas.idEmpresa = Convert.ToString(empresa).ToString();
            //CargosForm.CuentaCapturada = poliza.Rows[0].Cells[0].Value.ToString();
            PlantillaPrepolizaForm actual = new PlantillaPrepolizaForm();
            actual = this;
            cuentas.plantilla = actual;
            cuentas.Show();
        }


        //ACCEDE AL DICCIONARIO DEL CATALGO DE CUENTAS

        private void buttonX7_Click(object sender, EventArgs e)
        {
            CatalogoDeCuentasForm catalogoDeCuentasForm = new CatalogoDeCuentasForm();
            catalogoDeCuentasForm.Show();
        }
        //para seleccionar la fila para actualizar el cargo
        private void poliza_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Fila_actualizar_cargo = poliza.CurrentCell.RowIndex;//e.-columnindex para saber que columna seleccione
            }
            catch (Exception ex)
            {

            }

        }

        private void poliza_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Fila_actualizar_cargo = poliza.CurrentCell.RowIndex;//e.-columnindex para saber que columna seleccione
            }
            catch (Exception ex)
            {

            }
        }
        //CARGO
        private void buttonItem8_Click(object sender, EventArgs e)
        {
            agregarFila(1);
        }
        //ABONO
        private void buttonItem9_Click(object sender, EventArgs e)
        {
            agregarFila(2);
        }



        #endregion
    }
}
