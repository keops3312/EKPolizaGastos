using DevComponents.DotNetBar;
using EKPolizaGastos.Common.Classes;
using EKPolizaGastos.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EKPolizaGastos.Forms
{


    public partial class PolizaSatForm : DevComponents.DotNetBar.Office2007Form
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
        ReadSatFactura2 readSATFactura2;
        #endregion

        #region Attributes
        //pra la tabla general
        public string bases;
        public string tipoDeComprobante;
        public string tipoDeBase;

        public string ejercicio;
        public string cnx;
        int indexGrid;
        int indexGridPosition = 0;
        int totalFacturas = 0;
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

        public PolizaSatForm()
        {
            InitializeComponent();

            db = new SEMP_SATContext();
            readSATFactura = new ReadSATFactura();
            localidad = new DataTable();
            empresas = new DataTable();
            superTooltip = new SuperTooltipInfo();
            readSATFactura2 = new ReadSatFactura2();
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
            String[] month = new string[2];
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

            superTooltip1.SetSuperTooltip(btnClose, new DevComponents.DotNetBar.SuperTooltipInfo("EKPolizaGastos",
         "<strong>Salir de Generar Poliza!</strong>", ""
    , null, ((System.Drawing.Image)(EKPolizaGastos.Properties.Resources.iconToolTip_fw)),
         DevComponents.DotNetBar.eTooltipColor.Gray));

            superTooltip1.SetSuperTooltip(btnAnterior, new DevComponents.DotNetBar.SuperTooltipInfo("EKPolizaGastos",
        "<strong>Leer Poliza Anterior!</strong>", ""
   , null, ((System.Drawing.Image)(EKPolizaGastos.Properties.Resources.iconToolTip_fw)),
        DevComponents.DotNetBar.eTooltipColor.Magenta));
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

            IdEmpresaEjercicio = datos.IdEmpresa;


            //armado para llamar a la clase
            int ano= int.Parse(ejercicio.Substring(7, 4));
            int mes = readSATFactura2.SearchMonthD(ejercicio.Substring(4, 3));

            if (tipoDeBase.Equals("Recibidas"))
            {
                bases = ejercicio.Substring(0, 3) + "FACTRECIBIDAS";

              
            }
            else if (tipoDeBase.Equals("Emitidas"))
            {
                bases = ejercicio.Substring(0, 3) + "FACTSEMITIDAS";

               
            }

            dataGridViewX1.DataSource = readSATFactura2.listExercise(cnx, ano, mes, 2, bases);
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
            DataTable facturas = new DataTable("Facturas");
            int ano = int.Parse(ejercicio.Substring(7, 4));
            int mes = readSATFactura2.SearchMonthD(ejercicio.Substring(4, 3));
          

            
            facturas = readSATFactura2.listExercise(cnx, ano, mes, 2, bases);

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
           

            Proveedor = dataGridViewX1.Rows[indexGridPosition].Cells[21].Value.ToString();//RFC
            Proveedor_Completo = dataGridViewX1.Rows[indexGridPosition].Cells[21].Value.ToString();//NOMBRE PROVEEDOR
            RFC_proveedor = dataGridViewX1.Rows[indexGridPosition].Cells[20].Value.ToString();
            IdF = dataGridViewX1.Rows[indexGridPosition].Cells[0].Value.ToString();
            UUID = dataGridViewX1.Rows[indexGridPosition].Cells[17].Value.ToString();//UUID
            Folio = dataGridViewX1.Rows[indexGridPosition].Cells[16].Value.ToString();//FOLIOF

            txtNumero.Text = dataGridViewX1.Rows[indexGridPosition].Cells[67].Value.ToString();//NUMERO ID FACTURA antes 0

            tipoDeComprobante = string.Empty;

            tipoDeComprobante = dataGridViewX1.Rows[indexGridPosition].Cells[7].Value.ToString();//TIPO DE COMPROBANTE
            labelX2.Text = "Tipo de Comprobante: " + tipoDeComprobante;


            if(tipoDeComprobante.Trim().Equals("E")
                || tipoDeComprobante.Trim().Equals("I"))
            {
               
            }
            else
            {
                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("No identifico letra de poliza\n" +
                    "UUID :" + UUID,
                                                  "EKPolizaGastos",
                                                  MessageBoxButtons.OK,
                                                  MessageBoxIcon.Warning);

                if (indexGridPosition + 1 < totalFacturas)//antes <=
                {
                 
                    indexGridPosition++;


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




            poliza.Rows.Clear();


            if (tipoDeBase.Equals("Recibidas"))
            {

                file = @"" + path + "/" + ejercicio + "/" + UUID + ".xml";

            }
            else if (tipoDeBase.Equals("Emitidas"))
            {
                file = @"" + path + "/" + ejercicio.Substring(0, 3) + "_EMI_" + ejercicio.Substring(4, 7) + "/" + UUID + ".xml";
             



            }


           

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



            var proveedor = db.Proveedores.Where(p => p.RFC == RFC_proveedor.Trim() && p.IdEmpresa == IdEmpresaEjercicio).FirstOrDefault();

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
                //Titulo_principal = proveedor.Titulo_principal;//el concepto del encabezado
                //Titulo_secundario = proveedor.Titulo_secundario;//el concepto del total
                //Titulo_tercero = proveedor.Titulo_tercero; //el concepto del iva
                //tomamos la primera creacion de proveedores

                Titulo_principal = Proveedor + " " + RFC_proveedor; //proveedor a 40 caracteres + RFc

                Titulo_secundario = Proveedor;

                Titulo_tercero = "IVA-" + Proveedor + "-" + Folio; //proveedor a 25 caracteres + RFc

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
            int empresa = int.Parse(cmbLocalidades.SelectedValue.ToString());
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
            txtFecha.Text = Convert.ToDateTime(dataGridViewX1.Rows[indexGridPosition].Cells[9].Value.ToString()).ToString("dd/MM/yyyy");// Convert.ToDateTime().ToString("dd/MM/yyyy");
            //Departamento
            Departamento = txtDepto.Text;

          
            string subtotal;       
            string isr_retenido;
            string iva_retenido;
            string ieps;
            //ISH
            string ish;
            //TOTALLOCALTRASLADADO
            string totalLocalTrasladado;
            //TOTALLOCALRETENIDO
            string totalLocalRetenido;

            string leyenda_IVA = "IVA-" + Proveedor + "-" + Folio; ;//.Substring(0, 20)
            string leyenda_IEPS = "IEPS-" + Proveedor + "-" + Folio;
            string leyenda_ISR = "ISR-" + Proveedor + "-" + Folio;

            if (tipoDeBase.Equals("Recibidas"))
            {
                if (tipoDeComprobante.Trim() == "I")
                {
                    //El total de la poliza
                    total = dataGridViewX1.Rows[indexGridPosition].Cells[36].Value.ToString();
                    poliza.Rows.Insert(0, Cuenta_Abono_1, Titulo_secundario, "0.00", decimal.Parse(total).ToString("N2"), "TOTAL");
                }
                else if (tipoDeComprobante.Trim() == "E")
                {
                    //El total de la poliza
                    total = dataGridViewX1.Rows[indexGridPosition].Cells[36].Value.ToString();
                    poliza.Rows.Insert(0, Cuenta_Abono_1, Titulo_secundario, decimal.Parse(total).ToString("N2"), "0.00", "TOTAL");
                }
               
                //El Subtotal de la Poliza Subtotal(subtotal - descuento)

                string descuento = dataGridViewX1.Rows[indexGridPosition].Cells[30].Value.ToString();
                string miSubtotal = dataGridViewX1.Rows[indexGridPosition].Cells[29].Value.ToString();
                subtotal = Convert.ToString(decimal.Parse(miSubtotal) - decimal.Parse(descuento));

                if (tipoDeComprobante.Trim() == "I")
                {
                    poliza.Rows.Insert(1, Cuenta_cargo_1, Titulo_secundario, decimal.Parse(subtotal).ToString("N2"), "0.00", "CONCEPTO");
                }
                else if (tipoDeComprobante.Trim() == "E")
                {
                    poliza.Rows.Insert(1, Cuenta_cargo_1, Titulo_secundario, "0.00", decimal.Parse(subtotal).ToString("N2"), "CONCEPTO");
                }

                //ISR RETENIDO
                isr_retenido = dataGridViewX1.Rows[indexGridPosition].Cells[34].Value.ToString();
                if (tipoDeComprobante.Trim() == "I")
                {
                    if (!isr_retenido.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_isr_retenido, "ISR-RETENIDO", "0.00", decimal.Parse(isr_retenido).ToString("N2"), "ISR RETENIDO");
                    }
                }
                else if (tipoDeComprobante.Trim() == "E")
                {
                    if (!isr_retenido.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_isr_retenido, "ISR-RETENIDO", decimal.Parse(isr_retenido).ToString("N2"), "0.00", "ISR RETENIDO");
                    }

                }

                //IVA RETENIDO
                iva_retenido = dataGridViewX1.Rows[indexGridPosition].Cells[33].Value.ToString();
                if (tipoDeComprobante.Trim() == "I")
                {
                    if (!iva_retenido.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_iva_retenido, "IVA-RETENIDO", "0.00", decimal.Parse(iva_retenido).ToString("N2"), "IVA RETENIDO");
                    }
                }
                else if (tipoDeComprobante.Trim() == "E")
                {
                    if (!iva_retenido.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_iva_retenido, "IVA-RETENIDO", decimal.Parse(iva_retenido).ToString("N2"), "0.00", "IVA RETENIDO");
                    }
                }

                ieps = dataGridViewX1.Rows[indexGridPosition].Cells[31].Value.ToString();
                if (tipoDeComprobante.Trim() == "I")
                {
                    if (!ieps.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_ieps_trasladado, leyenda_IEPS, decimal.Parse(ieps).ToString("N2"), "0.00", "IEPS TRASLADADO");
                    }

                }
                else if (tipoDeComprobante.Trim() == "E")
                {
                    if (!ieps.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_ieps_trasladado, leyenda_IEPS, "0.00", decimal.Parse(ieps).ToString("N2"), "IEPS TRASLADADO");
                    }
                }

                //ISH(IEPS TRASLADADO)
                ish = dataGridViewX1.Rows[indexGridPosition].Cells[35].Value.ToString();
                if (tipoDeComprobante.Trim() == "I")
                {
                    if (!ish.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_ieps_trasladado, "ISH", decimal.Parse(ish).ToString("N2"), "0.00", "IEPS TRASLADADO");
                    }

                }
                else if (tipoDeComprobante.Trim() == "E")
                {
                    if (!ish.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_ieps_trasladado, "ISH", "0.00", decimal.Parse(ish).ToString("N2"), "IEPS TRASLADADO");
                    }
                }

                //TOTALLOCALTRASLADADO(IEPS TRASLADADO)
                totalLocalTrasladado = dataGridViewX1.Rows[indexGridPosition].Cells[40].Value.ToString();
                if (tipoDeComprobante.Trim() == "I")
                {
                    if (!totalLocalTrasladado.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_ieps_trasladado, "TLOCAL-TRASLADADO", decimal.Parse(totalLocalTrasladado).ToString("N2"), "0.00", "IEPS TRASLADADO");
                    }
                }
                else if (tipoDeComprobante.Trim() == "E")
                {
                    if (!totalLocalTrasladado.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_ieps_trasladado, "TLOCAL-TRASLADADO", "0.00", decimal.Parse(totalLocalTrasladado).ToString("N2"), "IEPS TRASLADADO");
                    }
                }

                //TOTALLOCALRETENIDO(IEPS TRASLADADO) 
                totalLocalRetenido = dataGridViewX1.Rows[indexGridPosition].Cells[41].Value.ToString();
                if (tipoDeComprobante.Trim() == "I")
                {
                    if (!totalLocalRetenido.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_iva_retenido, "TLOCAL-RETENIDO", "0.00", decimal.Parse(totalLocalRetenido).ToString("N2"), "IVA RETENIDO");
                    }
                }
                else if (tipoDeComprobante.Trim() == "E")
                {
                    if (!totalLocalRetenido.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_iva_retenido, "TLOCAL-RETENIDO", decimal.Parse(totalLocalRetenido).ToString("N2"), "0.00", "IVA RETENIDO");
                    }

                }

                //El total de Iva de la poliza
                iva = dataGridViewX1.Rows[indexGridPosition].Cells[32].Value.ToString();
                if (tipoDeComprobante.Trim() == "I")
                {
                    if (!iva.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_cargo_Iva, Titulo_tercero, decimal.Parse(iva).ToString("N2"), "0.00", "IVA TRASLADADO");
                    }


                }
                else if (tipoDeComprobante.Trim() == "E")
                {
                    if (!iva.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_cargo_Iva, Titulo_tercero, "0.00", decimal.Parse(iva).ToString("N2"), "IVA TRASLADADO");
                    }

                }

            }
            else if(tipoDeBase.Equals("Emitidas"))
            {
                if (tipoDeComprobante.Trim() == "E")
                {
                    //El total de la poliza
                    total = dataGridViewX1.Rows[indexGridPosition].Cells[36].Value.ToString();
                    poliza.Rows.Insert(0, Cuenta_Abono_1, Titulo_secundario, "0.00", decimal.Parse(total).ToString("N2"), "TOTAL");
                }
                else if (tipoDeComprobante.Trim() == "I")
                {
                    //El total de la poliza
                    total = dataGridViewX1.Rows[indexGridPosition].Cells[36].Value.ToString();
                    poliza.Rows.Insert(0, Cuenta_Abono_1, Titulo_secundario, decimal.Parse(total).ToString("N2"), "0.00", "TOTAL");
                }
              


                //El Subtotal de la Poliza Subtotal(subtotal - descuento)

                string descuento = dataGridViewX1.Rows[indexGridPosition].Cells[30].Value.ToString();
                string miSubtotal = dataGridViewX1.Rows[indexGridPosition].Cells[29].Value.ToString();
                subtotal = Convert.ToString(decimal.Parse(miSubtotal) - decimal.Parse(descuento));

                if (tipoDeComprobante.Trim() == "E")
                {
                    poliza.Rows.Insert(1, Cuenta_cargo_1,Titulo_secundario, decimal.Parse(subtotal).ToString("N2"), "0.00", "CONCEPTO");
                }
                else if (tipoDeComprobante.Trim() == "I")
                {
                    poliza.Rows.Insert(1, Cuenta_cargo_1, Titulo_secundario, "0.00", decimal.Parse(subtotal).ToString("N2"), "CONCEPTO");
                }

                //ISR RETENIDO
                isr_retenido = dataGridViewX1.Rows[indexGridPosition].Cells[34].Value.ToString();
                if (tipoDeComprobante.Trim() == "E")
                {
                    if (!isr_retenido.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_isr_retenido, "ISR-RETENIDO", "0.00", decimal.Parse(isr_retenido).ToString("N2"), "ISR RETENIDO");
                    }
                }
                else if (tipoDeComprobante.Trim() == "I")
                {
                    if (!isr_retenido.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_isr_retenido, "ISR-RETENIDO", decimal.Parse(isr_retenido).ToString("N2"), "0.00", "ISR RETENIDO");
                    }

                }

                //IVA RETENIDO
                iva_retenido = dataGridViewX1.Rows[indexGridPosition].Cells[33].Value.ToString();
                if (tipoDeComprobante.Trim() == "E")
                {
                    if (!iva_retenido.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_iva_retenido, "IVA-RETENIDO", "0.00", decimal.Parse(iva_retenido).ToString("N2"), "IVA RETENIDO");
                    }
                }
                else if (tipoDeComprobante.Trim() == "I")
                {
                    if (!iva_retenido.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_iva_retenido, "IVA-RETENIDO", decimal.Parse(iva_retenido).ToString("N2"), "0.00", "IVA RETENIDO");
                    }
                }

                ieps = dataGridViewX1.Rows[indexGridPosition].Cells[31].Value.ToString();
                if (tipoDeComprobante.Trim() == "E")
                {
                    if (!ieps.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_ieps_trasladado, leyenda_IEPS, decimal.Parse(ieps).ToString("N2"), "0.00", "IEPS TRASLADADO");
                    }

                }
                else if (tipoDeComprobante.Trim() == "I")
                {
                    if (!ieps.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_ieps_trasladado, leyenda_IEPS, "0.00", decimal.Parse(ieps).ToString("N2"), "IEPS TRASLADADO");
                    }
                }

                //ISH(IEPS TRASLADADO)
                ish = dataGridViewX1.Rows[indexGridPosition].Cells[35].Value.ToString();
                if (tipoDeComprobante.Trim() == "E")
                {
                    if (!ish.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_ieps_trasladado, "ISH", decimal.Parse(ish).ToString("N2"), "0.00", "IEPS TRASLADADO");
                    }

                }
                else if (tipoDeComprobante.Trim() == "I")
                {
                    if (!ish.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_ieps_trasladado, "ISH", "0.00", decimal.Parse(ish).ToString("N2"), "IEPS TRASLADADO");
                    }
                }

                //TOTALLOCALTRASLADADO(IEPS TRASLADADO)
                totalLocalTrasladado = dataGridViewX1.Rows[indexGridPosition].Cells[40].Value.ToString();
                if (tipoDeComprobante.Trim() == "E")
                {
                    if (!totalLocalTrasladado.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_ieps_trasladado, "TLOCAL-TRASLADADO", decimal.Parse(totalLocalTrasladado).ToString("N2"), "0.00", "IEPS TRASLADADO");
                    }
                }
                else if (tipoDeComprobante.Trim() == "I")
                {
                    if (!totalLocalTrasladado.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_ieps_trasladado, "TLOCAL-TRASLADADO", "0.00", decimal.Parse(totalLocalTrasladado).ToString("N2"), "IEPS TRASLADADO");
                    }
                }

                //TOTALLOCALRETENIDO(IEPS TRASLADADO) 
                totalLocalRetenido = dataGridViewX1.Rows[indexGridPosition].Cells[41].Value.ToString();
                if (tipoDeComprobante.Trim() == "E")
                {
                    if (!totalLocalRetenido.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_iva_retenido, "TLOCAL-RETENIDO", "0.00", decimal.Parse(totalLocalRetenido).ToString("N2"), "IVA RETENIDO");
                    }
                }
                else if (tipoDeComprobante.Trim() == "I")
                {
                    if (!totalLocalRetenido.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_iva_retenido, "TLOCAL-RETENIDO", decimal.Parse(totalLocalRetenido).ToString("N2"), "0.00", "IVA RETENIDO");
                    }

                }

                //El total de Iva de la poliza
                iva = dataGridViewX1.Rows[indexGridPosition].Cells[32].Value.ToString();
                if (tipoDeComprobante.Trim() == "E")
                {
                    if (!iva.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_cargo_Iva, Titulo_tercero, decimal.Parse(iva).ToString("N2"), "0.00", "IVA TRASLADADO");
                    }


                }
                else if (tipoDeComprobante.Trim() == "I")
                {
                    if (!iva.Equals("0"))
                    {
                        poliza.Rows.Insert(2, Cuenta_cargo_Iva, Titulo_tercero, "0.00", decimal.Parse(iva).ToString("N2"), "IVA TRASLADADO");
                    }

                }

            }





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


            //Actualizacion 17 enero 2019

            decimal diferencia;
            if (decimal.Parse(txtDebe.Text) > decimal.Parse(txtHaber.Text))
            {
                diferencia = decimal.Parse(txtDebe.Text) - decimal.Parse(txtHaber.Text);

                poliza.Rows.Insert(1, Cuenta_ieps_trasladado, "OTROS", "0.00", diferencia.ToString("N2"), "IEPS TRASLADADO");
                RECALCULAR();
            }
            else if (decimal.Parse(txtDebe.Text) < decimal.Parse(txtHaber.Text))
            {
                diferencia = decimal.Parse(txtHaber.Text) - decimal.Parse(txtDebe.Text);

                poliza.Rows.Insert(1, Cuenta_ieps_trasladado, "OTROS", diferencia.ToString("N2"), "0.00", "IEPS TRASLADADO");
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

        private void PolizaSatForm_Load(object sender, EventArgs e)
        {
            LoadF();
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
            PolizaSatForm actual = new PolizaSatForm();
            actual = this;
            cuentas.polizaSatForm = actual;
            cuentas.opcion = 1;
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
            PolizaSatForm actual = new PolizaSatForm();
            actual = this;
            cuentas.polizaSatForm = actual;
            cuentas.opcion = 1;
            cuentas.Show();
        }

        //ACCEDE AL DICCIONARIO DEL CATALGO DE CUENTAS

        private void buttonX7_Click(object sender, EventArgs e)
        {
            CatalogoDeCuentasForm catalogoDeCuentasForm = new CatalogoDeCuentasForm();
            catalogoDeCuentasForm.Show();
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

                    if (item.Cells[0].Value == null)
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
                string directorio_a_localizar = "";
                string numeroPolizaConvertido = "";
                int consecutivo;
                fecha_carpeta = Convert.ToDateTime(txtFecha.Text).ToString("ddMMMyyyy");

                if (tipoDeBase.Equals("Recibidas"))
                {

                    carpeta_ejercicio = ejercicio + "_" + fecha_carpeta;
                    //JMR_EMI_ENE2018
                    directorio_a_localizar = path + "/" + ejercicio + "/Polizas";//+ carpeta_ejercicio;

                }
                else if (tipoDeBase.Equals("Emitidas"))
                {
                    carpeta_ejercicio = ejercicio + "_" + fecha_carpeta;
                    //JMR_EMI_ENE2018
                    directorio_a_localizar = path + "/" +
                        ejercicio.Substring(0, 3) + "_EMI_" + ejercicio.Substring(4, 7) +
                        "/Polizas";//+ carpeta_ejercicio;



                }





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
                string importeWrite = "0.00";

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
                    if (txtConcepto.Text.Length >= 60)//primer_conccepto
                    {
                        primer_conccepto = txtConcepto.Text.Substring(0, 59);//primer_conccepto
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

                            if (tipoDeBase.Equals("Recibidas"))
                            {

                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite =string.Format("{0:0.00}",decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";//haber
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";//Debe
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);

                                    escritor.WriteLine(importeWrite);
                                }

                            }
                            else if (tipoDeBase.Equals("Emitidas"))
                            {
                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);

                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }


                            }






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


                            if (tipoDeBase.Equals("Recibidas"))
                            {


                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";//Debe
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);

                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";//Haber
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }


                            }
                            else if (tipoDeBase.Equals("Emitidas"))
                            {


                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";//Debe
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";//Haber
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);

                                    escritor.WriteLine(importeWrite);
                                }


                            }






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

                            if (tipoDeBase.Equals("Recibidas"))
                            {

                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);

                                    escritor.WriteLine(importeWrite);
                                }

                            }
                            else if (tipoDeBase.Equals("Emitidas"))
                            {

                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);

                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }

                            }






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
                            if (tipoDeBase.Equals("Recibidas"))
                            {

                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);

                                    escritor.WriteLine(importeWrite);
                                }

                            }
                            else if (tipoDeBase.Equals("Emitidas"))
                            {

                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);

                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }


                            }









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

                            if (tipoDeBase.Equals("Recibidas"))
                            {
                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine(importeWrite);
                                }


                            }
                            else if (tipoDeBase.Equals("Emitidas"))
                            {

                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }

                            }






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
                            if (tipoDeBase.Equals("Recibidas"))
                            {

                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }


                            }
                            else if (tipoDeBase.Equals("Emitidas"))
                            {

                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine(importeWrite);
                                }


                            }




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
                            if (tipoDeBase.Equals("Recibidas"))
                            {
                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }


                            }
                            else if (tipoDeBase.Equals("Emitidas"))
                            {

                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine(importeWrite);
                                }

                            }



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

                            if (tipoDeBase.Equals("Recibidas"))
                            {

                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";

                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine(importeWrite);


                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";

                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }

                            }
                            else if (tipoDeBase.Equals("Emitidas"))
                            {

                                if (tipoDeComprobante.Trim() == "I")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[3].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine("");
                                    escritor.WriteLine(importeWrite);
                                }
                                else if (tipoDeComprobante.Trim() == "E")
                                {
                                    importeWrite = string.Format("{0:0.00}", decimal.Parse(item.Cells[2].Value.ToString())) + ",1.00";
                                    escritor.WriteLine(cuentaWrite);
                                    escritor.WriteLine(tituloWrite);
                                    escritor.WriteLine(importeWrite);
                                }

                            }






                            cuentaBase = item.Cells[0].Value.ToString();

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
                    Isr_Trasladado = Cuenta_isr_trasladado,
                    Ieps_Retenido = Cuenta_ieps_retenido,
                    Ieps_Trasladado = Cuenta_ieps_trasladado,

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
                    SqlCommand cmdD = new SqlCommand("UPDATE " + bases + "  SET realizada='1'" +
                    "  where facturaId='" + IdF + "'", conn);
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

                VentanaForm ventanaForm = new VentanaForm();
                ventanaForm.Show();
                this.Close();

            }





        }
        //Refresca Datos de las cuentas por departamento, sucursal y provedor
        private void cmbLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEmpresadatos();
        }

        //ACTUALIZAR DATOS DE PROVEEDOR
        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (txtDepto.Text != "")
            {

                int empresa = int.Parse(cmbLocalidades.SelectedValue.ToString());
                var empresas = db.Empresas.Where(p => p.IdEmpresa == empresa).FirstOrDefault();


                var ExisteProovedor = db.Proveedores.Where(p => p.RFC == RFC_proveedor
                && p.IdEmpresa == empresas.IdEmpresa).FirstOrDefault();

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











                        var listaProveedores = db.Proveedores.Where(C => C.RFC == RFC_proveedor && C.IdEmpresa == empresa).ToList();
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
        //Exit
        private void btnClose_Click(object sender, EventArgs e)
        {
            VentanaForm ventanaForm = new VentanaForm();
            ventanaForm.Show();
            this.Close();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {

        }
        //Regresar a poliza
        private void btnAnterior_Click(object sender, EventArgs e)
        {





            if (indexGridPosition >= 1)//antes <=
            {


                indexGridPosition--;


                poliza.Rows.Clear();
                Lectura_de_factura();



            }
            else
            {
                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("Has LLegado a la Primera Fila!!" +
                                    "\n" + "Ya no Hay mas Filas Atras! :0",
                                                       "EKPolizaGastos",
                                                       MessageBoxButtons.OK,
                                                       MessageBoxIcon.Exclamation);


            }









        }
        #endregion
    }
}
