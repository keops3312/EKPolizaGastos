

namespace EKPolizaGastos.Common.Classes
{

    #region Libraries (Librerias)
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Xml;
    #endregion


    public class ReadSatNominas
    {

        #region Properties (Propiedades)
        //comprobante
        private string xsi_schemaLocation;
        private string Version;
        private string Serie;
        private string Folio;
        private string Fecha;
        private string Sello;
        private string FormaPago;
        private string NoCertificado;
        private string SubTotal;
        private string DescuentoR;
        private string Moneda;
        private string Total;
        private string TipoDeComprobante;
        private string MetodoDePago;
        private string LugarExpedicion;
        private string xmlns_cfdi;
        private string xmlns_xsi;
        private string xmlns_numero_nomina;//pendiente por tomar
        private string Certificado;
        private string Descuento;
        //emisor
        private string Emisor_Rfc;
        private string Emisor_Nombre;
        private string Emisor_RegimenFiscal;

        //receptor
        private string Receptor_Rfc;
        private string Receptor_Nombre;
        private string Receptor_UsoCFDI;

        //conceptos
        private string ClaveProdServ;
        private string Cantidad;
        private string CLaveUnidad;
        private string Descripcion;
        private string ValorUnitario;
        private string Importe;
        private string DescuentoC;

        //Complementos de nomina
        private string FechaFinalPago;
        private string FechaInicialPago;
        private string FechaPago;
        private string NumDiasPagados;
        private string TipoNomina;
        private string TotalDeducciones;
        private string TotalPercepciones;
        private string Complemento_Version;

        private string RegistroPatronal;

        //Nominal Receptor
        private string Antiguedad;
        private string Banco;
        private string ClaveEntFed;
        private string CuentaBancaria;
        private string Curp;
        private string Departamento;
        private string FechaInicioRelLaboral;
        private string NumEmpleado;
        private string NumSeguridadSocial;
        private string PeriodicidadPago;
        private string Puesto;
        private string RiesgoPuesto;
        private string SalarioBaseCotApor;
        private string SalarioDiarioIntegrado;
        private string Sindicalizado;
        private string TipoContrato;
        private string TipoJornada;
        private string TipoRegimen;

        //Total Percepciones
        private string TotalExento;
        private string TotalGravado;
        private string TotalSueldos;

        //Percepciones//para el for

        private string P_Clave;
        private string P_Concepto;
        private string P_ImporteExento;
        private string P_ImporteGravado;
        private string P_TipoPercepcion;


        //Total Deducciones
        private string TotalImpuestosRetenidos;
        private string TotalOtrasDeducciones;

        //Deduccion//para el for
        private string D_Clave;
        private string D_Concepto;
        private string D_Importe;
        private string D_TipoDeduccion;

        //TimbreFiscal
        private string T_RfcProvCertif;
        private string T_Version;
        private string UUID;
        private string T_FechaTimbrado;
        private string T_SelloCFD;
        private string NoCertificadoSAT;
        private string T_xsi_schemaLocation;
        private string T_xmlns_tfd;
        private string T_xmlns_xsi;

        #endregion


        #region Methods (Metodos)


        public DataTable ToListDTB(string Letra, string cnx)
        {

            SqlConnection conn = new SqlConnection(cnx);
            //CREATE TABLE TO EXCEL FILE
            DataTable list = new DataTable();

            //CHARGE DATA 
            SqlCommand cmd = new SqlCommand("select name from sysobjects where type='U'" +
                                " and name like '%" + Letra + "_EMI%' and name not like '%Percepciones%'" +
                                " and name not like '%Conceptos%'  and name not like '%Deducciones%'", conn);
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(list);

            }



            return list;
        }


        public int Scan(string path, string cnx, string nameTable)//ruta carpeta descomprimida + conexion + el nombre de la tabla que es el nombre de la carpeta
        {
            int total;

            //Documento
            XmlDocument VarDocumentoXML = new XmlDocument();


            string[] archivos = Directory.GetFiles(path, "*.XML");

            SqlConnection conn = new SqlConnection(cnx);

            //TRUNCATE TABLE NOMINAS
            conn.Open();
            SqlCommand command = new SqlCommand("SP_NominasInsert", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("opcion", 1);
            command.Parameters.AddWithValue("@msg", "2");
            command.Parameters.AddWithValue("@Capto", 2);
            command.ExecuteNonQuery();
            conn.Close();



            ////INSERT NEW REGISTRES
            foreach (var file in archivos)
            {
                VarDocumentoXML.Load(file);

                //Ruta
                //string file = @"T:\CFDIS_Emitidos\MRO\MRO_EMI_ABR2018\A9CD77F7-4C55-4905-BCB1-18FB53BD9385.xml";
                // VarDocumentoXML.Load(file);
                //Nombres de Espacio
                XmlNamespaceManager VarManager = new XmlNamespaceManager(VarDocumentoXML.NameTable);
                VarManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                VarManager.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
                VarManager.AddNamespace("implocal", "http://www.sat.gob.mx/implocal");
                VarManager.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
                VarManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");

               
                XmlNodeList xFacturaV = VarDocumentoXML.GetElementsByTagName("cfdi:Comprobante");//cfdi:comprobante
                foreach (XmlElement nodo in xFacturaV)
                {
                    Serie = nodo.GetAttribute("Serie");
                }

                    if (Serie.Equals("NOMINA"))
                    {

                    //Limpiar Variables
                    #region Limpiar variables
                    Version = string.Empty;
                    Serie = string.Empty;
                    Folio = string.Empty;
                    Fecha = string.Empty;
                    Sello = string.Empty;
                    FormaPago = string.Empty;
                    NoCertificado = string.Empty;
                    Certificado = string.Empty;
                    SubTotal = string.Empty;
                    Total = string.Empty;
                    TipoDeComprobante = string.Empty;
                    MetodoDePago = string.Empty;
                    LugarExpedicion = string.Empty;

                    DescuentoR = string.Empty;
                    Moneda = string.Empty;


                    Emisor_Rfc = string.Empty;
                    Emisor_Nombre = string.Empty;
                    Emisor_RegimenFiscal = string.Empty;

                    Receptor_Rfc = string.Empty;
                    Receptor_Nombre = string.Empty;
                    Receptor_UsoCFDI = string.Empty;



                    FechaFinalPago = string.Empty;
                    FechaInicialPago = string.Empty;
                    FechaPago = string.Empty;
                    NumDiasPagados = string.Empty;
                    TipoNomina = string.Empty;
                    TotalDeducciones = string.Empty;
                    TotalPercepciones = string.Empty;
                    Complemento_Version = string.Empty;

                    RegistroPatronal = string.Empty;

                    Antiguedad = string.Empty;
                    Banco = string.Empty;
                    ClaveEntFed = string.Empty;
                    CuentaBancaria = string.Empty;
                    Curp = string.Empty;
                    Departamento = string.Empty;
                    FechaInicioRelLaboral = string.Empty;
                    NumEmpleado = string.Empty;
                    NumSeguridadSocial = string.Empty;
                    PeriodicidadPago = string.Empty;
                    Puesto = string.Empty;
                    RiesgoPuesto = string.Empty;
                    SalarioBaseCotApor = string.Empty;
                    SalarioDiarioIntegrado = string.Empty;
                    Sindicalizado = string.Empty;
                    TipoContrato = string.Empty;
                    TipoJornada = string.Empty;
                    TipoRegimen = string.Empty;


                    TotalExento = string.Empty;
                    TotalGravado = string.Empty;
                    TotalSueldos = string.Empty;

                    TotalImpuestosRetenidos = string.Empty;
                    TotalOtrasDeducciones = string.Empty;

                    T_RfcProvCertif = string.Empty;
                    T_Version = string.Empty;
                    UUID = string.Empty;
                    T_FechaTimbrado = string.Empty;
                    T_SelloCFD = string.Empty;
                    NoCertificadoSAT = string.Empty;



                    #endregion



                    Version = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Version", VarManager).InnerText;
                    Serie = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Serie", VarManager).InnerText;
                    Folio = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Folio", VarManager).InnerText;
                    Fecha = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Fecha", VarManager).InnerText;
                    Sello = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Sello", VarManager).InnerText;
                    FormaPago = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@FormaPago", VarManager).InnerText;
                    NoCertificado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@NoCertificado", VarManager).InnerText;
                    Certificado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Certificado", VarManager).InnerText;
                    SubTotal = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@SubTotal", VarManager).InnerText;
                    Total = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Total", VarManager).InnerText;
                    TipoDeComprobante = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@TipoDeComprobante", VarManager).InnerText;
                    MetodoDePago = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@MetodoPago", VarManager).InnerText;
                    LugarExpedicion = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@LugarExpedicion", VarManager).InnerText;

                    string PathNomina = "";
                    string Nomina;
                    int i = 0;
                    XmlNodeList xFactura = VarDocumentoXML.GetElementsByTagName("cfdi:Comprobante");//cfdi:comprobante
                    foreach (XmlElement nodo in xFactura)
                    {
                        PathNomina = nodo.GetAttribute("xmlns:nomina" + i.ToString() + "");
                        for (i = 0; i < 100; i++)
                        {
                            if (PathNomina == "")
                            {
                                PathNomina = nodo.GetAttribute("xmlns:nomina" + i.ToString() + "");

                            }
                            else
                            {
                                i = i - 1;
                                break;
                            }
                        }

                    }
                    Nomina = "nomina" + i.ToString();
                    VarManager.AddNamespace("nomina" + i.ToString(), PathNomina);




                    DescuentoR = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Descuento", VarManager).InnerText;
                    Moneda = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Moneda", VarManager).InnerText;


                    Emisor_Rfc = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Emisor/@Rfc", VarManager).InnerText;
                    Emisor_Nombre = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Emisor/@Nombre", VarManager).InnerText;
                    Emisor_RegimenFiscal = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Emisor/@RegimenFiscal", VarManager).InnerText;

                    Receptor_Rfc = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Receptor/@Rfc", VarManager).InnerText;
                    Receptor_Nombre = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Receptor/@Nombre", VarManager).InnerText;
                    Receptor_UsoCFDI = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Receptor/@UsoCFDI", VarManager).InnerText;



                    FechaFinalPago = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@FechaFinalPago", VarManager).InnerText;
                    FechaInicialPago = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@FechaInicialPago", VarManager).InnerText;
                    FechaPago = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@FechaPago", VarManager).InnerText;
                    NumDiasPagados = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@NumDiasPagados", VarManager).InnerText;
                    TipoNomina = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@TipoNomina", VarManager).InnerText;
                    TotalDeducciones = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@TotalDeducciones", VarManager).InnerText;
                    TotalPercepciones = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@ TotalPercepciones", VarManager).InnerText;
                    Complemento_Version = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@Version", VarManager).InnerText;

                    RegistroPatronal = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Emisor/@RegistroPatronal", VarManager).InnerText;

                    Antiguedad = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@Antigüedad", VarManager).InnerText;
                    Banco = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@Banco", VarManager).InnerText;
                    ClaveEntFed = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@ClaveEntFed", VarManager).InnerText;
                    CuentaBancaria = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@CuentaBancaria", VarManager).InnerText;
                    Curp = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@Curp", VarManager).InnerText;
                    Departamento = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@Departamento", VarManager).InnerText;
                    FechaInicioRelLaboral = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@FechaInicioRelLaboral", VarManager).InnerText;
                    NumEmpleado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@NumEmpleado", VarManager).InnerText;
                    NumSeguridadSocial = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@NumSeguridadSocial", VarManager).InnerText;
                    PeriodicidadPago = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@PeriodicidadPago", VarManager).InnerText;
                    Puesto = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@Puesto", VarManager).InnerText;
                    RiesgoPuesto = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@RiesgoPuesto", VarManager).InnerText;
                    SalarioBaseCotApor = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@SalarioBaseCotApor", VarManager).InnerText;
                    SalarioDiarioIntegrado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@SalarioDiarioIntegrado", VarManager).InnerText;
                    Sindicalizado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@Sindicalizado", VarManager).InnerText;
                    TipoContrato = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@TipoContrato", VarManager).InnerText;
                    TipoJornada = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@TipoJornada", VarManager).InnerText;
                    TipoRegimen = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@TipoRegimen", VarManager).InnerText;


                    TotalExento = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/@TotalExento", VarManager).InnerText;
                    TotalGravado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/@TotalGravado", VarManager).InnerText;
                    TotalSueldos = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/@TotalSueldos", VarManager).InnerText;



                    TotalImpuestosRetenidos = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/@TotalImpuestosRetenidos", VarManager).InnerText;
                    TotalOtrasDeducciones = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/@TotalOtrasDeducciones", VarManager).InnerText;



                    T_RfcProvCertif = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@RfcProvCertif", VarManager).InnerText;
                    T_Version = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@Version", VarManager).InnerText;
                    UUID = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", VarManager).InnerText;
                    T_FechaTimbrado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@FechaTimbrado", VarManager).InnerText;
                    T_SelloCFD = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloCFD", VarManager).InnerText;
                    NoCertificadoSAT = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@NoCertificadoSAT", VarManager).InnerText;


                    //Inyeccion a Nominas


                    InsertData(cnx);




                    //ciclos para percepciones , deducciones y conceptos

                    //XmlNodeList xConcepto = VarDocumentoXML.GetElementsByTagName("cfdi:Concepto");//cfdi:comprobante
                    //foreach (XmlElement nodo in xConcepto)
                    //{
                    //    ClaveProdServ = string.Empty;
                    //    Cantidad = string.Empty;
                    //    CLaveUnidad = string.Empty;
                    //    Descripcion = string.Empty;
                    //    ValorUnitario = string.Empty;
                    //    Importe = string.Empty;
                    //    Descuento = string.Empty;



                    //    ClaveProdServ = nodo.GetAttribute("ClaveProdServ");
                    //    Cantidad = nodo.GetAttribute("Cantidad");
                    //    CLaveUnidad = nodo.GetAttribute("ClaveUnidad");
                    //    Descripcion = nodo.GetAttribute("Descripcion");
                    //    ValorUnitario = nodo.GetAttribute("ValorUnitario");
                    //    Importe = nodo.GetAttribute("Importe");
                    //    Descuento = nodo.GetAttribute("Descuento");


                    //    //Inyeccion a NominasConcepto
                    //    InsertDataConcept(cnx);


                    //}



                    //string Impuestos;
                    //XmlDocument xmlImpuestos = new XmlDocument();
                    //Impuestos = string.Empty;

                    //XmlNodeList VarConceptos =
                    //       VarDocumentoXML.SelectNodes("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones", VarManager);


                    //XmlNodeList VarConceptos2 =
                    //     VarDocumentoXML.SelectNodes("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones", VarManager);


                    //int cuantos;
                    //cuantos = VarConceptos.Item(0).ChildNodes.Count;

                    //int cuantos2;
                    //cuantos2 = VarConceptos2.Item(0).ChildNodes.Count;



                    //try
                    //{
                    //    //Deducciones
                    //    if (cuantos > 0)
                    //    {
                    //        for (int nodosHijos = 1; nodosHijos <= cuantos; nodosHijos++)
                    //        {
                    //            D_Clave = string.Empty;
                    //            D_Concepto = string.Empty;
                    //            D_Importe = string.Empty;
                    //            D_TipoDeduccion = string.Empty;

                    //            if (nodosHijos == 1)
                    //            {
                    //                D_Clave = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion/@Clave", VarManager).InnerText;
                    //                D_Concepto = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion/@Concepto", VarManager).InnerText;
                    //                D_Importe = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion/@Importe", VarManager).InnerText;
                    //                D_TipoDeduccion = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion/@TipoDeduccion", VarManager).InnerText;

                    //                InsertDataDeducciones(cnx);
                    //            }
                    //            else
                    //            {

                    //                D_Clave = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion[" + nodosHijos + "]/@Clave", VarManager).InnerText;
                    //                D_Concepto = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion[" + nodosHijos + "]/@Concepto", VarManager).InnerText;
                    //                D_Importe = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion[" + nodosHijos + "]/@Importe", VarManager).InnerText;
                    //                D_TipoDeduccion = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion[" + nodosHijos + "]/@TipoDeduccion", VarManager).InnerText;
                    //                InsertDataDeducciones(cnx);
                    //            }


                    //        }
                    //    }

                    //    //Percepciones
                    //    if (cuantos2 > 0)
                    //    {
                    //        for (int nodosHijos2 = 1; nodosHijos2 <= cuantos2; nodosHijos2++)
                    //        {
                    //            P_Clave = string.Empty;
                    //            P_Concepto = string.Empty;
                    //            P_ImporteExento = string.Empty;
                    //            P_ImporteGravado = string.Empty;
                    //            P_TipoPercepcion = string.Empty;

                    //            if (nodosHijos2 == 1)
                    //            {
                    //                P_Clave = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion/@Clave", VarManager).InnerText;
                    //                P_Concepto = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion/@Concepto", VarManager).InnerText;
                    //                P_ImporteExento = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion/@ImporteExento", VarManager).InnerText;
                    //                P_ImporteGravado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion/@ImporteGravado", VarManager).InnerText;
                    //                P_TipoPercepcion = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion/@TipoPercepcion", VarManager).InnerText;
                    //                InsertDataPercepciones(cnx);

                    //            }
                    //            else
                    //            {


                    //                P_Clave = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion[" + nodosHijos2 + "]/@Clave", VarManager).InnerText;
                    //                P_Concepto = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion[" + nodosHijos2 + "]/@Concepto", VarManager).InnerText;
                    //                P_ImporteExento = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion[" + nodosHijos2 + "]/@ImporteExento", VarManager).InnerText;
                    //                P_ImporteGravado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion[" + nodosHijos2 + "]/@ImporteGravado", VarManager).InnerText;
                    //                P_TipoPercepcion = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion[" + nodosHijos2 + "]/@TipoPercepcion", VarManager).InnerText;
                    //                InsertDataPercepciones(cnx);
                    //            }


                    //        }
                    //    }





                    //}
                    //catch (Exception)
                    //{

                    //    throw;
                    //}

                }

               


            }


            //#region Crear Tabla
            //conn.Open();
            //SqlCommand commandCreate = new SqlCommand("USE SEMP_SAT " +
            //                  "SELECT * INTO BASENominas FROM Nominas", conn);
            //commandCreate.ExecuteNonQuery();
            //conn.Close();

            //conn.Open();
            //SqlCommand commandRename = new SqlCommand("USE SEMP_SAT " +
            //                  "EXEC SP_RENAME 'BASENominas' , '" + nameTable + "'", conn);
            //commandRename.ExecuteNonQuery();
            //conn.Close();


            ////SE hace esto 3 veces para la tabla de deducciones, percepciones y conceptos de la nomina
            //conn.Open();
            //SqlCommand commandCreateC = new SqlCommand("USE SEMP_SAT " +
            //                  "SELECT * INTO BASENominasDecucciones FROM DeduccionesNominas", conn);
            //commandCreateC.ExecuteNonQuery();
            //conn.Close();

            //conn.Open();
            //SqlCommand commandRenameC = new SqlCommand("USE SEMP_SAT " +
            //                  "EXEC SP_RENAME 'BASENominasDeducciones' , '" + nameTable + "_Deducciones'", conn);
            //commandRenameC.ExecuteNonQuery();
            //conn.Close();
            ////
            //conn.Open();
            //SqlCommand commandCreateC2 = new SqlCommand("USE SEMP_SAT " +
            //                  "SELECT * INTO BASENominasPercepciones FROM PercepcionesNominas", conn);
            //commandCreateC2.ExecuteNonQuery();
            //conn.Close();

            //conn.Open();
            //SqlCommand commandRenameC3 = new SqlCommand("USE SEMP_SAT " +
            //                  "EXEC SP_RENAME 'BASENominasPercepciones' , '" + nameTable + "_Percepciones'", conn);
            //commandRenameC3.ExecuteNonQuery();
            //conn.Close();

            ////
            //conn.Open();
            //SqlCommand commandCreateC4 = new SqlCommand("USE SEMP_SAT " +
            //                  "SELECT * INTO BASENominasConceptos FROM ConceptosNominas", conn);
            //commandCreateC4.ExecuteNonQuery();
            //conn.Close();

            //conn.Open();
            //SqlCommand commandRenameC5 = new SqlCommand("USE SEMP_SAT " +
            //                  "EXEC SP_RENAME 'BASENominasConceptos' , '" + nameTable + "_Conceptos'", conn);
            //commandRenameC5.ExecuteNonQuery();
            //conn.Close();


            //////CLON DE TABLE COMPROBANTES AND RETURN ROWS COPIED

            //conn.Open();
            //SqlCommand commandClear = new SqlCommand("SP_NominasInsert", conn);
            //commandClear.CommandType = CommandType.StoredProcedure;
            //commandClear.Parameters.AddWithValue("opcion", 3);
            //commandClear.Parameters.AddWithValue("msg", "2");
            //SqlParameter param = new SqlParameter("Capto", SqlDbType.Int);
            //param.Direction = ParameterDirection.Output;
            //commandClear.Parameters.Add(param);

            //commandClear.ExecuteNonQuery();
            //total = int.Parse(param.Value.ToString());

            //#endregion

            return total=1;
        }

        private void InsertDataPercepciones(string cnx)
        {
            using (SqlConnection conn = new SqlConnection(cnx))
            {



                //search de las register
                DataTable lastRegister = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT top(1)* FROM Nomina  ORDER BY IdNomina desc", conn);
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(lastRegister);

                }
                int indice = int.Parse(lastRegister.Rows[0][0].ToString());

                conn.Open();

                SqlCommand command = new SqlCommand("SP_NominasInsert", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("opcion", 4);
                command.Parameters.AddWithValue("IdNomina", indice);

                command.Parameters.AddWithValue("UUID", UUID);
                command.Parameters.AddWithValue("NumEmpleado", NumEmpleado);

                DateTime tiempo = DateTime.Parse(Fecha);
                string conv = tiempo.ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("FechaConvert", conv);


                command.Parameters.AddWithValue("Clave", P_Clave);
                command.Parameters.AddWithValue("Concepto", P_Concepto);
                command.Parameters.AddWithValue("ImporteExento", P_ImporteExento);
                command.Parameters.AddWithValue("ImporteGravado", P_ImporteGravado);
                command.Parameters.AddWithValue("TipoPercepcion", P_TipoPercepcion);

                command.Parameters.AddWithValue("@msg", "2");
                command.Parameters.AddWithValue("@Capto", 2);

                command.ExecuteNonQuery();

                //return Convert.ToInt32(command.Parameters["CodRetorno"].Value);
            }
        }

        private void InsertDataDeducciones(string cnx)
        {
            using (SqlConnection conn = new SqlConnection(cnx))
            {



                //search de las register
                DataTable lastRegister = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT top(1)* FROM Nomina  ORDER BY IdNomina desc", conn);
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(lastRegister);

                }
                int indice = int.Parse(lastRegister.Rows[0][0].ToString());

                conn.Open();

                SqlCommand command = new SqlCommand("SP_NominasInsert", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("opcion", 5);
                command.Parameters.AddWithValue("IdNomina", indice);

                command.Parameters.AddWithValue("UUID", UUID);
                command.Parameters.AddWithValue("NumEmpleado", NumEmpleado);

                DateTime tiempo = DateTime.Parse(Fecha);
                string conv = tiempo.ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("FechaConvert", conv);


                command.Parameters.AddWithValue("Clave", D_Clave);
                command.Parameters.AddWithValue("Concepto", D_Concepto);
                command.Parameters.AddWithValue("Importe", D_Importe);
                command.Parameters.AddWithValue("TipoDeduccion", D_TipoDeduccion);

                command.Parameters.AddWithValue("@msg", "2");
                command.Parameters.AddWithValue("@Capto", 2);

                command.ExecuteNonQuery();

                //return Convert.ToInt32(command.Parameters["CodRetorno"].Value);
            }
        }

        //Registro de Conceptos de Nomina
        private void InsertDataConcept(string cnx)
        {
            using (SqlConnection conn = new SqlConnection(cnx))
            {



                //search de las register
                DataTable lastRegister = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT top(1)* FROM Nomina  ORDER BY IdNomina desc", conn);
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(lastRegister);

                }
                int indice = int.Parse(lastRegister.Rows[0][0].ToString());

                conn.Open();

                SqlCommand command = new SqlCommand("SP_NominasInsert", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("opcion", 5);
                command.Parameters.AddWithValue("IdNomina", indice);

                command.Parameters.AddWithValue("UUID", UUID);
                command.Parameters.AddWithValue("NumEmpleado", NumEmpleado);

                DateTime tiempo = DateTime.Parse(Fecha);
                string conv = tiempo.ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("FechaConvert", conv);


                command.Parameters.AddWithValue("ClaveProdServ", ClaveProdServ);
                command.Parameters.AddWithValue("Cantidad", Cantidad);
                command.Parameters.AddWithValue("ClaveUnidad", CLaveUnidad);
                command.Parameters.AddWithValue("Descripcion", Descripcion);
                command.Parameters.AddWithValue("ValorUnitario", ValorUnitario);
                command.Parameters.AddWithValue("Importe", Importe);
                command.Parameters.AddWithValue("Descuento", Descuento);

                command.Parameters.AddWithValue("@msg", "2");
                command.Parameters.AddWithValue("@Capto", 2);

                command.ExecuteNonQuery();



                //return Convert.ToInt32(command.Parameters["CodRetorno"].Value);
            }
        }


        //Inyeccion a la primera tabla
        private void InsertData(string cnx)
        {
            try
            {
                //using (SqlConnection conn = new SqlConnection(cnx))
                //{


                SqlConnection conn = new SqlConnection(cnx);

                conn.Open();
                SqlCommand command = new SqlCommand("SP_NominasInsert", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("opcion", 2);
                command.Parameters.AddWithValue("msg", "2");
                command.Parameters.AddWithValue("Capto", 2);
                command.Parameters.AddWithValue("Version", Version);//
                command.Parameters.AddWithValue("Serie", Serie);//  
                command.Parameters.AddWithValue("Folio", Folio);// 
                command.Parameters.AddWithValue("Fecha", Fecha);// 
                command.Parameters.AddWithValue("Sello", Sello);// 
                //command.Parameters.AddWithValue("FormaPago", FormaPago);//
                //command.Parameters.AddWithValue("NoCertificado", NoCertificado);//
                //command.Parameters.AddWithValue("Certificado", Certificado);// 
                //command.Parameters.AddWithValue("SubTotal", SubTotal);// 
                //command.Parameters.AddWithValue("Total", Total);// 
                //command.Parameters.AddWithValue("TipoDeComprobante", TipoDeComprobante);//
                //command.Parameters.AddWithValue("MetodoPago", MetodoDePago);//
                //command.Parameters.AddWithValue("LugarExpedicion", LugarExpedicion);//
                //command.Parameters.AddWithValue("Descuento", DescuentoR);// 
                //command.Parameters.AddWithValue("Moneda", Moneda);// 
                //command.Parameters.AddWithValue("[Emisor_Rfc]", Emisor_Rfc);//
                //command.Parameters.AddWithValue("[Emisor_Nombre]", Emisor_Nombre);//[]
                //command.Parameters.AddWithValue("[Emisor_RegimenFiscal]", Emisor_RegimenFiscal);//
                //command.Parameters.AddWithValue("[Receptor_Rfc]", Receptor_Rfc);// 
                //command.Parameters.AddWithValue("[Receptor_Nombre]", Receptor_Nombre);//
                //command.Parameters.AddWithValue("[Receptor_UsoCFDI]", Receptor_UsoCFDI);// 
                //command.Parameters.AddWithValue("FechaFinalPago", FechaFinalPago);//
                //command.Parameters.AddWithValue("FechaInicialPago", FechaInicialPago);// 
                //command.Parameters.AddWithValue("FechaPago", FechaPago);// 
                //command.Parameters.AddWithValue("NumDiasPagados", NumDiasPagados);// 
                //command.Parameters.AddWithValue("TipoNomina", TipoNomina);// 
                //command.Parameters.AddWithValue("TotalDeducciones", TotalDeducciones);// 
                //command.Parameters.AddWithValue("TotalPercepciones", TotalPercepciones);// 
                //command.Parameters.AddWithValue("[Complemento_Version]", Complemento_Version);//
                //command.Parameters.AddWithValue("RegistroPatronal", RegistroPatronal);//
                //command.Parameters.AddWithValue("Antiguedad", Antiguedad);//
                //command.Parameters.AddWithValue("Banco", Banco);// 
                //command.Parameters.AddWithValue("ClaveEntFed", ClaveEntFed);//
                //command.Parameters.AddWithValue("CuentaBancaria", CuentaBancaria);//
                //command.Parameters.AddWithValue("Curp", Curp);//
                //command.Parameters.AddWithValue("Departamento", Departamento);//
                //command.Parameters.AddWithValue("FechaInicioRelLaboral", FechaInicioRelLaboral);//
                //command.Parameters.AddWithValue("NumEmpleado", NumEmpleado);// 
                //command.Parameters.AddWithValue("NumSeguridadSocial", NumSeguridadSocial);//
                //command.Parameters.AddWithValue("PeriodicidadPago", PeriodicidadPago);//
                //command.Parameters.AddWithValue("Puesto", Puesto);// 
                //command.Parameters.AddWithValue("RiesgoPuesto", RiesgoPuesto);//
                //command.Parameters.AddWithValue("SalarioBaseCotApor", SalarioBaseCotApor);// 
                //command.Parameters.AddWithValue("SalarioDiarioIntegrado", SalarioDiarioIntegrado);// 
                //command.Parameters.AddWithValue("Sindicalizado", Sindicalizado);//
                //command.Parameters.AddWithValue("TipoContrato", TipoContrato);//
                //command.Parameters.AddWithValue("TipoJornada", TipoJornada);//
                //command.Parameters.AddWithValue("TipoRegimen", TipoRegimen);//
                //command.Parameters.AddWithValue("TotalExento", TotalExento);//
                //command.Parameters.AddWithValue("TotalGravado", TotalGravado);//
                //command.Parameters.AddWithValue("TotalSueldos", TotalSueldos);//
                //command.Parameters.AddWithValue("TotalImpuestosRetenidos", TotalImpuestosRetenidos);//
                //command.Parameters.AddWithValue("TotalOtrasDeducciones", TotalOtrasDeducciones);//
                //command.Parameters.AddWithValue("[T_RfcProvCertif]", T_RfcProvCertif);//
                //command.Parameters.AddWithValue("[T_Version]", T_Version);//
                //command.Parameters.AddWithValue("UUID", UUID);//
                //command.Parameters.AddWithValue("[T_FechaTimbrado]", T_FechaTimbrado);//
                //command.Parameters.AddWithValue("[T_SelloCFD]", T_SelloCFD);//
                //command.Parameters.AddWithValue("NoCertificadoSAT", NoCertificadoSAT);// 
                //command.Parameters.AddWithValue("EstatusNomina", 2);// 
                //DateTime tiempo = DateTime.Parse(Fecha);
                //string conv = tiempo.ToString("yyyy-MM-dd");
                //command.Parameters.AddWithValue("FechaConvert", conv);

                command.ExecuteNonQuery();
                conn.Close();

                //return Convert.ToInt32(command.Parameters["CodRetorno"].Value);
                //}
            }
            catch (Exception ex)
            {

                Console.Write("Error AQUI:" + ex.Message);
            }
          

        } 
        #endregion


    }
}
