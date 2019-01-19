using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EKPolizaGastos.Common.Classes
{
    public class ReadSatNominas
    {

        #region Attributes (atributos)
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


        public int Scan(string path, string cnx, string nameTable)//ruta carpeta descomprimida + conexion + el nombre de la tabla que es el nombre de la carpeta
        {
            int total;

            //Documento
            XmlDocument VarDocumentoXML = new XmlDocument();


            string[] archivos = Directory.GetFiles(path, "*.XML");

            SqlConnection conn = new SqlConnection(cnx);

            //TRUNCATE TABLE NOMINAS
            conn.Open();
            SqlCommand command = new SqlCommand("SP_InsertFactura", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("opcion", 5);
            command.Parameters.AddWithValue("@msg", "2");
            command.Parameters.AddWithValue("@Capto", 2);
            command.ExecuteNonQuery();
            conn.Close();



            ////INSERT NEW REGISTRES
            foreach (var file in archivos)
            {
                VarDocumentoXML.Load(path);

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

                XmlNodeList xConcepto = VarDocumentoXML.GetElementsByTagName("cfdi:Concepto");//cfdi:comprobante
                foreach (XmlElement nodo in xConcepto)
                {
                    ClaveProdServ = nodo.GetAttribute("ClaveProdServ");
                    Cantidad = nodo.GetAttribute("Cantidad");
                    CLaveUnidad = nodo.GetAttribute("ClaveUnidad");
                    Descripcion = nodo.GetAttribute("Descripcion");
                    ValorUnitario = nodo.GetAttribute("ValorUnitario");
                    Importe = nodo.GetAttribute("Importe");
                    Descuento = nodo.GetAttribute("Descuento");

                }



                string Impuestos;
                XmlDocument xmlImpuestos = new XmlDocument();
                Impuestos = string.Empty;

                XmlNodeList VarConceptos =
                       VarDocumentoXML.SelectNodes("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones", VarManager);


                XmlNodeList VarConceptos2 =
                     VarDocumentoXML.SelectNodes("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones", VarManager);


                int cuantos;
                cuantos = VarConceptos.Item(0).ChildNodes.Count;

                int cuantos2;
                cuantos2 = VarConceptos2.Item(0).ChildNodes.Count;



                try
                {
                    //Deducciones
                    for (int nodosHijos = 1; nodosHijos <= cuantos; nodosHijos++)
                    {

                        if (nodosHijos == 1)
                        {
                            D_Clave = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion/@Clave", VarManager).InnerText;
                            D_Concepto = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion/@Concepto", VarManager).InnerText;
                            D_Importe = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion/@Importe", VarManager).InnerText;
                            D_TipoDeduccion = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion/@TipoDeduccion", VarManager).InnerText;

                        }
                        else
                        {

                            D_Clave = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion[" + nodosHijos + "]/@Clave", VarManager).InnerText;
                            D_Concepto = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion[" + nodosHijos + "]/@Concepto", VarManager).InnerText;
                            D_Importe = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion[" + nodosHijos + "]/@Importe", VarManager).InnerText;
                            D_TipoDeduccion = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/" + Nomina + ":Deduccion[" + nodosHijos + "]/@TipoDeduccion", VarManager).InnerText;

                        }


                    }
                    //Percepciones
                    for (int nodosHijos2 = 1; nodosHijos2 <= cuantos2; nodosHijos2++)
                    {

                        if (nodosHijos2 == 1)
                        {
                            P_Clave = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion/@Clave", VarManager).InnerText;
                            P_Concepto = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion/@Concepto", VarManager).InnerText;
                            P_ImporteExento = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion/@ImporteExento", VarManager).InnerText;
                            P_ImporteGravado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion/@ImporteGravado", VarManager).InnerText;
                            P_TipoPercepcion = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion/@TipoPercepcion", VarManager).InnerText;
                        }
                        else
                        {


                            P_Clave = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion[" + nodosHijos2 + "]/@Clave", VarManager).InnerText;
                            P_Concepto = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion[" + nodosHijos2 + "]/@Concepto", VarManager).InnerText;
                            P_ImporteExento = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion[" + nodosHijos2 + "]/@ImporteExento", VarManager).InnerText;
                            P_ImporteGravado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion[" + nodosHijos2 + "]/@ImporteGravado", VarManager).InnerText;
                            P_TipoPercepcion = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/" + Nomina + ":Percepcion[" + nodosHijos2 + "]/@TipoPercepcion", VarManager).InnerText;
                        }


                    }




                }
                catch (Exception)
                {

                    throw;
                }



              


            }


            //#region Crear Tabla
            //conn.Open();
            //SqlCommand commandCreate = new SqlCommand("USE SEMP_SAT " +
            //                  "SELECT * INTO BASE FROM COMPROBANTE", conn);
            //commandCreate.ExecuteNonQuery();
            //conn.Close();

            //conn.Open();
            //SqlCommand commandRename = new SqlCommand("USE SEMP_SAT " +
            //                  "EXEC SP_RENAME 'BASE' , '" + nameTable + "'", conn);
            //commandRename.ExecuteNonQuery();
            //conn.Close();



            //conn.Open();
            //SqlCommand commandCreateC = new SqlCommand("USE SEMP_SAT " +
            //                  "SELECT * INTO BASE2 FROM COMPROBANTECONCEPTOS", conn);
            //commandCreateC.ExecuteNonQuery();
            //conn.Close();

            //conn.Open();
            //SqlCommand commandRenameC = new SqlCommand("USE SEMP_SAT " +
            //                  "EXEC SP_RENAME 'BASE2' , '" + nameTable + "Conceptos'", conn);
            //commandRenameC.ExecuteNonQuery();
            //conn.Close();


            ////CLON DE TABLE COMPROBANTES AND RETURN ROWS COPIED

            //conn.Open();
            //SqlCommand commandClear = new SqlCommand("SP_InsertFactura", conn);
            //commandClear.CommandType = CommandType.StoredProcedure;
            //commandClear.Parameters.AddWithValue("opcion", 3);
            //commandClear.Parameters.AddWithValue("msg", "2");
            //SqlParameter param = new SqlParameter("Capto", SqlDbType.Int);
            //param.Direction = ParameterDirection.Output;
            //commandClear.Parameters.Add(param);

            //commandClear.ExecuteNonQuery();
            //total = int.Parse(param.Value.ToString());

            //#endregion

            //return total;
        }


        //Inyecccion a la primera tabla
        public void InsertData(string cnx)
        {

            using (SqlConnection conn = new SqlConnection(cnx))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("SP_InsertFactura", conn);
                command.CommandType = CommandType.StoredProcedure;



                command.Parameters.AddWithValue("@Version", Version);//
                command.Parameters.AddWithValue("@Serie", Serie);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Serie", VarManager).InnerText;
                command.Parameters.AddWithValue("@Folio", Folio);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Folio", VarManager).InnerText;
                command.Parameters.AddWithValue("@Fecha", Fecha);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Fecha", VarManager).InnerText;
                command.Parameters.AddWithValue("@Sello", Sello);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Sello", VarManager).InnerText;
                command.Parameters.AddWithValue("@FormaPago", FormaPago);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@FormaPago", VarManager).InnerText;
                command.Parameters.AddWithValue("@NoCertificado", NoCertificado);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@NoCertificado", VarManager).InnerText;
                command.Parameters.AddWithValue("@Certificado", Certificado);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Certificado", VarManager).InnerText;
                command.Parameters.AddWithValue("@SubTotal", SubTotal);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@SubTotal", VarManager).InnerText;
                command.Parameters.AddWithValue("@Total", Total);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Total", VarManager).InnerText;
                command.Parameters.AddWithValue("@TipoDeComprobante", TipoDeComprobante);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@TipoDeComprobante", VarManager).InnerText;
                command.Parameters.AddWithValue("@MetodoPago", MetodoDePago);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@MetodoPago", VarManager).InnerText;
                command.Parameters.AddWithValue("@LugarExpedicion", LugarExpedicion);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@LugarExpedicion", VarManager).InnerText;

                command.Parameters.AddWithValue("@Descuento", DescuentoR);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Descuento", VarManager).InnerText;
                command.Parameters.AddWithValue("@Moneda", Moneda);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/@Moneda", VarManager).InnerText;


                command.Parameters.AddWithValue("@Emisor_Rfc", Emisor_Rfc);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Emisor/@Rfc", VarManager).InnerText;
                command.Parameters.AddWithValue("@Emisor_Nombre", Emisor_Nombre);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Emisor/@Nombre", VarManager).InnerText;
                command.Parameters.AddWithValue("@Emisor_RegimenFiscal", Emisor_RegimenFiscal);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Emisor/@RegimenFiscal", VarManager).InnerText;

                command.Parameters.AddWithValue("@Receptor_Rfc", Receptor_Rfc);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Receptor/@Rfc", VarManager).InnerText;
                command.Parameters.AddWithValue("@Receptor_Nombre", Receptor_Nombre);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Receptor/@Nombre", VarManager).InnerText;
                command.Parameters.AddWithValue("@Receptor_UsoCFDI", Receptor_UsoCFDI);// = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Receptor/@UsoCFDI", VarManager).InnerText;



                command.Parameters.AddWithValue("", FechaFinalPago = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@FechaFinalPago", VarManager).InnerText;
                command.Parameters.AddWithValue("", FechaInicialPago = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@FechaInicialPago", VarManager).InnerText;
                command.Parameters.AddWithValue("", FechaPago = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@FechaPago", VarManager).InnerText;
                command.Parameters.AddWithValue("", NumDiasPagados = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@NumDiasPagados", VarManager).InnerText;
                command.Parameters.AddWithValue("", TipoNomina = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@TipoNomina", VarManager).InnerText;
                command.Parameters.AddWithValue("", TotalDeducciones = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@TotalDeducciones", VarManager).InnerText;
                command.Parameters.AddWithValue("", TotalPercepciones = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@ TotalPercepciones", VarManager).InnerText;
                command.Parameters.AddWithValue("", Complemento_Version = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/@Version", VarManager).InnerText;

                command.Parameters.AddWithValue("", RegistroPatronal = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Emisor/@RegistroPatronal", VarManager).InnerText;

                command.Parameters.AddWithValue("", Antiguedad = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@Antigüedad", VarManager).InnerText;
                command.Parameters.AddWithValue("", Banco = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@Banco", VarManager).InnerText;
                command.Parameters.AddWithValue("", ClaveEntFed = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@ClaveEntFed", VarManager).InnerText;
                command.Parameters.AddWithValue("", CuentaBancaria = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@CuentaBancaria", VarManager).InnerText;
                command.Parameters.AddWithValue("", Curp = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@Curp", VarManager).InnerText;
                command.Parameters.AddWithValue("", Departamento = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@Departamento", VarManager).InnerText;
                command.Parameters.AddWithValue("", FechaInicioRelLaboral = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@FechaInicioRelLaboral", VarManager).InnerText;
                command.Parameters.AddWithValue("", NumEmpleado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@NumEmpleado", VarManager).InnerText;
                command.Parameters.AddWithValue("", NumSeguridadSocial = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@NumSeguridadSocial", VarManager).InnerText;
                command.Parameters.AddWithValue("", PeriodicidadPago = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@PeriodicidadPago", VarManager).InnerText;
                command.Parameters.AddWithValue("", Puesto = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@Puesto", VarManager).InnerText;
                command.Parameters.AddWithValue("", RiesgoPuesto = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@RiesgoPuesto", VarManager).InnerText;
                command.Parameters.AddWithValue("", SalarioBaseCotApor = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@SalarioBaseCotApor", VarManager).InnerText;
                command.Parameters.AddWithValue("", SalarioDiarioIntegrado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@SalarioDiarioIntegrado", VarManager).InnerText;
                command.Parameters.AddWithValue("", Sindicalizado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@Sindicalizado", VarManager).InnerText;
                command.Parameters.AddWithValue("", TipoContrato = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@TipoContrato", VarManager).InnerText;
                command.Parameters.AddWithValue("", TipoJornada = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@TipoJornada", VarManager).InnerText;
                command.Parameters.AddWithValue("", TipoRegimen = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Receptor/@TipoRegimen", VarManager).InnerText;


                command.Parameters.AddWithValue("", TotalExento = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/@TotalExento", VarManager).InnerText;
                command.Parameters.AddWithValue("", TotalGravado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/@TotalGravado", VarManager).InnerText;
                command.Parameters.AddWithValue("", TotalSueldos = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Percepciones/@TotalSueldos", VarManager).InnerText;



                command.Parameters.AddWithValue("", TotalImpuestosRetenidos = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/@TotalImpuestosRetenidos", VarManager).InnerText;
                command.Parameters.AddWithValue("", TotalOtrasDeducciones = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/" + Nomina + ":Nomina/" + Nomina + ":Deducciones/@TotalOtrasDeducciones", VarManager).InnerText;



                command.Parameters.AddWithValue("", T_RfcProvCertif = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@RfcProvCertif", VarManager).InnerText;
                command.Parameters.AddWithValue("", T_Version = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@Version", VarManager).InnerText;
                command.Parameters.AddWithValue("", UUID = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", VarManager).InnerText;
                command.Parameters.AddWithValue("", T_FechaTimbrado = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@FechaTimbrado", VarManager).InnerText;
                command.Parameters.AddWithValue("", T_SelloCFD = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloCFD", VarManager).InnerText;
                command.Parameters.AddWithValue("", NoCertificadoSAT = VarDocumentoXML.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@NoCertificadoSAT", VarManager).InnerText;









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


    }
}
