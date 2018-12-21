

namespace EKPolizaGastos.Common.Classes
{
    using EDsemp.Classes;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    public class ReadSATFactura
    {

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


        private string sqlcnx, a, b, c, f;

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


        public void Scan(string path,string cnx)
        {
            XmlDocument xDoc = new XmlDocument();

            string[] archivos = Directory.GetFiles(path, "*.XML");



            foreach (var file in archivos)
            {
                xDoc.Load(file);


                XmlNodeList xFactura = xDoc.GetElementsByTagName("cfdi:Comprobante");
                XmlNodeList xEmisor = xDoc.GetElementsByTagName("cfdi:Emisor");
                XmlNodeList xReceptor = xDoc.GetElementsByTagName("cfdi:Receptor");
                XmlNodeList xCFDIComplemento = xDoc.GetElementsByTagName("tfd:TimbreFiscalDigital");
                XmlNodeList xTax = xDoc.GetElementsByTagName("cfdi:Traslado");



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
                        TasaOCuota =nodoReceptor.GetAttribute("TasaOCuota");
                        TipoFactor = nodoReceptor.GetAttribute("TipoFactor");



                    }

                    //Insert Data
                    InsertData(cnx);

                }
            }



        }

        private void InsertData(string cnx)
        {
            using (SqlConnection conn = new SqlConnection(cnx))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SP_InsertFactura", conn);
                command.CommandType = CommandType.StoredProcedure;

                //SqlParameter paramCodRetorno = new SqlParameter("CodRetorno", SqlDbType.Int);
                //paramCodRetorno.Direction = ParameterDirection.Output;
                //command.Parameters.Add(paramCodRetorno);
                command.Parameters.AddWithValue("opcion", 1);
                command.Parameters.AddWithValue("Serie", Serie);
                command.Parameters.AddWithValue("Folio",Folio);
                command.Parameters.AddWithValue("Fecha",Fecha);
                command.Parameters.AddWithValue("Version",Version);
                command.Parameters.AddWithValue("Sello",Sello);
                command.Parameters.AddWithValue("FormaPago",FormaPago);
                command.Parameters.AddWithValue("NoCertificado",NoCertificado);
                command.Parameters.AddWithValue("MetodoPago",MetodoPago);
                command.Parameters.AddWithValue("LugarExpedicion",LugarExpedicion);
                command.Parameters.AddWithValue("schemaLocation",schemaLocation);
                command.Parameters.AddWithValue("CondicionesDePago",CondicionesDePago);
                command.Parameters.AddWithValue("SubTotal",SubTotal);
                command.Parameters.AddWithValue("Moneda",Moneda);
                command.Parameters.AddWithValue("Total",Total);
                command.Parameters.AddWithValue("TipoDeComprobante",TipoDeComprobante);
                command.Parameters.AddWithValue("Descuento",Descuento);


                command.Parameters.AddWithValue("Nombre",Nombre);
                command.Parameters.AddWithValue("RegimenFiscal",RegimenFiscal);
                command.Parameters.AddWithValue("Rfc",Rfc);


                command.Parameters.AddWithValue("NombreR",NombreR);
                command.Parameters.AddWithValue("RfcR",RfcR);
                command.Parameters.AddWithValue("UsoCFDI",UsoCFDI);




                command.Parameters.AddWithValue("Importe",Importe);
                command.Parameters.AddWithValue("Impuesto",Impuesto);
                command.Parameters.AddWithValue("TasaOCuota",TasaOCuota);
                command.Parameters.AddWithValue("TipoFactor",TipoFactor);



                command.Parameters.AddWithValue("SelloCFD",SelloCFD);
                command.Parameters.AddWithValue("NoCertificadoSAT",NoCertificadoSAT);
                command.Parameters.AddWithValue("RfcProvCertif",RfcProvCertif);
                command.Parameters.AddWithValue("UUID",UUID);
                command.Parameters.AddWithValue("FechaTimbrado",FechaTimbrado);
                command.Parameters.AddWithValue("SelloSAT",SelloSAT);
                command.Parameters.AddWithValue("@msg", "1");

                command.ExecuteNonQuery();

                //return Convert.ToInt32(command.Parameters["CodRetorno"].Value);
            }

        }



    }
}
