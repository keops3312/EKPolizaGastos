
namespace EKPolizaGastos.Forms
{

    #region Libraries (Librerias)
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Windows.Forms;
    using DevComponents.DotNetBar;
    using EKPolizaGastos.Context; 
    #endregion



    public partial class CargosForm : DevComponents.DotNetBar.Office2007Form
    {

        #region Context
        private SEMP_SATContext db;
        public PlantillaPrepolizaForm plantilla;
        public PolizaSatForm polizaSatForm;
        public int opcion;
        #endregion

        #region Properties
        public string RfcDeProveedor;
        public string idEmpresa;
        public string CuentaCapturada;
        #endregion

        #region Methods (Metodos)

        public CargosForm()
        {
            InitializeComponent();
            db = new SEMP_SATContext();
        }



        private void loadCuentas()
        {
            int empresa = Convert.ToInt32(idEmpresa);

            var cuentas = db.Proveedores.Where(p => p.RFC == RfcDeProveedor &&
                        p.IdEmpresa == empresa).FirstOrDefault();

            txtAbono1.Text = "0000-000-000";
            txtAbono2.Text = "0000-000-000";
            txtAbono3.Text = "0000-000-000";
            if (cuentas != null)
            {
                txtAbono1.Text = cuentas.Cuenta_cargo_1;
                txtAbono2.Text = cuentas.Cuenta_cargo_2;
                txtAbono3.Text = cuentas.Cuenta_cargo_3;

                var leyendaCuenta = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                  empresa && p.Cuenta == cuentas.Cuenta_cargo_1).FirstOrDefault();

                var leyendaCuenta2 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                     empresa && p.Cuenta == cuentas.Cuenta_cargo_2).FirstOrDefault();

                var leyendaCuenta3 = db.CuentasGastos.Where(p => p.IdEmpresa ==
                                     empresa && p.Cuenta == cuentas.Cuenta_cargo_3).FirstOrDefault();



                if (leyendaCuenta != null)
                {
                    lblAbono1.Text = leyendaCuenta.Descripcion;

                }
                if (leyendaCuenta2 != null)
                {
                    lblAbono2.Text = leyendaCuenta2.Descripcion;

                }
                if (leyendaCuenta3 != null)
                {
                    lblAbono3.Text = leyendaCuenta3.Descripcion;
                }
            }





            txtCuentaBase.Text = CuentaCapturada;

        }


        private void actualizarcuenta(int v)
        {
            int empresa = Convert.ToInt32(idEmpresa);
            var cuentas = db.Proveedores.Where(p => p.RFC == RfcDeProveedor
                        && p.IdEmpresa == empresa).FirstOrDefault();
            Proveedores proveedores = new Proveedores();

            if (cuentas == null)
            {
                proveedores.Cuenta_cargo_1 = "0000-000-000";
                proveedores.Cuenta_cargo_2 = "0000-000-000";
                proveedores.Cuenta_cargo_3 = "0000-000-000";
                proveedores.Cuenta_Cargo_Iva = "0000-000-000";
                proveedores.Cuenta_Abono_1 = "0000-000-000";
                proveedores.Cuenta_Abono_2 = "0000-000-000";
                proveedores.Cuenta_Abono_3 = "0000-000-000";

                proveedores.Isr_Retenido = "0000-000-000";
                proveedores.Iva_Retenido = "0000-000-000";
                proveedores.Isr_Trasladado = "0000-000-000";
                proveedores.Ieps_Trasladado = "0000-000-000";
                proveedores.Ieps_Retenido = "0000-000-000";

                proveedores.RFC = RfcDeProveedor;
                proveedores.Titulo_principal = "PROVEEDOR";
                proveedores.Titulo_secundario = "PROVEEDOR";
                proveedores.Titulo_tercero = "PROVEEDOR";
                proveedores.Departamento = "2";
                proveedores.IdLocalidad = 1;
                proveedores.IdEmpresa = empresa;

                switch (v)
                {
                    case 1:
                        proveedores.Cuenta_cargo_1 = txtCuentaBase.Text.Trim();


                        break;
                    case 2:
                        proveedores.Cuenta_cargo_2 = txtCuentaBase.Text.Trim();

                        break;
                    case 3:
                        proveedores.Cuenta_cargo_3 = txtCuentaBase.Text.Trim();

                        break;

                    default:
                        break;
                }

                db.Proveedores.Add(proveedores);
                db.SaveChanges();

            }
            else
            {
                proveedores = cuentas;
                switch (v)
                {
                    case 1:
                        proveedores.Cuenta_cargo_1 = txtCuentaBase.Text.Trim();

                        break;
                    case 2:
                        proveedores.Cuenta_cargo_2 = txtCuentaBase.Text.Trim();

                        break;
                    case 3:
                        proveedores.Cuenta_cargo_3 = txtCuentaBase.Text.Trim();

                        break;

                    default:
                        break;
                }

                db.Proveedores.Attach(proveedores);

                db.Entry(proveedores).State =
                    EntityState.Modified;
                db.SaveChanges();

            }





        }

        #endregion

        #region Events (Eventos)
        private void CargosForm_Load(object sender, EventArgs e)
        {
            loadCuentas();

        }

        private void btpUpdate_Click(object sender, EventArgs e)
        {
            MessageBoxEx.EnableGlass = false;
            DialogResult actualizarProveedor = MessageBoxEx.Show("¿Actualizar esta cuenta de Cargo?",
                "EKPolizaGastos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int i = 0;
            if (actualizarProveedor == DialogResult.Yes)
            {
                if (radioButton1.Checked == true)
                {
                    actualizarcuenta(1);
                    i = 1;
                }
                if (radioButton2.Checked == true)
                {
                    actualizarcuenta(2);
                    i = 2;
                }
                if (radioButton3.Checked == true)
                {
                    actualizarcuenta(3);
                    i = 3;
                }

                MessageBoxEx.EnableGlass = false;
                MessageBoxEx.Show("Cuenta Actualizada con Exito!",
                     "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (opcion == 1)
                {
                    polizaSatForm.CargarDatosCuentas2(Convert.ToInt32(idEmpresa), i, txtCuentaBase.Text.Trim());
                    opcion = 0;
                }
                else
                {
                    plantilla.CargarDatosCuentas2(Convert.ToInt32(idEmpresa), i, txtCuentaBase.Text.Trim());

                }


                this.Close();

            }
        }

        #endregion


    }
}
