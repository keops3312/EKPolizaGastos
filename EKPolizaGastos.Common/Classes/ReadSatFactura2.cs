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
           
            ResultadoDIOT.Columns.Add("IVA_RETENIDO");
            ResultadoDIOT.Columns.Add("ISR_RETENIDO");
            ResultadoDIOT.Columns.Add("CONCEPTOS_NO_GRABAN_IVA");


            ResultadoDIOT.Columns.Add("EGRESO_IVA_SIN_DECIMALES");
            ResultadoDIOT.Columns.Add("EGRESO_IVA_CON_DECIMALES");
            ResultadoDIOT.Columns.Add("EGRESO_BASE");

            ResultadoDIOT.Columns.Add("EGRESO_IVA_RETENIDO");
            ResultadoDIOT.Columns.Add("EGRESO_ISR_RETENIDO");
            ResultadoDIOT.Columns.Add("EGRESO_CONCEPTOS_NO_GRABAN_IVA");


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
            decimal total;
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

            //concepto nuevos
            decimal retenidoIva;
            decimal retenidoIsr;
            decimal IEPS;
            decimal EIEPS;
            decimal Etotal;
            decimal EretenidoIva;
            decimal EretenidoIsr;


            Mes = Convert.ToString(SearchMonthD(Mes));

            //CHARGE DATA DIOT
            foreach (DataRow item in proovedores.Rows)
            {

                Iva_trasladado = 0;
                iva_calculado = 0;
                BaseD = 0;
                BaseR = 0;
                subtotal = 0;
                descuento = 0;
                retenidoIva = 0;
                retenidoIsr = 0;
                IEPS = 0;
                total = 0;


                EIva_trasladado = 0;
                Eiva_calculado = 0;
                EBaseD = 0;
                EBaseR = 0;
                Esubtotal = 0;
                Edescuento = 0;
                EretenidoIva = 0;
                EretenidoIsr = 0;
                EIEPS = 0;
                Etotal = 0;

                RFC_Emisor = string.Empty;
                Proveedor_Emisor = string.Empty;


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



                if( RFC_Emisor.Equals("RUMM4612043H4") || 
                    RFC_Emisor.Equals("REME5202139N1") || 
                    RFC_Emisor.Equals("SIAM480401GF4") || 
                    RFC_Emisor.Equals("COTI4112249D3") || 
                    RFC_Emisor.Equals("GABL540419HA8") ||
                    RFC_Emisor.Equals("GAAJ6612125V6")
                   )
                {
                    //INGRESOS 
                    //Comprobantes tipo I
                    SqlCommand cmd = new SqlCommand("select sum(Convert(decimal(18,2),IVA)) as IVA," +
                        " sum(Convert(decimal(18,2),IVA)) as Base, " +//- CONVERT(decimal(18, 2), Descuento)
                        " sum(Convert(decimal(18,2),SubTotal)) as Subtotal," +
                        " sum(Convert(decimal(18, 2), Descuento)) as Descuento, " +
                        " sum(Convert(decimal(18, 2), Total)) as Total," +
                        " sum(Convert(decimal(18, 2),RetenidoIVA)) as retenidoIva," +
                        " sum(Convert(decimal(18, 2),RetenidoISR)) as retenidoIsr," +
                        " sum(Convert(decimal(18, 2),TotaLIEPS)) as IEPS " +
                        " from " + Tabla + " " +
                        " where TipoComprobante='I' and RFCEmisor='" + RFC_Emisor + "' and Ano='" + Periodo + "' and " +
                        " Mes='" + Mes + "'", conn);
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        result.Clear();
                        a.Fill(result);

                    }

                    //INGRESOS

                    if (!string.IsNullOrEmpty(result.Rows[0][0].ToString()))
                    {
                        Iva_trasladado = decimal.Parse(result.Rows[0][0].ToString());
                        iva_calculado = (int)Math.Round(Convert.ToDouble(Iva_trasladado), 0, MidpointRounding.ToEven); 

                        BaseD = decimal.Parse(result.Rows[0][2].ToString()); 
                        BaseR = (int)Math.Round(Convert.ToDouble(BaseD), 0, MidpointRounding.ToEven);

                        subtotal = decimal.Parse(result.Rows[0][2].ToString());
                        descuento = decimal.Parse(result.Rows[0][3].ToString());

                        retenidoIva = decimal.Parse(result.Rows[0][5].ToString());
                        retenidoIsr = decimal.Parse(result.Rows[0][6].ToString());
                        IEPS = decimal.Parse(result.Rows[0][7].ToString());
                        total = decimal.Parse(result.Rows[0][4].ToString());

                        decimal comprobar = 0;
                        decimal diferencia = 0;
                        double valor = 0.9533;
                        comprobar = subtotal * Convert.ToDecimal(valor);

                        diferencia = total - comprobar;
                        if(diferencia >= 1)
                        {
                            total = diferencia;
                        }
                        else
                        {
                            total = 0;
                        }




                        if (BaseR > 0 || iva_calculado > 0 || Iva_trasladado > 0 || retenidoIva > 0 || total > 0
                            || EBaseR > 0 || Eiva_calculado > 0 || EIva_trasladado > 0 || EretenidoIva > 0 || Etotal > 0)
                        {


                            ResultadoDIOT.Rows.Add(RFC_Emisor,
                                Proveedor_Emisor,
                            iva_calculado,
                            Iva_trasladado,
                            BaseR,
                            retenidoIva,
                            retenidoIsr,
                            (int)Math.Round(Convert.ToDouble(total), 0, MidpointRounding.ToEven),
                            Eiva_calculado,
                            EIva_trasladado,
                            EBaseR,
                            EretenidoIva,
                             EretenidoIsr,
                            (int)Math.Round(Convert.ToDouble(Etotal), 0, MidpointRounding.ToEven),
                             IdEmpresa,
                             Mes,
                             Periodo);
                        }



                    }

                }
                else
                {

                    //Comprobantes tipo I
                    SqlCommand cmd = new SqlCommand("select sum(Convert(decimal(18,2),IVA)) as IVA," +
                        " sum(Convert(decimal(18,2),IVA)/ " + base_Iva + ") as Base, " +//- CONVERT(decimal(18, 2), Descuento)
                        " sum(Convert(decimal(18,2),SubTotal)) as Subtotal," +
                        " sum(Convert(decimal(18, 2), Descuento)) as Descuento, " +
                        " sum(Convert(decimal(18, 2), Total)) as Total," +
                        " sum(Convert(decimal(18, 2),RetenidoIVA)) as retenidoIva," +
                        " sum(Convert(decimal(18, 2),RetenidoISR)) as retenidoIsr," +
                        " sum(Convert(decimal(18, 2),TotaLIEPS)) as IEPS " +
                        " from " + Tabla + " " +
                        " where TipoComprobante='I' and RFCEmisor='" + RFC_Emisor + "' and Ano='" + Periodo + "' and " +
                        " Mes='" + Mes + "'", conn);
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        result.Clear();
                        a.Fill(result);

                    }
                    //INGRESOS

                    if (!string.IsNullOrEmpty(result.Rows[0][0].ToString()))
                    {
                        Iva_trasladado = decimal.Parse(result.Rows[0][0].ToString());
                        iva_calculado = (int)Math.Round(Convert.ToDouble(Iva_trasladado), 0, MidpointRounding.ToEven); //IVA REDONDEADO

                        BaseD = decimal.Parse(result.Rows[0][1].ToString()); //NO redondeado
                        BaseR = (int)Math.Round(Convert.ToDouble(BaseD), 0, MidpointRounding.ToEven);

                        subtotal = decimal.Parse(result.Rows[0][2].ToString());
                        descuento = decimal.Parse(result.Rows[0][3].ToString());

                        retenidoIva = decimal.Parse(result.Rows[0][5].ToString());
                        retenidoIsr = decimal.Parse(result.Rows[0][6].ToString());
                        IEPS = decimal.Parse(result.Rows[0][7].ToString());

                        //conceptos sin iva
                        //total - iva -la base
                        total = decimal.Parse(result.Rows[0][4].ToString());
                        total = total - Iva_trasladado;


                        total = total - BaseD;//conceptos que no graban iva

                    }
                    //EGRESOS
                    SqlCommand cmd2 = new SqlCommand("select sum(Convert(decimal(18,2),IVA)) as IVA," +
                                    " sum(Convert(decimal(18,2),IVA)/ " + base_Iva + ") as Base, " +//- CONVERT(decimal(18, 2), Descuento)
                                    " sum(Convert(decimal(18,2),SubTotal)) as Subtotal," +
                                    " sum(Convert(decimal(18, 2), Descuento)) as Descuento, " +
                                    " sum(Convert(decimal(18, 2), Total)) as Total," +
                                    " sum(Convert(decimal(18, 2),RetenidoIVA)) as retenidoIva," +
                                    " sum(Convert(decimal(18, 2),RetenidoISR)) as retenidoIsr," +
                                    " sum(Convert(decimal(18, 2),TotaLIEPS)) as IEPS" +
                                    " from " + Tabla + "" +
                                    " where TipoComprobante='E' and RFCEmisor= '" + RFC_Emisor + "' and Ano='" + Periodo + "' and " +
                                    " Mes='" + Mes + "'", conn);
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd2))
                    {
                        result2.Clear();
                        a.Fill(result2);

                    }

                    if (!string.IsNullOrEmpty(result2.Rows[0][0].ToString()))
                    {
                        EIva_trasladado = decimal.Parse(result2.Rows[0][0].ToString());
                        Eiva_calculado = (int)Math.Round(Convert.ToDouble(EIva_trasladado), 0, MidpointRounding.ToEven); //IVA REDONDEADO

                        EBaseD = decimal.Parse(result2.Rows[0][1].ToString()); //NO redondeado

                        EBaseR = (int)Math.Round(Convert.ToDouble(EBaseD), 0, MidpointRounding.ToEven);

                        Esubtotal = decimal.Parse(result2.Rows[0][2].ToString());
                        Edescuento = decimal.Parse(result2.Rows[0][3].ToString());


                        EretenidoIva = decimal.Parse(result2.Rows[0][5].ToString());
                        EretenidoIsr = decimal.Parse(result2.Rows[0][6].ToString());
                        EIEPS = decimal.Parse(result2.Rows[0][7].ToString());

                        //conceptos sin iva
                        //total - iva -la base
                        Etotal = decimal.Parse(result2.Rows[0][4].ToString());
                        Etotal = Etotal - EIva_trasladado;


                        Etotal = Etotal - EBaseD;//conceptos que no graban iva

                    }



                    if (BaseR > 0 || iva_calculado > 0 || Iva_trasladado > 0 || retenidoIva > 0 || total > 0
                        || EBaseR > 0 || Eiva_calculado > 0 || EIva_trasladado > 0 || EretenidoIva > 0 || Etotal > 0)
                    {

                        if(total < 0 && RFC_Emisor.Equals("BBA830831LJ2"))/*ESTA ACTUALIZACION LO QUE HACE (EJEMPLO BANCOMER COMISIONES) NO SE INCLUYEN DENTRO DEL IVA SOLO APLICA HOY PARA BANCOMER*/
                        {
                            total = 0; //*-1 PARA CONVERTIR NEGATIVO A POSITIVO
                        }

                        ResultadoDIOT.Rows.Add(RFC_Emisor,
                            Proveedor_Emisor,
                        iva_calculado,
                        Iva_trasladado,
                        BaseR,
                        retenidoIva,
                        retenidoIsr,
                        (int)Math.Round(Convert.ToDouble(total), 0, MidpointRounding.ToEven),
                        Eiva_calculado,
                        EIva_trasladado,
                        EBaseR,
                        EretenidoIva,
                         EretenidoIsr,
                        (int)Math.Round(Convert.ToDouble(Etotal), 0, MidpointRounding.ToEven),
                         IdEmpresa,
                         Mes,
                         Periodo);
                    }


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
          
            //CHARGE ALL DATA 
            SqlCommand cmd = new SqlCommand("SELECT * FROM " + tablaName.Trim() + " " +
                               "where  Ano='" + año + "' and Mes='" + mes + "' order by facturaId, fechaEmision asc", conn);//realizada='2' and
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(result);

               
            }
            //1. agregar una columna vacia a result
            result.Columns.Add();
            //2. recorremos result y agregamos la ultima columna su numero real
            int i = 1;
            foreach (DataRow item in result.Rows)
            {
                item[67] = i;
                i++;
            }
            //3. ahora volvemos a recorrer y solo tomamos aquellso con status 2 que es no realizadas
            DataTable SinRealizar = new DataTable();
            SinRealizar.Columns.AddRange(new DataColumn[68]
             {
             new DataColumn("A1"),
             new DataColumn("A2"),
             new DataColumn("A3"),
             new DataColumn("A4"),
             new DataColumn("A5"),
             new DataColumn("A6"),
             new DataColumn("A7"),
             new DataColumn("A8"),
             new DataColumn("A9"),
             new DataColumn("A10"),
             new DataColumn("A11"),
             new DataColumn("A12"),
             new DataColumn("A13"),
             new DataColumn("A14"),
             new DataColumn("A15"),
             new DataColumn("A16"),
             new DataColumn("A17"),
             new DataColumn("A18"),
             new DataColumn("A19"),
             new DataColumn("A20"),
             new DataColumn("A21"),
             new DataColumn("A22"),
             new DataColumn("A23"),
             new DataColumn("A24"),
             new DataColumn("A25"),
             new DataColumn("A26"),
             new DataColumn("A27"),
             new DataColumn("A28"),
             new DataColumn("A29"),
             new DataColumn("A30"),
             new DataColumn("A31"),
             new DataColumn("A32"),
             new DataColumn("A33"),
             new DataColumn("A34"),
             new DataColumn("A35"),
             new DataColumn("A36"),
             new DataColumn("A37"),
             new DataColumn("A38"),
             new DataColumn("A39"),
             new DataColumn("A40"),
             new DataColumn("A41"),
             new DataColumn("A42"),
             new DataColumn("A43"),
             new DataColumn("A44"),
             new DataColumn("A45"),
             new DataColumn("A46"),
             new DataColumn("A47"),
             new DataColumn("A48"),
             new DataColumn("A49"),
             new DataColumn("A50"),
             new DataColumn("A51"),
             new DataColumn("A52"),
             new DataColumn("A53"),
             new DataColumn("A54"),
             new DataColumn("A55"),
             new DataColumn("A56"),
             new DataColumn("A57"),
             new DataColumn("A58"),
             new DataColumn("A59"),
             new DataColumn("A60"),
             new DataColumn("A61"),
             new DataColumn("A62"),
             new DataColumn("A63"),
             new DataColumn("A64"),
             new DataColumn("A65"),
             new DataColumn("A66"),
             new DataColumn("A67"),
             new DataColumn("A68")


         });

            DataRow[] resumen = result.Select("realizada='2'");


            for (int ii = 0; ii < resumen.Length; ii++)
            {
                SinRealizar.Rows.Add(resumen[ii][0],resumen[ii][1], resumen[ii][2], resumen[ii][3],
                    resumen[ii][4], resumen[ii][5], resumen[ii][6], resumen[ii][7], resumen[ii][8],
                    resumen[ii][9], resumen[ii][10], resumen[ii][11], resumen[ii][12], resumen[ii][13],
                    resumen[ii][14], resumen[ii][15], resumen[ii][16], resumen[ii][17], resumen[ii][18],
                    resumen[ii][19], resumen[ii][20], resumen[ii][21], resumen[ii][22], resumen[ii][23],
                    resumen[ii][24], resumen[ii][25], resumen[ii][26], resumen[ii][27], resumen[ii][28],
                    resumen[ii][29], resumen[ii][30], resumen[ii][31], resumen[ii][32], resumen[ii][33],
                    resumen[ii][34], resumen[ii][35], resumen[ii][36], resumen[ii][37], resumen[ii][38],
                    resumen[ii][39], resumen[ii][40], resumen[ii][41], resumen[ii][42], resumen[ii][43],
                    resumen[ii][44], resumen[ii][45], resumen[ii][46], resumen[ii][47], resumen[ii][48],
                    resumen[ii][49], resumen[ii][50], resumen[ii][51], resumen[ii][52], resumen[ii][53],
                    resumen[ii][54], resumen[ii][55], resumen[ii][56], resumen[ii][57], resumen[ii][58],
                    resumen[ii][59], resumen[ii][60], resumen[ii][61], resumen[ii][62], resumen[ii][63],
                    resumen[ii][64], resumen[ii][65], resumen[ii][66], resumen[ii][67]);
            }

            return SinRealizar;
           


        }
    }
}
