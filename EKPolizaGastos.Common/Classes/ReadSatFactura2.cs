using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKPolizaGastos.Common.Classes
{
    public class ReadSatFactura2
    {
       

        //EXCEL DATATABLE
        public DataTable ExcelImport(string path, string nombreHoja)
        {
            //Create a new DataTable.
            DataTable dt = new DataTable();

            using (XLWorkbook workBook = new XLWorkbook(path))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Create a new DataTable.

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            if (!string.IsNullOrEmpty(cell.Value.ToString()))
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            else
                            {
                                break;
                            }
                        }
                        firstRow = false;
                    }
                    else
                    {
                        int i = 0;
                        DataRow toInsert = dt.NewRow();
                        foreach (IXLCell cell in row.Cells(1, dt.Columns.Count))
                        {
                            try
                            {
                                toInsert[i] = cell.Value.ToString();
                            }
                            catch (Exception ex)
                            {

                            }
                            i++;
                        }
                        dt.Rows.Add(toInsert);
                    }
                }



                return dt;
            }
        }

        //CREATING DIOT
        //Catch Empresa Number
        public int EmpresaId(string Letra, string cnx)
        {
            int numero;

            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cnx))
            {

                SqlCommand cmd = new SqlCommand("SELECT IdEmpresa FROM Empresas where Letra='" + Letra.Trim() + "' ", conn);
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(dataTable);
                    numero = int.Parse(dataTable.Rows[0][0].ToString());
                }

            }

            return numero;
        }

        //Estep 1
        //Fill Proveddor Compare
        public DataTable ToListPRV(string Ejercicio, string cnx, string base_Iva, string RFCEmpresa, string Mes, string Periodo)
        {
            string Tabla;
            Tabla = Ejercicio.Substring(0, 3) + "FACTRECIBIDAS";
            int mes = SearchMonthD(Mes);

            SqlConnection conn = new SqlConnection(cnx);
            DataTable Proveedores = new DataTable();
            //CHARGE DATA 
            SqlCommand cmd = new SqlCommand("select distinct(RFCEmisor)," +
                "NombreEmisor from " + Tabla + " where Ano='"+ Periodo + "' and Mes='"+ mes + "' and Empresa='" + RFCEmpresa + "' order by RFCEmisor", conn);
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(Proveedores);

            }
            return Proveedores;

        }

        //Estep 2
        //Fill Excersise DIOT
        public DataTable DIOT(DataTable proovedores, string Ejercicio, string cnx, string base_Iva, string IdEmpresa, string Mes, string Periodo)
        {
            string Tabla;
            Tabla = Ejercicio.Substring(0, 3) + "FACTRECIBIDAS";
            

            SqlConnection conn = new SqlConnection(cnx);
            //CREATE TABLE TO EXCEL FILE
            DataTable result = new DataTable();

            string RFC_Emisor;
            string Proveedor_Emisor;

            decimal Iva_trasladado; //NO redondeado
            int BaseR;//redondeado
            decimal BaseD;//NO redondeado
            decimal iva_calculado; //NO redondeado

          

            Mes = Convert.ToString(SearchMonthD(Mes));

            DataTable Existe = new DataTable();
            //compruebo si ya existe ejercicio y de lo contrario solo lo llamo
            SqlCommand cmdExiste = new SqlCommand("select * from diot where mes='" + Mes + "' and periodo='" + Periodo + "' and " +
                                  "IdEmpresa='" + IdEmpresa + "' order by Proveedor asc", conn);
            using (SqlDataAdapter a = new SqlDataAdapter(cmdExiste))
            {
                Existe.Clear();
                a.Fill(Existe);

            }
            //Si no existe el ejercicio se realiza, de lo contrario solo lo llamo con la consulta
            if (Existe.Rows.Count == 0)
            {
                //CHARGE DATA DIOT
                foreach (DataRow item in proovedores.Rows)
                {

                    RFC_Emisor = item[0].ToString();
                    Proveedor_Emisor = item[1].ToString();

                 
                    SqlCommand cmd = new SqlCommand("select sum(Convert(decimal(18,2),IVA)) as IVA," +
                        " sum(Convert(decimal(18,2),IVA)/ "+ base_Iva +") as Base, " +//- CONVERT(decimal(18, 2), Descuento)
                        " sum(Convert(decimal(18,2),RetenidoIVA)) as IVARetenido" +
                        " from " + Tabla + "" +
                        " where RFCEmisor = '" + RFC_Emisor + "' and Ano='" + Periodo +"' and " +
                        "Mes='" +  Mes + "'", conn);
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        result.Clear();
                        a.Fill(result);

                    }

                    Iva_trasladado = decimal.Parse(result.Rows[0][0].ToString()); //NO redondeado

                    BaseD = decimal.Parse(result.Rows[0][1].ToString()); //NO redondeado
                    BaseR = (int)Math.Round(Convert.ToDouble(BaseD), 0, MidpointRounding.ToEven);

                   iva_calculado = (int)Math.Round(Convert.ToDouble(Iva_trasladado), 0, MidpointRounding.ToEven); ; //redondeado

                    if (iva_calculado > 0)
                    {
                        Register(RFC_Emisor, Proveedor_Emisor, Iva_trasladado, BaseR, iva_calculado, cnx, IdEmpresa, Mes, Periodo);
                    }
                    RFC_Emisor = string.Empty;
                    Proveedor_Emisor = string.Empty;


                }

            }



            DataTable ResultadoDIOT = new DataTable("DIOT");

            SqlCommand cmddiot = new SqlCommand("select * from diot where mes='" + Mes + "' and periodo='" + Periodo + "' and " +
                                    "IdEmpresa='" + IdEmpresa + "' order by Proveedor asc", conn);
            using (SqlDataAdapter a = new SqlDataAdapter(cmddiot))
            {
                ResultadoDIOT.Clear();
                a.Fill(ResultadoDIOT);

            }

            decimal suma_A = 0;
            decimal suma_B = 0;
            decimal suma_C = 0;

            foreach (DataRow dr in ResultadoDIOT.Rows)
            {
                suma_A += Convert.ToDecimal(dr[3].ToString());//iva_trasladado
                suma_B += Convert.ToDecimal(dr[4].ToString());//base
                suma_C += Convert.ToDecimal(dr[5].ToString());//Iva_trasladado_calculado

            }
            DataRow row = ResultadoDIOT.NewRow();
            row[2] = "Total de DIOT:";
            row[3] = suma_A;
            row[4] = suma_B;
            row[5] = suma_C;
            row[6] = Mes;
            row[7] = Periodo;
            row[8] = IdEmpresa;

            ResultadoDIOT.Rows.Add(row);

            return ResultadoDIOT;

        }

        //Estep 3
        //Insert Register
        public void Register(string RFC, string Proveedor,
                                decimal Iva_trasladado, int Base, decimal Iva_Trasladado_Calculado,
                                string cnx, string IdEmpresa, string Mes, string Periodo)
        {
            SqlConnection conn = new SqlConnection(cnx);

            conn.Open();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO DIOT(RFC,PROVEEDOR, IVA_TRASLADADO, BASE,Iva_Trasladado_Calculado,IdEmpresa,MES, PERIODO)" +
                "VALUES(@RFC,@Proveedor, @Iva_trasladado, @Base,@Iva_Trasladado_Calculado,@IdEmpresa,@Mes, @Periodo) ", conn);
            cmdInsert.Parameters.AddWithValue("@RFC", RFC);
            cmdInsert.Parameters.AddWithValue("@Proveedor", Proveedor);
            cmdInsert.Parameters.AddWithValue("@Iva_trasladado", Iva_trasladado);
            cmdInsert.Parameters.AddWithValue("@Base", Base);
            cmdInsert.Parameters.AddWithValue("@Iva_Trasladado_Calculado", Iva_Trasladado_Calculado);
            cmdInsert.Parameters.AddWithValue("@IdEmpresa", IdEmpresa);
            cmdInsert.Parameters.AddWithValue("@Mes", Mes);
            cmdInsert.Parameters.AddWithValue("@Periodo", Periodo);

            cmdInsert.ExecuteNonQuery();
            conn.Close();





        }



        public int SearchMonthD(string v)
        {
            int month = 0;

            switch (v)
            {
                case "ENE":

                    month = 1;
                    break;
                case "FEB":
                    month = 2;
                    break;
                case "MAR":
                    month = 3;
                    break;
                case "ABR":
                    month = 4;
                    break;
                case "MAY":
                    month = 5;
                    break;
                case "JUN":
                    month = 6;
                    break;
                case "JUL":
                    month = 7;
                    break;
                case "AGO":
                    month = 8;
                    break;
                case "SEP":
                    month = 9;
                    break;
                case "OCT":
                    month = 10;
                    break;
                case "NOV":
                    month = 11;
                    break;
                case "DIC":
                    month = 12;
                    break;

                default:

                    break;


            }

            return month;
        }

        //Poliza excersise Start (Read table excersise facturas)
        public DataTable listExercise(string cnx, int año, int mes, int empresa, string tablaName)
        {
            SqlConnection conn = new SqlConnection(cnx);
            DataTable result = new DataTable();
            //CHARGE DATA 
            SqlCommand cmd = new SqlCommand("SELECT * FROM " + tablaName + " " +
                               "where realizada='2' and Ano='" + año + "' and Mes='" + mes + "' order by facturaId asc", conn);
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(result);

            }


            return result;
        }
    }
}
