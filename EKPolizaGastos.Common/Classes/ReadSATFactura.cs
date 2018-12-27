

namespace EKPolizaGastos.Common.Classes
{

    #region Libraries (Librerias)  
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Xml;
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

        //concepts to tax
        private string ClaveProdServ;
        private string NoIdentificacion;
        private string Cantidad ;
        private string ClaveUnidad ;
        private string Unidad ;
        private string Descripcion;
        private string ValorUnitario ;
        private string ImporteX ;

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


                XmlNodeList xFactura = xDoc.GetElementsByTagName("cfdi:Comprobante");
                XmlNodeList xEmisor = xDoc.GetElementsByTagName("cfdi:Emisor");
                XmlNodeList xReceptor = xDoc.GetElementsByTagName("cfdi:Receptor");
                XmlNodeList xCFDIComplemento = xDoc.GetElementsByTagName("tfd:TimbreFiscalDigital");
                XmlNodeList xTax = xDoc.GetElementsByTagName("cfdi:Traslado");
                XmlNodeList xConceptos = xDoc.GetElementsByTagName("cfdi:Concepto");



                foreach (XmlElement nodo in xFactura)
                {



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



                    }
                    InsertData(cnx);

                    foreach (XmlElement nodoReceptor in xConceptos)
                    {
                        ClaveProdServ = nodoReceptor.GetAttribute("ClaveProdServ");
                        NoIdentificacion = nodoReceptor.GetAttribute("NoIdentificacion");
                        Cantidad = nodoReceptor.GetAttribute("Cantidad");
                        ClaveUnidad = nodoReceptor.GetAttribute("ClaveUnidad");
                        Unidad = nodoReceptor.GetAttribute("Unidad");
                        Descripcion = nodoReceptor.GetAttribute("Descripcion");
                        ValorUnitario = nodoReceptor.GetAttribute("ValorUnitario");
                        ImporteX = nodoReceptor.GetAttribute("ImporteX");
                        InserConcepts(cnx);
                    }
                    //Insert Data
                    

                }
            }


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

            ////CLON DE TABLE COMPROBANTES AND RETURN ROWS COPIED

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
            //conn.Close();
          
            return total;
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




                command.Parameters.AddWithValue("Importe", Importe);
                command.Parameters.AddWithValue("Impuesto", Impuesto);
                command.Parameters.AddWithValue("TasaOCuota", TasaOCuota);
                command.Parameters.AddWithValue("TipoFactor", TipoFactor);



                command.Parameters.AddWithValue("SelloCFD", SelloCFD);
                command.Parameters.AddWithValue("NoCertificadoSAT", NoCertificadoSAT);
                command.Parameters.AddWithValue("RfcProvCertif", RfcProvCertif);
                command.Parameters.AddWithValue("UUID", UUID);
                command.Parameters.AddWithValue("FechaTimbrado", FechaTimbrado);
                command.Parameters.AddWithValue("SelloSAT", SelloSAT);

             

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
                conn.Open();

                SqlCommand command = new SqlCommand("SP_InsertFactura", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("opcion", 4);
                command.Parameters.AddWithValue("ClaveProdServ", ClaveProdServ);
                command.Parameters.AddWithValue("NoIdentificacion", NoIdentificacion);
                command.Parameters.AddWithValue("Cantidad", Cantidad);
                command.Parameters.AddWithValue("ClaveUnidad", ClaveUnidad);
                command.Parameters.AddWithValue("Unidad", Unidad);
                command.Parameters.AddWithValue("Descripcion", Descripcion);
                command.Parameters.AddWithValue("ValorUnitario", ValorUnitario);
                command.Parameters.AddWithValue("ImporteX", ImporteX);

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


            System.IO.Directory.Move(root + "/" + nameTable + ".zip", path + "/" + nameTable + ".zip");

        }

        #endregion


    }
}
