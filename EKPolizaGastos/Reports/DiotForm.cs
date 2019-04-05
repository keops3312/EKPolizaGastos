using CrystalDecisions.Shared;
using DevComponents.DotNetBar;
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
        public string ruta;
        public string letra;
        public string carpeta;
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

            //Autoguardamos el documento en PDF en la ruta que corresponde

            ExportOptions CrExportOptions;
            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            string carpetaContenedora=letra +"-"+ mes.Substring(0,3) + ano+"/";
           
            string concatRuta = ruta + "/" + carpetaContenedora + "DIOT_" + mes + ano + "_" + rfc + " .pdf";
            carpeta = ruta + "/" + carpetaContenedora + "DIOT_" + mes + ano + "_" + rfc + " .txt";


            CrDiskFileDestinationOptions.DiskFileName = concatRuta;
            CrExportOptions = ob.ExportOptions;
            {
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
            }
           ob.Export();
            MessageBoxEx.EnableGlass = false;
            MessageBoxEx.Show("Reporte Exportado con Exito!\n"+
               concatRuta , "EKDIOT",
             MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnDiot_Click(object sender, EventArgs e)
        {

            EleccionForm eleccionForm = new EleccionForm();
            eleccionForm.Resultado = Resultado;
            eleccionForm.empresa = empresa;
            eleccionForm.mes = mes;
            eleccionForm.ano = ano;
            eleccionForm.rfc = rfc;
            eleccionForm.carpeta = carpeta;
            eleccionForm.Show();

         
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
  