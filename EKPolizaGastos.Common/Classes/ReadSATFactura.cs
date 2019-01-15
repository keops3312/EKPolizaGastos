

namespace EKPolizaGastos.Common.Classes
{


    #region Libraries (Librerias) 
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Xml;
    using System.Xml.XPath;
    using ClosedXML.Excel;
    using EDsemp.Classes;
    #endregion
    public class ReadSATFactura
    {

        #region Attributes
        private string Serie;
        private string Folio;
        private string Fecha;
        private string Version;
        private string Sello;
        private string FormaPago;
        private string NoCertificado;
        private string MetodoPago;
        private string LugarExpedicion;
        private string schemaLocation;
        private string CondicionesDePago;
        private string SubTotal;
        private string Moneda;
        private string Total;
        private string TipoDeComprobante;
        private string Descuento;
        //Emisor Data

        private string Nombre;
        private string RegimenFiscal;
        private string Rfc;

        //Receptor Data
        private string NombreR;
        private string RfcR;
        private string UsoCFDI;

        //Taxes Data Translate

        //private decimal TotalImpuestosTrasladados;
        private string Importe;
        private string Impuesto;
        private string TasaOCuota;
        private string TipoFactor;


        //FiscalDigitalRing
        private string SelloCFD;
        private string NoCertificadoSAT;
        private string RfcProvCertif;
        private string UUID;
        private string FechaTimbrado;
        private string SelloSAT;
       // private string trasladados;

        //concepts to tax
        private string ClaveProdServ;
        private string NoIdentificacion;
        private string Cantidad ;
        private string ClaveUnidad ;
        private string Unidad ;
        private string Descripcion;
        private string ValorUnitario ;
        private string ImporteX ;
        private string DescuentoX;

        private string BaseTR;
        private string ImpuestoTR;
        private string TipoFactorTR;
        private string TasaOCuotaTR;
        private string ImporteTR;

        private string TotalImpuestosTrasladados;




        //
        private string sqlcnx, a, b, c, f;
        #endregion


        #region Methods

        public string CheckDataConection()
        {


            //aligual que las demas aplicaciones cargaremos nuestra llave al servidor de oficinas para la conexion directa
            string cadena = "C:/SEMP2013/EKPolizaGastos/EKPolizaGastos/cdb.txt";

            using (StreamReader sr1 = new StreamReader(cadena, true))
            {

                string lineA = sr1.ReadLine();
                string lineB = sr1.ReadLine();
                string lineC = sr1.ReadLine();
                string lineF = sr1.ReadLine();

                //ahroa desecrypto la informacion             
                a = Encriptar_Desencriptar.DecryptKeyMD5(lineA);
                b = Encriptar_Desencriptar.DecryptKeyMD5(lineB);
                c = Encriptar_Desencriptar.DecryptKeyMD5(lineC);
                f = Encriptar_Desencriptar.DecryptKeyMD5(lineF);
                //ahora realizo la conexion par amostrar las sucursales


                sqlcnx = "Data Source=" + a + " ;" +
                    "Initial Catalog=" + b + ";" +
                    "Persist Security Info=True;" +
                    "User ID=" + c + ";Password=" + f + "";
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = sqlcnx;
                conexion.Open();

                if (true)
                {
                    return sqlcnx;
                }




            }




        }


        public int Scan(string path, string cnx,string nameTable)//ruta carpeta descomprimida + conexion + el nombre de la tabla que es el nombre de la carpeta
        {
            int total;

            XmlDocument xDoc = new XmlDocument();


           

            string[] archivos = Directory.GetFiles(path, "*.XML");

            SqlConnection conn = new SqlConnection(cnx);
          
            //TRUNCATE TABLE
            conn.Open();
            SqlCommand command = new SqlCommand("SP_InsertFactura", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("opcion", 1);
            command.Parameters.AddWithValue("@msg", "2");
            command.Parameters.AddWithValue("@Capto", 2);
            command.ExecuteNonQuery();
            conn.Close();

          

            ////INSERT NEW REGISTRES
            foreach (var file in archivos)
            {
                xDoc.Load(file);

            

                XmlNodeList xFactura = xDoc.GetElementsByTagName("cfdi:Comprobante");//cfdi:comprobante
                XmlNodeList xEmisor = xDoc.GetElementsByTagName("cfdi:Emisor");
                XmlNodeList xReceptor = xDoc.GetElementsByTagName("cfdi:Receptor");
                XmlNodeList xCFDIComplemento = xDoc.GetElementsByTagName("tfd:TimbreFiscalDigital");
                XmlNodeList xTax = xDoc.GetElementsByTagName("cfdi:Traslado");
                XmlNodeList xConceptos = xDoc.GetElementsByTagName("cfdi:Concepto");//sin s



                foreach (XmlElement nodo in xFactura)
                {

                    Serie = string.Empty;
                    Folio = string.Empty;
                    Fecha = string.Empty;
                    Version = string.Empty;
                    Sello = string.Empty;
                    FormaPago = string.Empty;
                    NoCertificado = string.Empty;
                    MetodoPago = string.Empty;
                    LugarExpedicion = string.Empty;
                    schemaLocation = string.Empty;
                    CondicionesDePago = string.Empty;
                    SubTotal = string.Empty;
                    Moneda = string.Empty;
                    Total = string.Empty;
                    TipoDeComprobante = string.Empty;
                    Descuento = string.Empty;



                    Nombre = string.Empty;
                    RegimenFiscal = string.Empty;
                    Rfc = string.Empty;

                    NombreR = string.Empty;
                    UsoCFDI = string.Empty;
                    RfcR = string.Empty;

                    SelloCFD = string.Empty;
                    NoCertificadoSAT = string.Empty;
                    RfcProvCertif = string.Empty;
                    UUID = string.Empty;
                    FechaTimbrado = string.Empty;
                    SelloSAT = string.Empty;


                    Importe = string.Empty;
                    Impuesto = string.Empty;
                    TasaOCuota = string.Empty;
                    TipoFactor = string.Empty;

                    TotalImpuestosTrasladados = string.Empty;


                    Serie = nodo.GetAttribute("Serie");
                    Folio = nodo.GetAttribute("Folio");
                    Fecha = nodo.GetAttribute("Fecha");
                    Version = nodo.GetAttribute("Version");
                    Sello = nodo.GetAttribute("Sello");
                    FormaPago = nodo.GetAttribute("FormaPago");
                    NoCertificado = nodo.GetAttribute("NoCertificado");
                    MetodoPago = nodo.GetAttribute("MetodoPago");
                    LugarExpedicion = nodo.GetAttribute("LugarExpedicion");
                    schemaLocation = nodo.GetAttribute("xsi:schemaLocation");
                    CondicionesDePago = nodo.GetAttribute("CondicionesDePago");
                    SubTotal = nodo.GetAttribute("SubTotal");
                    Moneda = nodo.GetAttribute("Moneda");
                    Total = nodo.GetAttribute("Total");
                    TipoDeComprobante = nodo.GetAttribute("TipoDeComprobante");
                    Descuento = nodo.GetAttribute("Descuento");


                    //Taxes 
                    foreach (XmlElement nodoReceptor in xTax)
                    {

                        Importe = nodoReceptor.GetAttribute("Importe");
                        Impuesto = nodoReceptor.GetAttribute("Impuesto");
                        TasaOCuota = nodoReceptor.GetAttribute("TasaOCuota");
                        TipoFactor = nodoReceptor.GetAttribute("TipoFactor");


                        if (string.IsNullOrEmpty(Importe) || string.IsNullOrWhiteSpace(Importe))
                        {
                            Importe = "0";
                        }

                        if (string.IsNullOrEmpty(Impuesto) || string.IsNullOrWhiteSpace(Impuesto))
                        {
                            Impuesto = "0";
                        }
                        if (string.IsNullOrEmpty(TasaOCuota) || string.IsNullOrWhiteSpace(TasaOCuota))
                        {
                            TasaOCuota = "0";
                        }
                        if (string.IsNullOrEmpty(TipoFactor) || string.IsNullOrWhiteSpace(TipoFactor))
                        {
                            TipoFactor = "0";
                        }



                    }

                    //Emisor Data
                    foreach (XmlElement nodoEmisor in xEmisor)
                    {
                        Nombre = nodoEmisor.GetAttribute("Nombre");
                        RegimenFiscal = nodoEmisor.GetAttribute("RegimenFiscal");
                        Rfc = nodoEmisor.GetAttribute("Rfc");
                    }
                    //Receptor Data
                    foreach (XmlElement nodoReceptor in xReceptor)
                    {
                        NombreR = nodoReceptor.GetAttribute("Nombre");
                        UsoCFDI = nodoReceptor.GetAttribute("UsoCFDI");
                        RfcR = nodoReceptor.GetAttribute("Rfc");
                    }
                    //DigitalFiscal
                    foreach (XmlElement nodoReceptor in xCFDIComplemento)
                    {
                        SelloCFD = nodoReceptor.GetAttribute("SelloCFD");
                        NoCertificadoSAT = nodoReceptor.GetAttribute("NoCertificadoSAT");
                        RfcProvCertif = nodoReceptor.GetAttribute("RfcProvCertif");
                        UUID = nodoReceptor.GetAttribute("UUID");
                        FechaTimbrado = nodoReceptor.GetAttribute("FechaTimbrado");
                        SelloSAT = nodoReceptor.GetAttribute("SelloSAT");



                    }
                    //Taxes 
                    foreach (XmlElement nodoReceptor in xTax)
                    {

                        Importe = nodoReceptor.GetAttribute("Importe");
                        Impuesto = nodoReceptor.GetAttribute("Impuesto");
                        TasaOCuota = nodoReceptor.GetAttribute("TasaOCuota");
                        TipoFactor = nodoReceptor.GetAttribute("TipoFactor");


                        if (string.IsNullOrEmpty(Importe) || string.IsNullOrWhiteSpace(Importe))
                        {
                            Importe = "0";
                        }

                        if (string.IsNullOrEmpty(Impuesto) || string.IsNullOrWhiteSpace(Impuesto))
                        {
                            Impuesto = "0";
                        }
                        if (string.IsNullOrEmpty(TasaOCuota) || string.IsNullOrWhiteSpace(TasaOCuota))
                        {
                            TasaOCuota = "0";
                        }
                        if (string.IsNullOrEmpty(TipoFactor) || string.IsNullOrWhiteSpace(TipoFactor))
                        {
                            TipoFactor = "0";
                        }



                    }

                    InsertData(cnx);

                    foreach (XmlElement nodoReceptor in xConceptos)
                    {

                        ClaveProdServ = string.Empty;
                        NoIdentificacion = string.Empty;
                        Cantidad = string.Empty;
                        ClaveUnidad = string.Empty;
                        Unidad = string.Empty;
                        Descripcion = string.Empty;
                        ValorUnitario = string.Empty;
                        ImporteX = string.Empty;
                        DescuentoX = string.Empty;


                        ClaveProdServ = nodoReceptor.GetAttribute("ClaveProdServ");
                        NoIdentificacion = nodoReceptor.GetAttribute("NoIdentificacion");
                        Cantidad = nodoReceptor.GetAttribute("Cantidad");
                        ClaveUnidad = nodoReceptor.GetAttribute("ClaveUnidad");
                        Unidad = nodoReceptor.GetAttribute("Unidad");
                        Descripcion = nodoReceptor.GetAttribute("Descripcion");
                        ValorUnitario = nodoReceptor.GetAttribute("ValorUnitario");
                        ImporteX = nodoReceptor.GetAttribute("Importe");
                        DescuentoX = nodoReceptor.GetAttribute("Descuento");
                        //BaseTR = nodoReceptor.FirstChild.FirstChild["cfdi:Traslado"].GetAttribute("Base");


                        InserConcepts(cnx);
                    }
                   

                }
            }


            #region Crear Tabla
            conn.Open();
            SqlCommand commandCreate = new SqlCommand("USE SEMP_SAT " +
                              "SELECT * INTO BASE FROM COMPROBANTE", conn);
            commandCreate.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            SqlCommand commandRename = new SqlCommand("USE SEMP_SAT " +
                              "EXEC SP_RENAME 'BASE' , '" + nameTable + "'", conn);
            commandRename.ExecuteNonQuery();
            conn.Close();



            conn.Open();
            SqlCommand commandCreateC = new SqlCommand("USE SEMP_SAT " +
                              "SELECT * INTO BASE2 FROM COMPROBANTECONCEPTOS", conn);
            commandCreateC.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            SqlCommand commandRenameC = new SqlCommand("USE SEMP_SAT " +
                              "EXEC SP_RENAME 'BASE2' , '" + nameTable + "Conceptos'", conn);
            commandRenameC.ExecuteNonQuery();
            conn.Close();


            //CLON DE TABLE COMPROBANTES AND RETURN ROWS COPIED

            conn.Open();
            SqlCommand commandClear = new SqlCommand("SP_InsertFactura", conn);
            commandClear.CommandType = CommandType.StoredProcedure;
            commandClear.Parameters.AddWithValue("opcion", 3);
            commandClear.Parameters.AddWithValue("msg", "2");
            SqlParameter param = new SqlParameter("Capto", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            commandClear.Parameters.Add(param);

            commandClear.ExecuteNonQuery();
            total = int.Parse(param.Value.ToString());

            #endregion

            return total;
        }


        public int InsertProvedores(string cnx, string nameTable, string letra)
        {
            using (SqlConnection conn = new SqlConnection(cnx))
            {

                int EmpresaNO;
                string RFC_proveedor;
                int IdLocalidad;
                string Cuentas = "0000-000-000";
                string Titulo_principal;
                string Titulo_secundario;
                string Titulo_tercero;
                string Proveedor;
                string noProveedor;
                string noProveedor2;
                string Departamento = "0";


                DataTable Letra = new DataTable();
                DataTable Registros = new DataTable();
                DataTable RegistrosLocalidades = new DataTable();
                DataTable NoProvedor = new DataTable();
                DataTable Existe = new DataTable();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Empresas where Letra='" + letra + "'" +
                    " ", conn);
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(Letra);
                    EmpresaNO = int.Parse(Letra.Rows[0][0].ToString());
                }

                SqlCommand cmdC = new SqlCommand("SELECT Emisor, RFC_emisor FROM [" + nameTable + "]" +
                    "  ORDER BY IdFactura asc", conn);
                using (SqlDataAdapter a = new SqlDataAdapter(cmdC))
                {
                    a.Fill(Registros);

                }

                SqlCommand cmdD = new SqlCommand("SELECT * FROM Localidades " +
                   "  ORDER BY IdLocalidad asc", conn);
                using (SqlDataAdapter a = new SqlDataAdapter(cmdD))
                {
                    a.Fill(RegistrosLocalidades);

                }



                foreach(DataRow item in Registros.Rows)
                {
                    Proveedor = item["Emisor"].ToString();
                    RFC_proveedor =item["RFC_emisor"].ToString();


                    Titulo_principal = Proveedor + " " + RFC_proveedor; //proveedor a 40 caracteres + RFc
                    if (Proveedor.Length > 40)
                    {
                        Titulo_principal = Proveedor.Substring(0, 40) + " " + RFC_proveedor; //proveedor a 40 caracteres + RFc
                    }

                    
                    Titulo_secundario = "---";
                    Titulo_tercero = "---";

                    //check if exist Provedor
                    SqlCommand cmdExiste = new SqlCommand("SELECT RFC FROM Proveedores " +
                       " where RFC='"+ RFC_proveedor +"'", conn);
                    using (SqlDataAdapter a = new SqlDataAdapter(cmdExiste))
                    {
                        Existe.Clear();
                        a.Fill(Existe);

                    }

                   if(Existe.Rows.Count == 0)
                    {

                    foreach (DataRow itemC in RegistrosLocalidades.Rows)
                    {
                        IdLocalidad = int.Parse(itemC["IdLocalidad"].ToString());

                        conn.Open();
                        SqlCommand cmdInsert = new SqlCommand("Insert Into Proveedores(Proveedor,RFC,IdEmpresa," +
                            "IdLocalidad, Cuenta_cargo_1, Cuenta_cargo_2, Cuenta_cargo_3," +
                            " Cuenta_cargo_Iva, Cuenta_Abono_1,Cuenta_Abono_2,Cuenta_Abono_3" +
                            ",Titulo_principal,Titulo_secundario,Titulo_tercero,Departamento)values(@Proveedor,@RFC,@IdEmpresa," +
                            " @IdLocalidad, @Cuenta_cargo_1, @Cuenta_cargo_2, @Cuenta_cargo_3," +
                            " @Cuenta_cargo_Iva, @Cuenta_Abono_1, @Cuenta_Abono_2, @Cuenta_Abono_3" +
                            ",@Titulo_principal,@Titulo_secundario,@Titulo_tercero,@Departamento)", conn);
                        cmdInsert.Parameters.AddWithValue("@Proveedor", Proveedor);
                        cmdInsert.Parameters.AddWithValue("@RFC", RFC_proveedor);
                        cmdInsert.Parameters.AddWithValue("@IdEmpresa", EmpresaNO);
                        cmdInsert.Parameters.AddWithValue("@IdLocalidad", IdLocalidad);
                        cmdInsert.Parameters.AddWithValue("@Cuenta_cargo_1", Cuentas);
                        cmdInsert.Parameters.AddWithValue("@Cuenta_cargo_2", Cuentas);
                        cmdInsert.Parameters.AddWithValue("@Cuenta_cargo_3", Cuentas);
                        cmdInsert.Parameters.AddWithValue("@Cuenta_cargo_Iva", Cuentas);
                        cmdInsert.Parameters.AddWithValue("@Cuenta_Abono_1", Cuentas);
                        cmdInsert.Parameters.AddWithValue("@Cuenta_Abono_2", Cuentas);
                        cmdInsert.Parameters.AddWithValue("@Cuenta_Abono_3", Cuentas);
                        cmdInsert.Parameters.AddWithValue("@Titulo_principal", Titulo_principal);
                        cmdInsert.Parameters.AddWithValue("@Titulo_secundario", Titulo_secundario);
                        cmdInsert.Parameters.AddWithValue("@Titulo_tercero", Titulo_tercero);
                        cmdInsert.Parameters.AddWithValue("@Departamento", Departamento);

                        cmdInsert.ExecuteNonQuery();
                        conn.Close();



                            SqlCommand cmdNo = new SqlCommand("SELECT top(1) IdProveedor FROM Proveedores" +
                                                "  ORDER BY IdProveedor desc", conn);
                            using (SqlDataAdapter a = new SqlDataAdapter(cmdNo))
                            {
                                NoProvedor.Clear();
                                a.Fill(NoProvedor);
                                noProveedor = NoProvedor.Rows[0][0].ToString();
                                noProveedor2 = NoProvedor.Rows[0][0].ToString();

                                if (int.Parse(noProveedor) < 10)
                                {
                                    noProveedor = "00" + noProveedor;

                                }
                                else if (int.Parse(noProveedor) >= 10 && int.Parse(noProveedor) <= 99)
                                {

                                    noProveedor = "0" + noProveedor;
                                }

                             
                            }
                            conn.Open();
                            SqlCommand cmdUpdate = new SqlCommand("Update Proveedores Set NoProveedor='" + noProveedor + "' " +
                                " where IdProveedor='" + noProveedor2 + "'", conn);

                            cmdUpdate.ExecuteNonQuery();
                            conn.Close();



                        }

                   }

                    Proveedor = "";
                    RFC_proveedor = "";
                    Titulo_principal = "";
                    IdLocalidad = 0;





                }


        }



            //Emisor
            //    RFC_emisor
            //    IdEmpresa
            //    IdLocalidad
            //    Departamento



            return 1;


        }

        public void InsertData(string cnx)
        {

            using (SqlConnection conn = new SqlConnection(cnx))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SP_InsertFactura", conn);
                command.CommandType = CommandType.StoredProcedure;

                //SqlParameter paramCodRetorno = new SqlParameter("CodRetorno", SqlDbType.Int);
                //paramCodRetorno.Direction = ParameterDirection.Output;
                //command.Parameters.Add(paramCodRetorno);
                command.Parameters.AddWithValue("opcion", 2);
                command.Parameters.AddWithValue("Serie", Serie);
                command.Parameters.AddWithValue("Folio", Folio);
                command.Parameters.AddWithValue("Fecha", Fecha);
                command.Parameters.AddWithValue("Version", Version);
                command.Parameters.AddWithValue("Sello", Sello);
                command.Parameters.AddWithValue("FormaPago", FormaPago);
                command.Parameters.AddWithValue("NoCertificado", NoCertificado);
                command.Parameters.AddWithValue("MetodoPago", MetodoPago);
                command.Parameters.AddWithValue("LugarExpedicion", LugarExpedicion);
                command.Parameters.AddWithValue("schemaLocation", schemaLocation);
                command.Parameters.AddWithValue("CondicionesDePago", CondicionesDePago);
                command.Parameters.AddWithValue("SubTotal", SubTotal);
                command.Parameters.AddWithValue("Moneda", Moneda);
                command.Parameters.AddWithValue("Total", Total);
                command.Parameters.AddWithValue("TipoDeComprobante", TipoDeComprobante);
                command.Parameters.AddWithValue("Descuento", Descuento);


                command.Parameters.AddWithValue("Nombre", Nombre);
                command.Parameters.AddWithValue("RegimenFiscal", RegimenFiscal);
                command.Parameters.AddWithValue("Rfc", Rfc);


                command.Parameters.AddWithValue("NombreR", NombreR);
                command.Parameters.AddWithValue("RfcR", RfcR);
                command.Parameters.AddWithValue("UsoCFDI", UsoCFDI);




                command.Parameters.AddWithValue("Importe", Importe);//entes importe
                command.Parameters.AddWithValue("Impuesto", Impuesto);
                command.Parameters.AddWithValue("TasaOCuota", TasaOCuota);
                command.Parameters.AddWithValue("TipoFactor", TipoFactor);



                command.Parameters.AddWithValue("SelloCFD", SelloCFD);
                command.Parameters.AddWithValue("NoCertificadoSAT", NoCertificadoSAT);
                command.Parameters.AddWithValue("RfcProvCertif", RfcProvCertif);
                command.Parameters.AddWithValue("UUID", UUID);
                command.Parameters.AddWithValue("FechaTimbrado", FechaTimbrado);
                command.Parameters.AddWithValue("SelloSAT", SelloSAT);

                DateTime tiempo = DateTime.Parse(Fecha);
                string conv = tiempo.ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("FechaC", conv);

                command.Parameters.AddWithValue("@msg", "2");
                command.Parameters.AddWithValue("@Capto", 2);


               

               

                command.ExecuteNonQuery();

                //return Convert.ToInt32(command.Parameters["CodRetorno"].Value);
            }

           

        }

        public void InserConcepts(string cnx)
        {
            using (SqlConnection conn = new SqlConnection(cnx))
            {



                //search de las register
                DataTable lastRegister = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT top(1)* FROM Comprobante  ORDER BY IdFactura desc", conn);
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(lastRegister);

                }
                int indice = int.Parse(lastRegister.Rows[0][0].ToString());

                conn.Open();

                SqlCommand command = new SqlCommand("SP_InsertFactura", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("opcion", 4);
                command.Parameters.AddWithValue("ClaveProdServ", ClaveProdServ);
               // command.Parameters.AddWithValue("NoIdentificacion", NoIdentificacion);
                command.Parameters.AddWithValue("Cantidad", Cantidad);
                command.Parameters.AddWithValue("ClaveUnidad", ClaveUnidad);
                command.Parameters.AddWithValue("Unidad", Unidad);
                command.Parameters.AddWithValue("Descripcion", Descripcion);
                command.Parameters.AddWithValue("ValorUnitario", ValorUnitario);
                command.Parameters.AddWithValue("ImporteX", ImporteX);
                command.Parameters.AddWithValue("DescuentoX", DescuentoX);
                command.Parameters.AddWithValue("IdFactura",indice);

                command.Parameters.AddWithValue("BaseTR", "0.00");           
                command.Parameters.AddWithValue("ImpuestoTR", "0.00");
                command.Parameters.AddWithValue("TipoFactorTR", "0.00");
                command.Parameters.AddWithValue("TasaOCuotaTR", "0.00");           
                command.Parameters.AddWithValue("ImporteTR", "0.00");
                command.Parameters.AddWithValue("UUID", UUID);
                command.Parameters.AddWithValue("@msg", "2");
                command.Parameters.AddWithValue("@Capto", 2);

                command.ExecuteNonQuery();

                //return Convert.ToInt32(command.Parameters["CodRetorno"].Value);
            }

        }


        public void GeneratePrePoliza()
        {





        }

       public void ToExcel(string nameTable, string path,string cnx, string root)
       {

            SqlConnection conn = new SqlConnection(cnx);
            //CREATE TABLE TO EXCEL FILE
            DataTable excel = new DataTable(nameTable);
         
            //CHARGE DATA 
            SqlCommand cmd = new SqlCommand("SELECT * FROM  [" + nameTable + "]  ORDER BY IdFactura ASC", conn);
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(excel);

            }


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(excel);
                wb.SaveAs(path + "/" + nameTable + ".xlsx");

            }



            //CREATE TABLE TO EXCEL FILE Concepts
            DataTable excel2 = new DataTable(nameTable);

            //CHARGE DATA Concepts
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM  [" + nameTable + "Conceptos" + "]  ORDER BY IdFactura ASC", conn);
            using (SqlDataAdapter a = new SqlDataAdapter(cmd2))
            {
                a.Fill(excel2);

            }


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(excel2);
                wb.SaveAs(path + "/" + nameTable + "Conceptos.xlsx");

            }


            System.IO.Directory.Move(root + "/" + nameTable + ".zip", path + "/" + nameTable + ".zip");

        }



        public DataTable ToListDTB(string Letra,string cnx)
        {
           
            SqlConnection conn = new SqlConnection(cnx);
            //CREATE TABLE TO EXCEL FILE
            DataTable list = new DataTable();

            //CHARGE DATA 
            SqlCommand cmd = new SqlCommand("select name from sysobjects where type='U'" +
                                " and name like '%" + Letra  + "%' and name not like '%conceptos%'", conn);
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(list);

            }

         

            return list;
        }


        //Poliza excersise Start (Read table excersise facturas)
        public DataTable listExercise(string cnx,string ejercicio)
        {
            SqlConnection conn = new SqlConnection(cnx);
            DataTable result = new DataTable();
            //CHARGE DATA 
            SqlCommand cmd = new SqlCommand("SELECT * FROM [" + ejercicio + "] " +
                               "where IdEstatus='2' order by IdFactura asc", conn);
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(result);

            }


            return result;
        }

        public DataTable Localidades(string cnx)
        {
            SqlConnection conn = new SqlConnection(cnx);
            DataTable result = new DataTable();
            //CHARGE DATA 
            SqlCommand cmd = new SqlCommand("SELECT * FROM Localidades " +
                               " order by IdLocalidad asc", conn);
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(result);

            }



            return result;

        }












        public DataTable listExerciseDate(string cnx, string ejercicio, string Fecha)
        {
            SqlConnection conn = new SqlConnection(cnx);

           // DateTime Inicio = DateTime.Parse(Fecha).ToString("yyyy-MM-dd");
            DataTable result = new DataTable();
            //CHARGE DATA 
            SqlCommand cmd = new SqlCommand("SELECT   IdFactura,"+
                  "Fecha,"+
                    "FechaC,"+
                    "UUID,"+
                    "SubTotal,"+
                    "Importe,"+
                    "Total,"+
                    "RFC_emisor,"+
                    "Emisor,"+
                    "RFC_receptor,"+
                    "Receptor FROM [" + ejercicio + "] " +
                               " where FechaC=Convert(date,'" +  DateTime.Parse(Fecha).ToString("yyyy-MM-dd") + "')  " +
                               " OR  Fecha LIKE '%" + DateTime.Parse(Fecha).ToString("yyyy-MM-dd") + "%' order by IdFactura asc", conn);
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(result);

            }


            return result;
        }

        #endregion


    }
}
