using DevComponents.DotNetBar;
using EKPolizaGastos.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EKPolizaGastos.Forms
{
    public partial class EleccionForm : DevComponents.DotNetBar.Office2007Form
    {

        public DataTable Resultado;
        public string mes;
        public string empresa;
        public string ano;
        public string rfc;
        public string carpeta;

        #region Context
        private SEMP_SATContext db;
        private int Fila_actualizar_cargo;
        #endregion

        public EleccionForm()
        {
            db = new SEMP_SATContext();
            InitializeComponent();
        }

        private void EleccionForm_Load(object sender, EventArgs e)
        {
            loadGrid();

        }

        private void loadGrid()
        {

          
            DataTable dataTable = new DataTable("DIOT");
            dataTable.Columns.Add("TipoTercero");
            dataTable.Columns.Add("TipoOperacion");
            dataTable.Columns.Add("RFC");
            dataTable.Columns.Add("Proveedor");
            dataTable.Columns.Add("Base");
            dataTable.Columns.Add("NoGrabanIva");
            dataTable.Columns.Add("IvaRetenido");
            dataTable.Columns.Add("IvaEgreso");
          
            foreach (DataRow item in Resultado.Rows)
            {
                int IdEmpresa =int.Parse(item[14].ToString());
                string RFC = item[0].ToString();
                var datosEmpresa = db.Proveedores.Where
                    (p => p.IdEmpresa == IdEmpresa 
                    && p.RFC == RFC)
                    .FirstOrDefault();


                
                string tercero = "04";
                string operacion = "85";

                if (datosEmpresa!=null)
                {
                    tercero = datosEmpresa.tipoDeTercero;
                    operacion = datosEmpresa.tipoDeOperacion;
                   
                }
                if (string.IsNullOrEmpty(tercero)|| string.IsNullOrWhiteSpace(tercero))
                {
                    tercero = "04";
                    operacion = "85";
                }

                dataTable.Rows.Add(tercero,
                  operacion ,
                     RFC.Trim(),
                     item[1].ToString(),
                     item[4].ToString(),
                     item[7].ToString(),
                     item[5].ToString(),
                     item[9].ToString()

                 );

             

            }
            

           dataGridViewX1.DataSource = dataTable;

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {


            //ALTERNAMENTE DISEÑAMOS EL BLOC DE NOTAS
            using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(carpeta))
            {
                int Base;
                int NoGrabanIVA;
                int IvaRetenido;
                int IvaEgreso;

                string tipoTercero;
                string tipoOperacion;
                string rfc;

                foreach (DataGridViewRow item in dataGridViewX1.Rows)
                {
                    rfc = item.Cells[2].Value.ToString();
                    tipoTercero = item.Cells[0].Value.ToString();
                    tipoOperacion = item.Cells[1].Value.ToString();
                    if (string.IsNullOrEmpty(tipoTercero) || string.IsNullOrWhiteSpace(tipoTercero))
                    {
                        tipoTercero = "04";
                        tipoOperacion = "85";
                    }
                    Base = (int)Math.Round(Convert.ToDouble(item.Cells[4].Value.ToString()), 0, MidpointRounding.ToEven);
                    IvaRetenido = (int)Math.Round(Convert.ToDouble(item.Cells[6].Value.ToString()), 0, MidpointRounding.ToEven);
                    NoGrabanIVA = (int)Math.Round(Convert.ToDouble(item.Cells[5].Value.ToString()), 0, MidpointRounding.ToEven);
                    IvaEgreso = (int)Math.Round(Convert.ToDouble(item.Cells[7].Value.ToString()), 0, MidpointRounding.ToEven);

                    string batch;
                    batch = "" + tipoTercero.Trim() + "|" + tipoOperacion.Trim() + "|" + rfc + "|||||" + Base + "||||||||||||" + NoGrabanIVA + "||" + IvaRetenido + "|" + IvaEgreso + "|";

                    escritor.WriteLine(batch);

                    int IdEmpresa = int.Parse(Resultado.Rows[0][14].ToString());
                    var listaProveedores = db.Proveedores.Where(C => C.RFC == rfc.Trim() && C.IdEmpresa == IdEmpresa).FirstOrDefault();
                    if (listaProveedores != null)
                    {
                        if (chkTipoOperacion.Checked == true)
                        {

                            //Proveedores proveedoresM = new Proveedores();
                            listaProveedores.tipoDeOperacion = tipoOperacion;
                            //MODIFICAR SOLO UNA ENTIDAD CON  ENTY FRAMEWORK
                            db.Proveedores.Attach(listaProveedores);
                            db.Entry(listaProveedores).State =
                            EntityState.Modified;
                            db.SaveChanges();



                        }
                        if (chkTipoTercero.Checked == true)
                        {

                            //Proveedores proveedoresM = new Proveedores();
                            listaProveedores.tipoDeTercero = tipoTercero;
                            //MODIFICAR SOLO UNA ENTIDAD CON  ENTY FRAMEWORK
                            db.Proveedores.Attach(listaProveedores);
                            db.Entry(listaProveedores).State =
                            EntityState.Modified;
                            db.SaveChanges();
                        }
                    }



                }



            }


            MessageBoxEx.EnableGlass = false;
            MessageBoxEx.Show("DIOT GENERADA CON EXITO\n"+
                carpeta, "EKDIOT",
            MessageBoxButtons.OK, MessageBoxIcon.Information);



            //string ruta;
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            //saveFileDialog1.FilterIndex = 2;
            

            //string initPath = "T:/CFDIS/CIS/CIS-ENE2018"; //carpeta;
            
            //saveFileDialog1.InitialDirectory = initPath;

            //saveFileDialog1.RestoreDirectory = true;

            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{

            //    ruta = saveFileDialog1.FileName;

            //    if (string.IsNullOrEmpty(ruta))
            //    {
            //        MessageBoxEx.EnableGlass = false;
            //        MessageBoxEx.Show("No hay directorio Seleccionado",
            //            "EKDIOT", MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //    }
            //    else
            //    {

                  

            //    }
            //}


          

        }
        //Proveedor Nacional
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX1.Rows[Fila_actualizar_cargo].Cells[0].Value = "04";

            }
            catch (Exception ex)
            {

            }
        }
        //Proovedor Extranjero
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX1.Rows[Fila_actualizar_cargo].Cells[0].Value = "05";

            }
            catch (Exception ex)
            {

            }
        }
        //Proveedor Global
        private void buttonItem6_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX1.Rows[Fila_actualizar_cargo].Cells[0].Value = "15";

            }
            catch (Exception ex)
            {

            }
        }



        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Fila_actualizar_cargo = dataGridViewX1.CurrentCell.RowIndex;//e.-columnindex para saber que columna seleccione
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Fila_actualizar_cargo = dataGridViewX1.CurrentCell.RowIndex;//e.-columnindex para saber que columna seleccione
            }
            catch (Exception ex)
            {

            }
        }
        
        
        //Prestacion de servicios
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX1.Rows[Fila_actualizar_cargo].Cells[1].Value = "03";

            }
            catch (Exception ex)
            {

            }
        }
        //Arrendamiento
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX1.Rows[Fila_actualizar_cargo].Cells[1].Value = "06";

            }
            catch (Exception ex)
            {

            }
        }
        //Otros
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX1.Rows[Fila_actualizar_cargo].Cells[1].Value = "85";

            }
            catch (Exception ex)
            {

            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
