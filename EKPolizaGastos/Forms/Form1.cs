


namespace EKPolizaGastos
{


    #region Libraries (Librerias)
    using System;
    using System.IO;
    using System.Windows.Forms;
    using EKPolizaGastos.Common;
    using EKPolizaGastos.Common.Classes;
    using DevComponents.DotNetBar;
    using DevComponents.DotNetBar.Rendering;
    using DevComponents.DotNetBar.Metro;
    #endregion



    public partial class Form1 : Office2007Form
    {


        #region Attributtes
        private FolderBrowserDialog folderBrowserDialog;
        private ReadSATFactura readSATFactura;

        #endregion

        #region Properties
        private string path;
        private string cnx;

        #endregion

        #region Methods
        private void LoadPath()
        {
            

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {

                path = folderBrowserDialog.SelectedPath;
                txtpath.Text = path;

                string[] dirs = Directory.GetFiles(path, "*.XML");

                int cantidad = dirs.Length;
                lblCount.Text = "Numero de XML docuemntos encontrados: " + cantidad;

            }

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
            ReadAndStart();
        }

        public Form1()
        {
            InitializeComponent();

            txtpath.Enabled = false;

            folderBrowserDialog = new FolderBrowserDialog();
            readSATFactura = new ReadSATFactura();

            cnx = readSATFactura.CheckDataConection();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCargarRuta_MouseHover(object sender, EventArgs e)
        {
           


            ToastNotification.Show(this, "Click para cargar Ruta donde estan los XML", 
                eToastGlowColor.Blue, eToastPosition.BottomRight);
        }




        #endregion


    }
}
