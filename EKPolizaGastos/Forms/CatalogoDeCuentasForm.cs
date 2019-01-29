using EKPolizaGastos.Context;
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
    public partial class CatalogoDeCuentasForm : DevComponents.DotNetBar.Office2007Form
    {

        #region Context
        private SEMP_SATContext db;
        private DataTable tabla;
        #endregion


        #region 
        public string RfcDeProveedor;
        public string idEmpresa;
        public string CuentaCapturada;
        #endregion

        public CatalogoDeCuentasForm()
        {
            InitializeComponent();
            db = new SEMP_SATContext();
            tabla = new DataTable();
        }

        private void CatalogoDeCuentasForm_Load(object sender, EventArgs e)
        {
            var datos = db.CuentasGastos.ToList().OrderBy(p => p.IdCuenta).ThenBy(p=> p.IdEmpresa);
            tabla.Columns.Add("Cuenta");
            tabla.Columns.Add("Descripcion");
            tabla.Columns.Add("IdEmpresa");
            

            foreach (var item in datos)
            {
                //var empresa = db.Empresas.Where(p => p.IdEmpresa == item.IdEmpresa).First();
                tabla.Rows.Add(item.Cuenta, item.Descripcion, item.IdEmpresa);
               
            }
            dataGridViewX1.DataSource = tabla;

        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            
            tabla.DefaultView.RowFilter = $"Descripcion LIKE '{textBoxX1.Text}%'";
        }
    }
}
