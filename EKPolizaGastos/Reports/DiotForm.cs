using EKPolizaGastos.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EKPolizaGastos.Reports
{
    public partial class DiotForm : DevComponents.DotNetBar.Office2007Form
    {
        
        public DataTable Resultado;
        public string mes;
        public string empresa;
        public string ano;
        public string rfc;

        public DiotForm()
        {
            InitializeComponent();
        }

        private void DiotForm_Load(object sender, EventArgs e)
        {
            dataSetDiot1.Tables.Remove("DIOT");
            dataSetDiot1.Tables.Add(Resultado);
            CrystalReportDiot ob = new CrystalReportDiot();
            ob.SetDataSource(dataSetDiot1);
            ob.SetParameterValue("empresa", empresa);
            ob.SetParameterValue("mes", mes);
            ob.SetParameterValue("ano", ano);
            ob.SetParameterValue("rfc", rfc);
            crystalReportViewer1.ReportSource = ob;
            crystalReportViewer1.Refresh();
        }

        private void btnDiot_Click(object sender, EventArgs e)
        {

            EleccionForm eleccionForm = new EleccionForm();
            eleccionForm.Resultado = Resultado;
            eleccionForm.empresa = empresa;
            eleccionForm.mes = mes;
            eleccionForm.ano = ano;
            eleccionForm.rfc = rfc;
            eleccionForm.Show();

         
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
  