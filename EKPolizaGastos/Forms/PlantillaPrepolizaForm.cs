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
    public partial class PlantillaPrepolizaForm : DevComponents.DotNetBar.Office2007Form
    {
        #region Context
        private SEMP_SATEntities db;
        #endregion

        public PlantillaPrepolizaForm()
        {
            InitializeComponent();

            db = new SEMP_SATEntities();

            cmbEmpresas.DataSource = db.Empresas.ToList();
            cmbEmpresas.DisplayMember = "Empresa";
            cmbEmpresas.ValueMember = "RFC";

            dateInput.Value = DateTime.Now;

        }

        private void PlantillaPrepolizaForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            LoadCFDIS();
        }

        private void LoadCFDIS()
        {
            

            dataGridViewX1.DataSource = db.Comprobante.Where(p => p.RFC_receptor == cmbEmpresas.ValueMember &&
                                                              p.Fecha == Convert.ToDateTime(dateInput.Value).ToString("yyyy-MM-dd")).ToList();
            
        }
    }
}
