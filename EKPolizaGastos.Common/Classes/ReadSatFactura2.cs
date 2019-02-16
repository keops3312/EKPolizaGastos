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
            SqlCommand cmd = new SqlCommand("select distinct(RFCEmisor)" +
                " from " + Tabla + " where Ano='"+ Periodo + "' and Mes='"+ mes + "' and Empresa='" + RFCEmpresa + "' order by RFCEmisor", conn);
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

            DataTable ResultadoDIOT = new DataTable("DIOT");
            ResultadoDIOT.Columns.Add("RFC_Emisor");
            ResultadoDIOT.Columns.Add("Proveedor_Emisor");
            ResultadoDIOT.Columns.Add("IVA_SIN_DECIMALES");
            ResultadoDIOT.Columns.Add("IVA_CON_DECIMALES");
            ResultadoDIOT.Columns.Add("BASE");
            ResultadoDIOT.Columns.Add("CONCEPTOS_NO_GRABAN_IVA");
            ResultadoDIOT.Columns.Add("IdEmpresa");
            ResultadoDIOT.Columns.Add("MES");
            ResultadoDIOT.Columns.Add("PERIODO");




         


            SqlConnection conn = new SqlConnection(cnx);
            //CREATE TABLE TO EXCEL FILE
            DataTable result = new DataTable();
            DataTable result2 = new DataTable();
            DataTable resultA = new DataTable();
            string RFC_Emisor;
            string Proveedor_Emisor;

            decimal Iva_trasladado; //NO redondeado
            int BaseR;//redondeado
            decimal BaseD;//NO redondeado
            decimal iva_calculado; //NO redondeado
            decimal RESULTADO; //NO redondeado
            decimal SubtotalBase;
            decimal subtotal;
            decimal descuento;
            decimal conceptoSinIva;
            //EGRESOS
            decimal EIva_trasladado; 
            decimal Eiva_calculado; 
            decimal EBaseD; 
            decimal EBaseR; 
            decimal Esubtotal;
            decimal Edescuento;
            decimal ESubtotalBase; 
            decimal ERESULTADO;
            decimal EconceptoSinIva;



            Mes = Convert.ToString(SearchMonthD(Mes));

            DataTable Existe = new DataTable();
            //compruebo si ya existe ejercicio y de lo contrario solo lo llamo
            //SqlCommand cmdExiste = new SqlCommand("select * from diot where mes='" + Mes + "' and periodo='" + Periodo + "' and " +
            //                      "IdEmpresa='" + IdEmpresa + "' order by Proveedor asc", conn);
            //using (SqlDataAdapter a = new SqlDataAdapter(cmdExiste))
            //{
            //    Existe.Clear();
            //    a.Fill(Existe);

            //}
       
            
            //Si no existe el ejercicio se realiza, de lo contrario solo lo llamo con la consulta
            if (Existe.Rows.Count == 0)
            {
                //CHARGE DATA DIOT
                foreach (DataRow item in proovedores.Rows)
                {

                    RFC_Emisor = item[0].ToString();

                    //Nombre Provedor
                    SqlCommand cmdPn = new SqlCommand("select NombreEmisor " +
                       " from " + Tabla + "" +
                       " where  RFCEmisor= '" + RFC_Emisor + "' and Ano='" + Periodo + "' and " +
                       " Mes='" + Mes + "'", conn);
                    using (SqlDataAdapter a = new SqlDataAdapter(cmdPn))
                    {
                        resultA.Clear();
                        a.Fill(resultA);
                        Proveedor_Emisor = resultA.Rows[0][0].ToString().Trim();
                    }

                    //Comprobantes tipo I
                    SqlCommand cmd = new SqlCommand("select sum(Convert(decimal(18,2),IVA)) as IVA," +
                        " sum(Convert(decimal(18,2),IVA)/ "+ base_Iva +") as Base, " +//- CONVERT(decimal(18, 2), Descuento)
                        " sum(Convert(decimal(18,2),SubTotal)) as Subtotal," +
                        " sum(Convert(decimal(18, 2), Descuento)) as Descuento, "+
                        " sum(Convert(decimal(18, 2), Total)) as Total " +
                        " from " + Tabla + "" +
                        " where TipoComprobante='I' and RFCEmisor= '" + RFC_Emisor + "' and Ano='" + Periodo +"' and " +
                        " Mes='" +  Mes + "'", conn);
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        result.Clear();
                        a.Fill(result);

                    }

                    if (result.Rows.Count > 0)
                    {
                        Iva_trasladado = decimal.Parse(result.Rows[0][0].ToString());
                        iva_calculado = (int)Math.Round(Convert.ToDouble(Iva_trasladado), 0, MidpointRounding.ToEven); //IVA REDONDEADO

                        BaseD = decimal.Parse(result.Rows[0][1].ToString()); //NO redondeado

                        BaseR = (int)Math.Round(Convert.ToDouble(BaseD), 0, MidpointRounding.ToEven);

                        subtotal = decimal.Parse(result.Rows[0][2].ToString());
                        descuento = decimal.Parse(result.Rows[0][3].ToString());

                        SubtotalBase = (int)Math.Round(Convert.ToDouble(subtotal), 0, MidpointRounding.ToEven);

                        RESULTADO = (int)Math.Round(Convert.ToDouble(subtotal - descuento), 0, MidpointRounding.ToEven);

                        conceptoSinIva = 0;

                        if (BaseR < SubtotalBase)
                        {
                            conceptoSinIva = RESULTADO - BaseR;//conceptos sin iva
                        }




                        ////resto sus notas de credito
                        //////AHORA LAS NOTAS DE CREDITO
                        ///
                        EIva_trasladado = 0;
                        Eiva_calculado = 0;
                        EBaseD = 0;
                        EBaseR = 0;
                        Esubtotal = 0;
                        Edescuento = 0;
                        ESubtotalBase = 0;
                        ERESULTADO = 0;
                        EconceptoSinIva = 0;
                        SqlCommand cmd2 = new SqlCommand("select sum(Convert(decimal(18,2),IVA)) as IVA," +
                            " sum(Convert(decimal(18,2),IVA)/ " + base_Iva + ") as Base, " +//- CONVERT(decimal(18, 2), Descuento)
                            " sum(Convert(decimal(18,2),SubTotal)) as Subtotal," +
                            " sum(Convert(decimal(18, 2), Descuento)) as Descuento, " +
                            " sum(Convert(decimal(18, 2), Total)) as Total " +
                            " from " + Tabla + "" +
                            " where TipoComprobante='E' and RFCEmisor= '" + RFC_Emisor + "' and Ano='" + Periodo + "' and " +
                            " Mes='" + Mes + "'", conn);
                        using (SqlDataAdapter a = new SqlDataAdapter(cmd2))
                        {
                            result2.Clear();
                            a.Fill(result2);
                            if (result2.Rows[0][0].ToString()!=string.Empty)
                            {
                                EIva_trasladado = decimal.Parse(result2.Rows[0][0].ToString());
                                Eiva_calculado = (int)Math.Round(Convert.ToDouble(EIva_trasladado), 0, MidpointRounding.ToEven); //IVA REDONDEADO

                                EBaseD = decimal.Parse(result2.Rows[0][1].ToString()); //NO redondeado

                                EBaseR = (int)Math.Round(Convert.ToDouble(EBaseD), 0, MidpointRounding.ToEven);

                                Esubtotal = decimal.Parse(result2.Rows[0][2].ToString());
                                Edescuento = decimal.Parse(result2.Rows[0][3].ToString());

                                ESubtotalBase = (int)Math.Round(Convert.ToDouble(Esubtotal), 0, MidpointRounding.ToEven);

                                ERESULTADO = (int)Math.Round(Convert.ToDouble(Esubtotal - Edescuento), 0, MidpointRounding.ToEven);

                                if (EBaseR < ESubtotalBase)
                                {
                                    EconceptoSinIva = ERESULTADO - EBaseR;//conceptos sin iva
                                }
                            }
                        }



                        ResultadoDIOT.Rows.Add(RFC_Emisor, Proveedor_Emisor, iva_calculado-Eiva_calculado,
                        Iva_trasladado-EIva_trasladado, BaseR-EBaseR, conceptoSinIva-EconceptoSinIva, IdEmpresa, Mes, Periodo);
                    }
                   




                 
                   



                    
                    
                    RFC_Emisor = string.Empty;
                    Proveedor_Emisor = string.Empty;


                }

            }

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
