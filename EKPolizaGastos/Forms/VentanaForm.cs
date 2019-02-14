using DevComponents.DotNetBar;
using EKPolizaGastos.Common.Classes;
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
    public partial class VentanaForm : DevComponents.DotNetBar.Office2007Form
    {
        #region Context
        private SEMP_SATContext db;
        private ReadSATFactura readSATFactura;
        #endregion

        
        public VentanaForm()
        {
            db = new SEMP_SATContext();
            readSATFactura = new ReadSATFactura();
            InitializeComponent();
        }
        private void LoadF()
        {

            DataRow myNewRow;
            DataTable dataTable = new DataTable("TiposFacturas");
            DataColumn colInt32 = new DataColumn("IdTipo");
            colInt32.DataType = System.Type.GetType("System.Int32");

            DataColumn colString = new DataColumn("Tipo");
            colString.DataType = System.Type.GetType("System.String");

            dataTable.Columns.Add(colInt32);
            dataTable.Columns.Add(colString);

            myNewRow = dataTable.NewRow();
            myNewRow["IdTipo"] = 1;
            myNewRow["Tipo"] = "Recibidas";
            dataTable.Rows.Add(myNewRow);

            myNewRow = dataTable.NewRow();
            myNewRow["IdTipo"] = 2;
            myNewRow["Tipo"] = "Emitidas";
            dataTable.Rows.Add(myNewRow);

            myNewRow = dataTable.NewRow();
            myNewRow["IdTipo"] = 3;
            myNewRow["Tipo"] = "Nomina";
            dataTable.Rows.Add(myNewRow);




            cmbTipoFactura.DataSource = dataTable;
            cmbTipoFactura.DisplayMember = "Tipo";
            cmbTipoFactura.ValueMember = "IdTipo";


            cmbEmpresa.DataSource = db.Empresas.ToList();
            cmbEmpresa.DisplayMember = "Empresa";
            cmbEmpresa.ValueMember = "IdEmpresa";
        }
        private void VentanaForm_Load(object sender, EventArgs e)
        {
            LoadF();

        }

      

        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void loadAnosCargados()
        {
            int NoEmpresa = int.Parse(cmbEmpresa.SelectedValue.ToString());
            int tipoFacturas = int.Parse(cmbTipoFactura.SelectedValue.ToString());

            var empresa = db.Empresas.Where(p => p.IdEmpresa == NoEmpresa).First();
            cmbAno.Items.Clear();
            if (tipoFacturas == 1)
            {
                if (empresa.Letra.Trim() == "CIS")
                {
                    var Resultado = (from s in db.CISFACTRECIBIDAS
                                     select s.Ano).Distinct();
                    cmbAno.DataSource = Resultado.ToList();
                    loadMesesCargados();
                }

                if (empresa.Letra.Trim() == "MRO")
                {
                    var Resultado = (from s in db.MROFACTRECIBIDAS
                                     select s.Ano).Distinct();
                    cmbAno.DataSource = Resultado.ToList();
                    loadMesesCargados();
                }

                if (empresa.Letra.Trim() == "CMG")
                {
                    var Resultado = (from s in db.CMGFACTRECIBIDAS
                                     select s.Ano).Distinct();
                    cmbAno.DataSource = Resultado.ToList();
                    loadMesesCargados();
                }

                if (empresa.Letra.Trim() == "DDR")
                {
                    var Resultado = (from s in db.DDRFACTRECIBIDAS
                                     select s.Ano).Distinct();
                    cmbAno.DataSource = Resultado.ToList();

                    loadMesesCargados();

                }

                if (empresa.Letra.Trim() == "JMR")
                {
                    var Resultado = (from s in db.JMRFACTRECIBIDAS
                                     select s.Ano).Distinct();
                    cmbAno.DataSource = Resultado.ToList();
                    //los meses
                    loadMesesCargados();

                }



            }

            //EMITIDAS
            if (tipoFacturas == 2)
            {
                if (empresa.Letra.Trim() == "CIS")
                {
                    var Resultado = (from s in db.CISFACTSEMITIDAS
                                     select s.Ano).Distinct();
                    cmbAno.DataSource = Resultado.ToList();
                    loadMesesCargados();
                }

                if (empresa.Letra.Trim() == "MRO")
                {
                    var Resultado = (from s in db.MROFACTEMITIDAS
                                     select s.Ano).Distinct();
                    cmbAno.DataSource = Resultado.ToList();
                    loadMesesCargados();
                }

                if (empresa.Letra.Trim() == "CMG")
                {
                    var Resultado = (from s in db.CMGFACTEMITIDAS
                                     select s.Ano).Distinct();
                    cmbAno.DataSource = Resultado.ToList();
                    loadMesesCargados();
                }

                if (empresa.Letra.Trim() == "DDR")
                {
                    var Resultado = (from s in db.DDRFACTEMITIDAS
                                     select s.Ano).Distinct();
                    cmbAno.DataSource = Resultado.ToList();

                    loadMesesCargados();

                }

                if (empresa.Letra.Trim() == "JMR")
                {
                    var Resultado = (from s in db.JMRFACTEMITIDAS
                                     select s.Ano).Distinct();
                    cmbAno.DataSource = Resultado.ToList();
                    //los meses
                    loadMesesCargados();

                }



            }

            //NOMINA

        }

        private void loadMesesCargados()
        {
            int NoEmpresa = int.Parse(cmbEmpresa.SelectedValue.ToString());
            int tipoFacturas = int.Parse(cmbTipoFactura.SelectedValue.ToString());

            var empresa = db.Empresas.Where(p => p.IdEmpresa == NoEmpresa).First();
            int ano = int.Parse(cmbAno.Text);
            if (tipoFacturas == 1)
            {
                if (empresa.Letra.Trim() == "CIS")
                {
                    var Resultado = (from s in db.CISFACTRECIBIDAS
                                     where s.Ano==ano select s.Mes ).Distinct();
                    cmbMes.Items.Clear();
                    foreach (var item in Resultado)
                    {
                        mesConvertido(item.Value);
                    }



                }

                if (empresa.Letra.Trim() == "MRO")
                {
                    var Resultado = (from s in db.MROFACTRECIBIDAS
                                     where s.Ano == ano
                                     select s.Mes).Distinct();
                    cmbMes.Items.Clear();
                    foreach (var item in Resultado)
                    {
                        mesConvertido(item.Value);
                    }

                }

                if (empresa.Letra.Trim() == "CMG")
                {
                    var Resultado = (from s in db.CMGFACTRECIBIDAS
                                     where s.Ano == ano
                                     select s.Mes).Distinct();
                    cmbMes.Items.Clear();
                    foreach (var item in Resultado)
                    {
                        mesConvertido(item.Value);
                    }

                }

                if (empresa.Letra.Trim() == "DDR")
                {
                    var Resultado = (from s in db.DDRFACTRECIBIDAS
                                     where s.Ano == ano
                                     select s.Mes).Distinct();
                    cmbMes.Items.Clear();
                    foreach (var item in Resultado)
                    {
                        mesConvertido(item.Value);
                    }


                }

                if (empresa.Letra.Trim() == "JMR")
                {
                    var Resultado = (from s in db.JMRFACTRECIBIDAS
                                     where s.Ano == ano
                                     select s.Mes).Distinct();
                    cmbMes.Items.Clear();
                    foreach (var item in Resultado)
                    {
                        mesConvertido(item.Value);
                    }

                }



            }

            //EMITIDAS
            if (tipoFacturas == 2)
            {
                if (empresa.Letra.Trim() == "CIS")
                {
                    var Resultado = (from s in db.CISFACTSEMITIDAS
                                     where s.Ano == ano
                                     select s.Mes).Distinct();
                    cmbMes.Items.Clear();
                    foreach (var item in Resultado)
                    {
                        mesConvertido(item.Value);
                    }



                }

                if (empresa.Letra.Trim() == "MRO")
                {
                    var Resultado = (from s in db.MROFACTEMITIDAS
                                     where s.Ano == ano
                                     select s.Mes).Distinct();
                    cmbMes.Items.Clear();
                    foreach (var item in Resultado)
                    {
                        mesConvertido(item.Value);
                    }

                }

                if (empresa.Letra.Trim() == "CMG")
                {
                    var Resultado = (from s in db.CMGFACTEMITIDAS
                                     where s.Ano == ano
                                     select s.Mes).Distinct();
                    cmbMes.Items.Clear();
                    foreach (var item in Resultado)
                    {
                        mesConvertido(item.Value);
                    }

                }

                if (empresa.Letra.Trim() == "DDR")
                {
                    var Resultado = (from s in db.DDRFACTEMITIDAS
                                     where s.Ano == ano
                                     select s.Mes).Distinct();
                    cmbMes.Items.Clear();
                    foreach (var item in Resultado)
                    {
                        mesConvertido(item.Value);
                    }


                }

                if (empresa.Letra.Trim() == "JMR")
                {
                    var Resultado = (from s in db.JMRFACTEMITIDAS
                                     where s.Ano == ano
                                     select s.Mes).Distinct();
                    cmbMes.Items.Clear();
                    foreach (var item in Resultado)
                    {
                        mesConvertido(item.Value);
                    }

                }



            }

            //NOMINA
        }

        private void mesConvertido(int Value)
        {
            if (Value == 1)
            {
                cmbMes.Items.Add("ENERO");
            }
            if (Value == 2)
            {
                cmbMes.Items.Add("FEBRERO");
            }
            if (Value == 3)
            {
                cmbMes.Items.Add("MARZO");
            }
            if (Value == 4)
            {
                cmbMes.Items.Add("ABRIL");
            }
            if (Value == 5)
            {
                cmbMes.Items.Add("MAYO");
            }
            if (Value == 6)
            {
                cmbMes.Items.Add("JUNIO");
            }
            if (Value == 7)
            {
                cmbMes.Items.Add("JULIO");
            }
            if (Value == 8)
            {
                cmbMes.Items.Add("AGOSTO");
            }
            if (Value == 9)
            {
                cmbMes.Items.Add("SEPTIEMBRE");
            }
            if (Value == 10)
            {
                cmbMes.Items.Add("OCTUBRE");
            }
            if (Value == 11)
            {
                cmbMes.Items.Add("NOVIEMBRE");
            }
            if (Value == 12)
            {
                cmbMes.Items.Add("DICIEMBRE");
            }
        }


        private void cmbEmpresa_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            loadAnosCargados();
        }

        private void cmbAno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }
        //MANDO EL EJERCICIO 
        private void btnComenzar_Click(object sender, EventArgs e)
        {
            string ejercicio;
            int idEmpresa =int.Parse(cmbEmpresa.SelectedValue.ToString());
            var empresa = db.Empresas.Where(p => p.IdEmpresa == idEmpresa).FirstOrDefault();
            int tipoFacturas = int.Parse(cmbTipoFactura.SelectedValue.ToString());

            ejercicio = empresa.Letra.Trim() + "-" + cmbMes.Text.Substring(0, 3) + cmbAno.Text;
            MessageBoxEx.EnableGlass = false;
            MessageBoxEx.Show("Ejercicio Elejido: " + ejercicio + "",
                "EKPolizaGastos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PolizaSatForm polizaSatForm = new PolizaSatForm();
            polizaSatForm.ejercicio = ejercicio;
            if (tipoFacturas == 1)
            {
                polizaSatForm.path = empresa.Path;
            }
            if (tipoFacturas == 2)
            {
                polizaSatForm.path = empresa.PathNomina;
            }

            string cnx =readSATFactura.CheckDataConection();

            polizaSatForm.cnx = cnx;
            polizaSatForm.ShowDialog();
            return;
        }
    }
}
