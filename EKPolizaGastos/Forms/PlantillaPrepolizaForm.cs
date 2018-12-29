

namespace EKPolizaGastos.Forms
{
    using EKPolizaGastos.Common.Classes;

    #region Libraries(librerias)
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
    #endregion

    public partial class PlantillaPrepolizaForm : DevComponents.DotNetBar.Office2007Form
    {
        #region Context
        private SEMP_SATConetxt db;
        #endregion


        #region Properties
        ReadSATFactura readSATFactura;
        #endregion

        #region Attributes
        public string ejercicio;
        public string cnx;
        #endregion

        public PlantillaPrepolizaForm()
        {
            InitializeComponent();

            db = new SEMP_SATConetxt();
            readSATFactura = new ReadSATFactura();

           
        }

        private void PlantillaPrepolizaForm_Load(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = readSATFactura.listExercise(cnx, ejercicio);

            var datos = db.Empresas.Where(p => p.Letra == ejercicio.Substring(0, 3)).First();

            lblEmpresa.Text = "Empresa:  "+datos.Empresa;

            lblMes.Text ="Mes: " + SearchMonth(ejercicio.Substring(4, 3));

            lblAno.Text = "Año: " + ejercicio.Substring(7, 4);

            lblCantidad.Text ="Numero de CFDI cargados del mes: " + dataGridViewX1.Rows.Count;

           int dias = SearchMonthD(ejercicio.Substring(4, 3))

            //dateInput.MinDate =;
            //dateInput.MaxDate =;
            //dateInput.Value =;
        }

        private string SearchMonth(string v)
        {
            string month=""; 
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

        private int SearchMonthD(string v)
        {
            int month = 0;
            switch (v)
            {
                case "ENE":
                    month = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)),1);
                    break;
                case "FEB":
                    month = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 2);
                    break;
                case "MAR":
                    month = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 3);
                    break;
                case "ABR":
                    month = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 4);
                    break;
                case "MAY":
                    month = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 5);
                    break;
                case "JUN":
                    month = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 6);
                    break;
                case "JUL":
                    month = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 7);
                    break;
                case "AGO":
                    month = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 8);
                    break;
                case "SEP":
                    month = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 9);
                    break;
                case "OCT":
                    month = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 10);
                    break;
                case "NOV":
                    month = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 11);
                    break;
                case "DIC":
                    month = DateTime.DaysInMonth(int.Parse(ejercicio.Substring(7, 4)), 12);
                    break;

                default:

                    break;


            }

            return month;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //LoadCFDIS();
        }

      
    }
}
