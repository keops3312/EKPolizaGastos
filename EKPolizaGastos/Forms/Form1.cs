


namespace EKPolizaGastos
{


    #region Libraries (Librerias)
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    using DevComponents.DotNetBar;
    using DevComponents.DotNetBar.Rendering;
    using EKPolizaGastos.Common.Classes;
    using EKPolizaGastos.Forms;
    #endregion



    public partial class Form1 : DevComponents.DotNetBar.Office2007Form 
    {
       


        #region Attributtes
        private FolderBrowserDialog folderBrowserDialog;
        private ReadSATFactura readSATFactura;
        
        #endregion

        #region Properties
        private string path;
        private string cnx;
        private int cantidad;
        #endregion

        #region Methods
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
            readSATFactura.Scan(path,cnx);
        }
        #endregion

        #region Events
        private void btnCargarRuta_Click(object sender, EventArgs e)
        {
            if (cnx == "false")
            {

                lblMessage.Text = "NO me puedo enlazar al servidor Verifique su conexion";
                return;
            }

            LoadPath();

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

            btnCargarRuta.Enabled = false;
            circularProgress1.Visible = true;
            circularProgress1.IsRunning = true;
            backgroundWorker1.RunWorkerAsync();
        }

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
           
            CheckForIllegalCrossThreadCalls = false;//To Use Multi threads

            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, eOffice2007ColorScheme.Black);

            txtpath.Enabled = false;
            circularProgress1.Visible = false;


            folderBrowserDialog = new FolderBrowserDialog();
            readSATFactura = new ReadSATFactura();

            cnx = readSATFactura.CheckDataConection();
            hideObjects();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCargarRuta_MouseHover(object sender, EventArgs e)
        {
           
            ToastNotification.Show(this, "Click para cargar Ruta donde estan los XML",
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
            btnCargarRuta.Enabled = true;
            circularProgress1.Visible = false;
            circularProgress1.IsRunning = false;
            MessageBoxEx.EnableGlass = false;
            MessageBoxEx.Show("XML Cargados con Exito", "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

       
    }
}
