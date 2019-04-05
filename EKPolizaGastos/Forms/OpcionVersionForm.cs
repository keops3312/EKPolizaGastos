

namespace EKPolizaGastos.Forms
{

    #region Libraries (librerias)
    using System;
    using System.Threading;
    using System.Windows.Forms;
    #endregion
    public partial class OpcionVersionForm : DevComponents.DotNetBar.Office2007Form
    {

        #region Attributes (Atributos)
        public int p = 0; 
        #endregion

        #region Methods (Metodos)
        public OpcionVersionForm()
        {
           
            InitializeComponent();
          

        }

        private void Splash()
        {
            SplashScreen.SplashForm frm = new SplashScreen.SplashForm();
            frm.AppName = "Polizas y DIOT XML";
            frm.Icon = Properties.Resources.empresa;
             frm.ShowIcon = true;
            frm.ShowInTaskbar = true;
            Application.Run(frm);
        }

        #endregion

        #region Events (Eventos)
        private void OpcionVersionForm_Load(object sender, EventArgs e)
        {
            if (p == 0)
            {
                Thread t = new Thread(new ThreadStart(Splash));
                t.Start();
                //Loading Data
                string str = string.Empty;
                for (int i = 0; i < 60000; i++)
                {
                    str += i.ToString();//init data
                }
                //complete
                t.Abort();

            }
            

           
        }
        //CLOSE
        private void metroTileItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Version dos
        private void metroTileItemVersionDos_Click(object sender, EventArgs e)
        {
            VentanaForm ventanaForm = new VentanaForm();
            this.Hide();
            ventanaForm.Show();

        }
        //Version uno
        private void metroTileItemVersionUno_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        } 
        #endregion
    }
}
