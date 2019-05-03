

namespace EKPolizaGastos.Forms
{
    using DevComponents.DotNetBar;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using EKPolizaGastos.Common.Classes;
    using EKPolizaGastos.Context;
    using System;
    using System.Data.Entity;

    public partial class ExcelForm : DevComponents.DotNetBar.Office2007Form
    {

        #region Context
        private SEMP_SATContext db;
        private ReadSatFactura2 readSatFactura2;
        #endregion

        private string letra;
        private string pathDefaultL;


        public ExcelForm()
        {
            db = new SEMP_SATContext();
            readSatFactura2 = new ReadSatFactura2();
            InitializeComponent();

        }

        private void LoadCompanies()
        {

            cmbEmpresa.DataSource = db.Empresas.ToList();
            cmbEmpresa.DisplayMember = "Empresa";
            cmbEmpresa.ValueMember = "Letra";

        }


        private void LoadCompaniesProperties()
        {


            letra = cmbEmpresa.SelectedValue.ToString();

            DataTable list = new DataTable();
            //Lista de Bases de datos de Gastos
            if (swtBtn.Value == true)
            {
                var pathDefault = db.Empresas.Where(p => p.Letra == cmbEmpresa.SelectedValue.ToString()).FirstOrDefault();
                pathDefaultL = pathDefault.Path;
            }
            //Lista de Base de Tabla Facturas Emitidas
            else
            {
                var pathDefault = db.Empresas.Where(p => p.Letra == cmbEmpresa.SelectedValue.ToString()).FirstOrDefault();

                pathDefaultL = pathDefault.PathNomina;
            }


            return;



        }


        private void InsertarRegistros()
        {
            int periodo;
            int mes;
            int dia;

          

            var empresa = db.Empresas.Where(p => p.Letra == letra.Trim()).FirstOrDefault();

            if (letra.Trim() == "CIS")
            {
                


                //Ingreso a base de datos
                foreach (DataGridViewRow row in gridMuestra.Rows)
                {

                    DateTime FechaRaiz = DateTime.Parse(row.Cells[04].ToString());

                    periodo = FechaRaiz.Year;
                    mes = FechaRaiz.Month;
                    dia = FechaRaiz.Day;



                    //periodo = int.Parse(row.Cells[10].Value.ToString());//ANO
                    //mes = int.Parse(row.Cells[11].Value.ToString());//MES
                    //dia = int.Parse(row.Cells[12].Value.ToString());//DIA


                    letra = cmbEmpresa.SelectedValue.ToString();






                    if (swtBtn.Value == true)
                    {


                        CISFACTRECIBIDAS cISFACTRECIBIDAS =
                   new CISFACTRECIBIDAS
                   {

                       Verificado = row.Cells[0].Value.ToString(),//
                       EstadoSat = row.Cells[1].Value.ToString(),//
                       EstadoValidacion = ".",//row.Cells[2].Value.ToString(),
                       NoCertificadoEmisor =".",// row.Cells[3].Value.ToString(),
                       NoCertificadoSAT = ".",//row.Cells[4].Value.ToString(),
                       Version = row.Cells[2].Value.ToString(),
                       TipoComprobante = ".",
                       Tipo = row.Cells[3].Value.ToString(),
                       FechaEmision = DateTime.Parse(row.Cells[4].Value.ToString()),
                       FechaTimbrado = row.Cells[5].Value.ToString(),
                       Ano = periodo,
                       Mes = mes,
                       Dia = dia,                 
                       EstadoPago =".",// row.Cells[13].Value.ToString(),
                       Serie = row.Cells[8].Value.ToString(),
                       Folio = row.Cells[9].Value.ToString(),
                       UUID = row.Cells[10].Value.ToString(),
                       TipoRelacion = ".",//row.Cells[18].Value.ToString(),
                       UUIDRelacion = row.Cells[11].Value.ToString(),
                       RFCEmisor = row.Cells[12].Value.ToString(),
                       NombreEmisor = row.Cells[13].Value.ToString(),
                       RegimenFiscal = ".",//row.Cells[22].Value.ToString(),
                       LugarDeExpedicion = row.Cells[14].Value.ToString(),
                       RFCReceptor = row.Cells[15].Value.ToString(),
                       NombreReceptor = row.Cells[16].Value.ToString(),
                       ResidenciaFiscal = row.Cells[17].Value.ToString(),
                       NumRegIdTrib = row.Cells[18].Value.ToString(),
                       UsoCFDI = row.Cells[19].Value.ToString(),
                       SubTotal = row.Cells[20].Value.ToString(),
                       Descuento = row.Cells[21].Value.ToString(),
                       TotaLIEPS = row.Cells[22].Value.ToString(),
                       IVA = row.Cells[23].Value.ToString(),
                       RetenidoIVA = row.Cells[24].Value.ToString(),
                       RetenidoISR = row.Cells[25].Value.ToString(),
                       ISH = row.Cells[26].Value.ToString(),
                       Total = row.Cells[27].Value.ToString(),
                       TotalOriginal = row.Cells[28].Value.ToString(),
                       TotalTrasladados = row.Cells[29].Value.ToString(),
                       TotalRetenidos = row.Cells[30].Value.ToString(),
                       TotalLocalTrasladado = row.Cells[31].Value.ToString(),
                       TotalLocalRetenido = row.Cells[32].Value.ToString(),
                       Complemento = row.Cells[33].Value.ToString(),
                       Moneda = row.Cells[34].Value.ToString(),
                       TipoDeCambio = row.Cells[35].Value.ToString(),
                       FormaDePago = row.Cells[36].Value.ToString(),
                       MetodoDePago = row.Cells[37].Value.ToString(),
                       NumCtaPago = row.Cells[38].Value.ToString(),
                       CondicionDePago = row.Cells[39].Value.ToString(),
                       Conceptos = row.Cells[40].Value.ToString(),
                       Combustible = row.Cells[41].Value.ToString(),
                       IEPS3 = row.Cells[42].Value.ToString(),
                       IEPS6 = row.Cells[43].Value.ToString(),
                       IEPS7 = row.Cells[44].Value.ToString(),
                       IEPS8 = row.Cells[45].Value.ToString(),
                       IEPS9 = row.Cells[46].Value.ToString(),
                       IEPS265 = row.Cells[47].Value.ToString(),
                       IEPS30 = row.Cells[48].Value.ToString(),
                       IEPS53 = row.Cells[49].Value.ToString(),
                       IEPS160 = row.Cells[50].Value.ToString(),
                       AchivoXML = row.Cells[51].Value.ToString(),
                       DireccionEmisor = row.Cells[52].Value.ToString(),
                       LocalidadEmisor = row.Cells[53].Value.ToString(),
                       DireccionReceptor = row.Cells[54].Value.ToString(),
                       LocalidadReceptor = row.Cells[55].Value.ToString(),
                       Empresa = empresa.RFC,
                       realizada = 2,






                   };


                        if (cISFACTRECIBIDAS.Tipo == "Factura")
                        {
                            cISFACTRECIBIDAS.TipoComprobante = "I";
                        }

                        if (cISFACTRECIBIDAS.Tipo == "NotaCredito")
                        {
                            cISFACTRECIBIDAS.TipoComprobante = "E";
                        }


                        db.CISFACTRECIBIDAS.Add(cISFACTRECIBIDAS);
                        db.SaveChanges();

                    }
                    else
                    {

                        CISFACTSEMITIDAS cISFACTSEMITIDAS =
                      new CISFACTSEMITIDAS
                      {

                          Verificado = row.Cells[0].Value.ToString(),
                          EstadoSat = row.Cells[1].Value.ToString(),
                          EstadoValidacion = row.Cells[2].Value.ToString(),
                          NoCertificadoEmisor = row.Cells[3].Value.ToString(),
                          NoCertificadoSAT = row.Cells[4].Value.ToString(),
                          Version = row.Cells[5].Value.ToString(),
                          TipoComprobante = row.Cells[6].Value.ToString(),
                          Tipo = row.Cells[7].Value.ToString(),
                          FechaEmision = DateTime.Parse(row.Cells[8].Value.ToString()),
                          FechaTimbrado = row.Cells[9].Value.ToString(),
                          Ano = int.Parse(row.Cells[10].Value.ToString()),
                          Mes = int.Parse(row.Cells[11].Value.ToString()),
                          Dia = int.Parse(row.Cells[12].Value.ToString()),
                          EstadoPago = row.Cells[13].Value.ToString(),
                          Serie = row.Cells[15].Value.ToString(),
                          Folio = row.Cells[16].Value.ToString(),
                          UUID = row.Cells[17].Value.ToString(),
                          TipoRelacion = row.Cells[18].Value.ToString(),
                          UUIDRelacion = row.Cells[19].Value.ToString(),
                          RFCEmisor = row.Cells[20].Value.ToString(),
                          NombreEmisor = row.Cells[21].Value.ToString(),
                          RegimenFiscal = row.Cells[22].Value.ToString(),
                          LugarDeExpedicion = row.Cells[23].Value.ToString(),
                          RFCReceptor = row.Cells[24].Value.ToString(),
                          NombreReceptor = row.Cells[25].Value.ToString(),
                          ResidenciaFiscal = row.Cells[26].Value.ToString(),
                          NumRegIdTrib = row.Cells[27].Value.ToString(),
                          UsoCFDI = row.Cells[28].Value.ToString(),
                          SubTotal = row.Cells[29].Value.ToString(),
                          Descuento = row.Cells[30].Value.ToString(),
                          TotaLIEPS = row.Cells[31].Value.ToString(),
                          IVA = row.Cells[32].Value.ToString(),
                          RetenidoIVA = row.Cells[33].Value.ToString(),
                          RetenidoISR = row.Cells[34].Value.ToString(),
                          ISH = row.Cells[35].Value.ToString(),
                          Total = row.Cells[36].Value.ToString(),
                          TotalOriginal = row.Cells[37].Value.ToString(),
                          TotalTrasladados = row.Cells[38].Value.ToString(),
                          TotalRetenidos = row.Cells[39].Value.ToString(),
                          TotalLocalTrasladado = row.Cells[40].Value.ToString(),
                          TotalLocalRetenido = row.Cells[41].Value.ToString(),
                          Complemento = row.Cells[42].Value.ToString(),
                          Moneda = row.Cells[43].Value.ToString(),
                          TipoDeCambio = row.Cells[44].Value.ToString(),
                          FormaDePago = row.Cells[45].Value.ToString(),
                          MetodoDePago = row.Cells[46].Value.ToString(),
                          NumCtaPago = row.Cells[47].Value.ToString(),
                          CondicionDePago = row.Cells[48].Value.ToString(),
                          Conceptos = row.Cells[49].Value.ToString(),
                          Combustible = row.Cells[50].Value.ToString(),
                          IEPS3 = row.Cells[51].Value.ToString(),
                          IEPS6 = row.Cells[52].Value.ToString(),
                          IEPS7 = row.Cells[53].Value.ToString(),
                          IEPS8 = row.Cells[54].Value.ToString(),
                          IEPS9 = row.Cells[55].Value.ToString(),
                          IEPS265 = row.Cells[56].Value.ToString(),
                          IEPS30 = row.Cells[57].Value.ToString(),
                          IEPS53 = row.Cells[58].Value.ToString(),
                          IEPS160 = row.Cells[59].Value.ToString(),
                          AchivoXML = row.Cells[60].Value.ToString(),
                          DireccionEmisor = row.Cells[61].Value.ToString(),
                          LocalidadEmisor = row.Cells[62].Value.ToString(),
                          DireccionReceptor = row.Cells[63].Value.ToString(),
                          LocalidadReceptor = row.Cells[64].Value.ToString(),
                          Empresa = empresa.RFC,
                          realizada = 2,


                          #region TRASH_ANTERIOR
                          //Verificado = row.Cells[0].Value.ToString(),
                          //EstadoSat = row.Cells[1].Value.ToString(),
                          //EstadoValidacion = row.Cells[2].Value.ToString(),
                          //NoCertificadoEmisor = row.Cells[3].Value.ToString(),
                          //NoCertificadoSAT = row.Cells[4].Value.ToString(),
                          //Version = row.Cells[5].Value.ToString(),
                          //TipoComprobante = row.Cells[6].Value.ToString(),
                          //Tipo = row.Cells[7].Value.ToString(),
                          //FechaEmision = DateTime.Parse(row.Cells[8].Value.ToString()),
                          //FechaTimbrado = row.Cells[9].Value.ToString(),
                          //Ano = int.Parse(row.Cells[10].Value.ToString()),
                          //Mes = int.Parse(row.Cells[11].Value.ToString()),
                          //Dia = int.Parse(row.Cells[12].Value.ToString()),
                          //EstadoPago = row.Cells[13].Value.ToString(),
                          //Serie = row.Cells[15].Value.ToString(),
                          //Folio = row.Cells[16].Value.ToString(),
                          //UUID = row.Cells[17].Value.ToString(),
                          //TipoRelacion = row.Cells[18].Value.ToString(),
                          //UUIDRelacion = row.Cells[19].Value.ToString(),
                          //RFCEmisor = row.Cells[20].Value.ToString(),
                          //NombreEmisor = row.Cells[21].Value.ToString(),
                          //RegimenFiscal = row.Cells[22].Value.ToString(),
                          //LugarDeExpedicion = row.Cells[23].Value.ToString(),
                          //RFCReceptor = row.Cells[24].Value.ToString(),
                          //NombreReceptor = row.Cells[25].Value.ToString(),
                          //ResidenciaFiscal = row.Cells[26].Value.ToString(),
                          //NumRegIdTrib = row.Cells[27].Value.ToString(),
                          //UsoCFDI = row.Cells[28].Value.ToString(),
                          //SubTotal = row.Cells[29].Value.ToString(),
                          //Descuento = row.Cells[30].Value.ToString(),
                          //TotaLIEPS = row.Cells[31].Value.ToString(),
                          //IVA = row.Cells[32].Value.ToString(),
                          //RetenidoIVA = row.Cells[33].Value.ToString(),
                          //RetenidoISR = row.Cells[34].Value.ToString(),
                          //ISH = row.Cells[35].Value.ToString(),
                          //Total = row.Cells[36].Value.ToString(),
                          //TotalOriginal = row.Cells[37].Value.ToString(),
                          //TotalTrasladados = row.Cells[38].Value.ToString(),
                          //TotalRetenidos = row.Cells[39].Value.ToString(),
                          //TotalLocalTrasladado = row.Cells[40].Value.ToString(),
                          //TotalLocalRetenido = row.Cells[41].Value.ToString(),
                          //Complemento = row.Cells[42].Value.ToString(),
                          //Moneda = row.Cells[43].Value.ToString(),
                          //TipoDeCambio = row.Cells[44].Value.ToString(),
                          //FormaDePago = row.Cells[45].Value.ToString(),
                          //MetodoDePago = row.Cells[46].Value.ToString(),
                          //NumCtaPago = row.Cells[47].Value.ToString(),
                          //CondicionDePago = row.Cells[48].Value.ToString(),
                          //Conceptos = row.Cells[49].Value.ToString(),
                          //Combustible = row.Cells[50].Value.ToString(),
                          //IEPS3 = row.Cells[51].Value.ToString(),
                          //IEPS6 = row.Cells[52].Value.ToString(),
                          //IEPS7 = row.Cells[53].Value.ToString(),
                          //IEPS8 = row.Cells[54].Value.ToString(),
                          //IEPS9 = row.Cells[55].Value.ToString(),
                          //IEPS265 = row.Cells[56].Value.ToString(),
                          //IEPS30 = row.Cells[57].Value.ToString(),
                          //IEPS53 = row.Cells[58].Value.ToString(),
                          //IEPS160 = row.Cells[59].Value.ToString(),
                          //AchivoXML = row.Cells[60].Value.ToString(),
                          //DireccionEmisor = row.Cells[61].Value.ToString(),
                          //LocalidadEmisor = row.Cells[62].Value.ToString(),
                          //DireccionReceptor = row.Cells[63].Value.ToString(),
                          //LocalidadReceptor = row.Cells[64].Value.ToString(),
                          //Empresa = empresa.RFC,
                          //realizada = 2, 
                          #endregion





                      };

                        if (cISFACTSEMITIDAS.Tipo == "Factura")
                        {
                            cISFACTSEMITIDAS.TipoComprobante = "I";
                        }

                        if (cISFACTSEMITIDAS.Tipo == "NotaCredito")
                        {
                            cISFACTSEMITIDAS.TipoComprobante = "E";
                        }

                        db.CISFACTSEMITIDAS.Add(cISFACTSEMITIDAS);
                        db.SaveChanges();
                    }





                }


                //AJUSTE CON NOTAS DE CREDITO
                //if (swtBtn.Value == true)
                //{

                //    var factura = db.CISFACTRECIBIDAS.Where(p => p.Tipo == "NotaCredito").ToList();
                //    foreach (var item in factura)
                //    {
                //        var facturaEncontrada = db.CISFACTRECIBIDAS.Where(p => p.Tipo == "Factura" &&
                //                                                        p.UUID == item.UUIDRelacion && p.Total == item.Total).First();
                //        if (facturaEncontrada != null)
                //        {
                //            //PRIMERO LA NOTA DE CREDITO
                //            CISFACTRECIBIDAS objeto = new CISFACTRECIBIDAS();
                //            objeto = item;
                //            objeto.Total = "0.00";
                //            objeto.IVA = "0.00";
                //            objeto.SubTotal = "0.00";

                //            db.CISFACTRECIBIDAS.Attach(objeto);

                //            db.Entry(objeto).State =
                //                EntityState.Modified;
                //            db.SaveChanges();

                //            //SEGUNDO LA FACTURA
                //            facturaEncontrada.Total = "0.00";
                //            facturaEncontrada.IVA = "0.00";
                //            facturaEncontrada.SubTotal = "0.00";

                //            db.CISFACTRECIBIDAS.Attach(facturaEncontrada);

                //            db.Entry(facturaEncontrada).State =
                //                EntityState.Modified;
                //            db.SaveChanges();




                //        }



                //    }

                //}

            }
            if (letra.Trim() == "MRO")
            {
                //Ingreso a base de datos
                foreach (DataGridViewRow row in gridMuestra.Rows)
                {

                    DateTime FechaRaiz = DateTime.Parse(row.Cells[04].ToString());

                    periodo = FechaRaiz.Year;
                    mes = FechaRaiz.Month;
                    dia = FechaRaiz.Day;

                    //periodo = int.Parse(row.Cells[10].Value.ToString());
                    //mes = int.Parse(row.Cells[11].Value.ToString());
                    //dia = int.Parse(row.Cells[12].Value.ToString());

                    letra = cmbEmpresa.SelectedValue.ToString();






                    if (swtBtn.Value == true)
                    {


                        MROFACTRECIBIDAS mroFACTRECIBIDAS =
                   new MROFACTRECIBIDAS
                   {

                       Verificado = row.Cells[0].Value.ToString(),
                       EstadoSat = row.Cells[1].Value.ToString(),
                       EstadoValidacion = row.Cells[2].Value.ToString(),
                       NoCertificadoEmisor = row.Cells[3].Value.ToString(),
                       NoCertificadoSAT = row.Cells[4].Value.ToString(),
                       Version = row.Cells[5].Value.ToString(),
                       TipoComprobante = row.Cells[6].Value.ToString(),
                       Tipo = row.Cells[7].Value.ToString(),
                       FechaEmision = DateTime.Parse(row.Cells[8].Value.ToString()),
                       FechaTimbrado = row.Cells[9].Value.ToString(),
                       Ano = int.Parse(row.Cells[10].Value.ToString()),
                       Mes = int.Parse(row.Cells[11].Value.ToString()),
                       Dia = int.Parse(row.Cells[12].Value.ToString()),
                       EstadoPago = row.Cells[13].Value.ToString(),
                       Serie = row.Cells[15].Value.ToString(),
                       Folio = row.Cells[16].Value.ToString(),
                       UUID = row.Cells[17].Value.ToString(),
                       TipoRelacion = row.Cells[18].Value.ToString(),
                       UUIDRelacion = row.Cells[19].Value.ToString(),
                       RFCEmisor = row.Cells[20].Value.ToString(),
                       NombreEmisor = row.Cells[21].Value.ToString(),
                       RegimenFiscal = row.Cells[22].Value.ToString(),
                       LugarDeExpedicion = row.Cells[23].Value.ToString(),
                       RFCReceptor = row.Cells[24].Value.ToString(),
                       NombreReceptor = row.Cells[25].Value.ToString(),
                       ResidenciaFiscal = row.Cells[26].Value.ToString(),
                       NumRegIdTrib = row.Cells[27].Value.ToString(),
                       UsoCFDI = row.Cells[28].Value.ToString(),
                       SubTotal = row.Cells[29].Value.ToString(),
                       Descuento = row.Cells[30].Value.ToString(),
                       TotaLIEPS = row.Cells[31].Value.ToString(),
                       IVA = row.Cells[32].Value.ToString(),
                       RetenidoIVA = row.Cells[33].Value.ToString(),
                       RetenidoISR = row.Cells[34].Value.ToString(),
                       ISH = row.Cells[35].Value.ToString(),
                       Total = row.Cells[36].Value.ToString(),
                       TotalOriginal = row.Cells[37].Value.ToString(),
                       TotalTrasladados = row.Cells[38].Value.ToString(),
                       TotalRetenidos = row.Cells[39].Value.ToString(),
                       TotalLocalTrasladado = row.Cells[40].Value.ToString(),
                       TotalLocalRetenido = row.Cells[41].Value.ToString(),
                       Complemento = row.Cells[42].Value.ToString(),
                       Moneda = row.Cells[43].Value.ToString(),
                       TipoDeCambio = row.Cells[44].Value.ToString(),
                       FormaDePago = row.Cells[45].Value.ToString(),
                       MetodoDePago = row.Cells[46].Value.ToString(),
                       NumCtaPago = row.Cells[47].Value.ToString(),
                       CondicionDePago = row.Cells[48].Value.ToString(),
                       Conceptos = row.Cells[49].Value.ToString(),
                       Combustible = row.Cells[50].Value.ToString(),
                       IEPS3 = row.Cells[51].Value.ToString(),
                       IEPS6 = row.Cells[52].Value.ToString(),
                       IEPS7 = row.Cells[53].Value.ToString(),
                       IEPS8 = row.Cells[54].Value.ToString(),
                       IEPS9 = row.Cells[55].Value.ToString(),
                       IEPS265 = row.Cells[56].Value.ToString(),
                       IEPS30 = row.Cells[57].Value.ToString(),
                       IEPS53 = row.Cells[58].Value.ToString(),
                       IEPS160 = row.Cells[59].Value.ToString(),
                       AchivoXML = row.Cells[60].Value.ToString(),
                       DireccionEmisor = row.Cells[61].Value.ToString(),
                       LocalidadEmisor = row.Cells[62].Value.ToString(),
                       DireccionReceptor = row.Cells[63].Value.ToString(),
                       LocalidadReceptor = row.Cells[64].Value.ToString(),
                       Empresa = empresa.RFC,
                       realizada = 2,






                   };

                        db.MROFACTRECIBIDAS.Add(mroFACTRECIBIDAS);
                        db.SaveChanges();

                    }
                    else
                    {

                        MROFACTSEMITIDAS mroFACTEMITIDAS =
                      new MROFACTSEMITIDAS
                      {

                          Verificado = row.Cells[0].Value.ToString(),
                          EstadoSat = row.Cells[1].Value.ToString(),
                          EstadoValidacion = row.Cells[2].Value.ToString(),
                          NoCertificadoEmisor = row.Cells[3].Value.ToString(),
                          NoCertificadoSAT = row.Cells[4].Value.ToString(),
                          Version = row.Cells[5].Value.ToString(),
                          TipoComprobante = row.Cells[6].Value.ToString(),
                          Tipo = row.Cells[7].Value.ToString(),
                          FechaEmision = DateTime.Parse(row.Cells[8].Value.ToString()),
                          FechaTimbrado = row.Cells[9].Value.ToString(),
                          Ano = int.Parse(row.Cells[10].Value.ToString()),
                          Mes = int.Parse(row.Cells[11].Value.ToString()),
                          Dia = int.Parse(row.Cells[12].Value.ToString()),
                          EstadoPago = row.Cells[13].Value.ToString(),
                          Serie = row.Cells[15].Value.ToString(),
                          Folio = row.Cells[16].Value.ToString(),
                          UUID = row.Cells[17].Value.ToString(),
                          TipoRelacion = row.Cells[18].Value.ToString(),
                          UUIDRelacion = row.Cells[19].Value.ToString(),
                          RFCEmisor = row.Cells[20].Value.ToString(),
                          NombreEmisor = row.Cells[21].Value.ToString(),
                          RegimenFiscal = row.Cells[22].Value.ToString(),
                          LugarDeExpedicion = row.Cells[23].Value.ToString(),
                          RFCReceptor = row.Cells[24].Value.ToString(),
                          NombreReceptor = row.Cells[25].Value.ToString(),
                          ResidenciaFiscal = row.Cells[26].Value.ToString(),
                          NumRegIdTrib = row.Cells[27].Value.ToString(),
                          UsoCFDI = row.Cells[28].Value.ToString(),
                          SubTotal = row.Cells[29].Value.ToString(),
                          Descuento = row.Cells[30].Value.ToString(),
                          TotaLIEPS = row.Cells[31].Value.ToString(),
                          IVA = row.Cells[32].Value.ToString(),
                          RetenidoIVA = row.Cells[33].Value.ToString(),
                          RetenidoISR = row.Cells[34].Value.ToString(),
                          ISH = row.Cells[35].Value.ToString(),
                          Total = row.Cells[36].Value.ToString(),
                          TotalOriginal = row.Cells[37].Value.ToString(),
                          TotalTrasladados = row.Cells[38].Value.ToString(),
                          TotalRetenidos = row.Cells[39].Value.ToString(),
                          TotalLocalTrasladado = row.Cells[40].Value.ToString(),
                          TotalLocalRetenido = row.Cells[41].Value.ToString(),
                          Complemento = row.Cells[42].Value.ToString(),
                          Moneda = row.Cells[43].Value.ToString(),
                          TipoDeCambio = row.Cells[44].Value.ToString(),
                          FormaDePago = row.Cells[45].Value.ToString(),
                          MetodoDePago = row.Cells[46].Value.ToString(),
                          NumCtaPago = row.Cells[47].Value.ToString(),
                          CondicionDePago = row.Cells[48].Value.ToString(),
                          Conceptos = row.Cells[49].Value.ToString(),
                          Combustible = row.Cells[50].Value.ToString(),
                          IEPS3 = row.Cells[51].Value.ToString(),
                          IEPS6 = row.Cells[52].Value.ToString(),
                          IEPS7 = row.Cells[53].Value.ToString(),
                          IEPS8 = row.Cells[54].Value.ToString(),
                          IEPS9 = row.Cells[55].Value.ToString(),
                          IEPS265 = row.Cells[56].Value.ToString(),
                          IEPS30 = row.Cells[57].Value.ToString(),
                          IEPS53 = row.Cells[58].Value.ToString(),
                          IEPS160 = row.Cells[59].Value.ToString(),
                          AchivoXML = row.Cells[60].Value.ToString(),
                          DireccionEmisor = row.Cells[61].Value.ToString(),
                          LocalidadEmisor = row.Cells[62].Value.ToString(),
                          DireccionReceptor = row.Cells[63].Value.ToString(),
                          LocalidadReceptor = row.Cells[64].Value.ToString(),
                          Empresa = empresa.RFC,
                          realizada = 2,





                      };


                        db.MROFACTSEMITIDAS.Add(mroFACTEMITIDAS);
                        db.SaveChanges();
                    }





                }
                //AJUSTE CON NOTAS DE CREDITO
                //if (swtBtn.Value == true)
                //{

                //    var factura = db.MROFACTRECIBIDAS.Where(p => p.Tipo == "NotaCredito").ToList();
                //    foreach (var item in factura)
                //    {
                //        var facturaEncontrada = db.MROFACTRECIBIDAS.Where(p => p.Tipo == "Factura" &&
                //                                                        p.UUID == item.UUIDRelacion && p.Total == item.Total).First();
                //        if (facturaEncontrada != null)
                //        {
                //            //PRIMERO LA NOTA DE CREDITO
                //            MROFACTRECIBIDAS objeto = new MROFACTRECIBIDAS();
                //            objeto = item;
                //            objeto.Total = "0.00";
                //            objeto.IVA = "0.00";
                //            objeto.SubTotal = "0.00";

                //            db.MROFACTRECIBIDAS.Attach(objeto);

                //            db.Entry(objeto).State =
                //                EntityState.Modified;
                //            db.SaveChanges();

                //            //SEGUNDO LA FACTURA
                //            facturaEncontrada.Total = "0.00";
                //            facturaEncontrada.IVA = "0.00";
                //            facturaEncontrada.SubTotal = "0.00";

                //            db.MROFACTRECIBIDAS.Attach(facturaEncontrada);

                //            db.Entry(facturaEncontrada).State =
                //                EntityState.Modified;
                //            db.SaveChanges();




                //        }



                //    }

                //}
            }
            if (letra.Trim() == "JMR")
            {
                //Ingreso a base de datos
                foreach (DataGridViewRow row in gridMuestra.Rows)
                {

                    periodo = int.Parse(row.Cells[10].Value.ToString());
                    mes = int.Parse(row.Cells[11].Value.ToString());
                    dia = int.Parse(row.Cells[12].Value.ToString());

                    letra = cmbEmpresa.SelectedValue.ToString();

                    if (swtBtn.Value == true)
                    {


                        JMRFACTRECIBIDAS jmrFACTRECIBIDAS =
                   new JMRFACTRECIBIDAS
                   {

                       Verificado = row.Cells[0].Value.ToString(),
                       EstadoSat = row.Cells[1].Value.ToString(),
                       EstadoValidacion = row.Cells[2].Value.ToString(),
                       NoCertificadoEmisor = row.Cells[3].Value.ToString(),
                       NoCertificadoSAT = row.Cells[4].Value.ToString(),
                       Version = row.Cells[5].Value.ToString(),
                       TipoComprobante = row.Cells[6].Value.ToString(),
                       Tipo = row.Cells[7].Value.ToString(),
                       FechaEmision = DateTime.Parse(row.Cells[8].Value.ToString()),
                       FechaTimbrado = row.Cells[9].Value.ToString(),
                       Ano = int.Parse(row.Cells[10].Value.ToString()),
                       Mes = int.Parse(row.Cells[11].Value.ToString()),
                       Dia = int.Parse(row.Cells[12].Value.ToString()),
                       EstadoPago = row.Cells[13].Value.ToString(),
                       Serie = row.Cells[15].Value.ToString(),
                       Folio = row.Cells[16].Value.ToString(),
                       UUID = row.Cells[17].Value.ToString(),
                       TipoRelacion = row.Cells[18].Value.ToString(),
                       UUIDRelacion = row.Cells[19].Value.ToString(),
                       RFCEmisor = row.Cells[20].Value.ToString(),
                       NombreEmisor = row.Cells[21].Value.ToString(),
                       RegimenFiscal = row.Cells[22].Value.ToString(),
                       LugarDeExpedicion = row.Cells[23].Value.ToString(),
                       RFCReceptor = row.Cells[24].Value.ToString(),
                       NombreReceptor = row.Cells[25].Value.ToString(),
                       ResidenciaFiscal = row.Cells[26].Value.ToString(),
                       NumRegIdTrib = row.Cells[27].Value.ToString(),
                       UsoCFDI = row.Cells[28].Value.ToString(),
                       SubTotal = row.Cells[29].Value.ToString(),
                       Descuento = row.Cells[30].Value.ToString(),
                       TotaLIEPS = row.Cells[31].Value.ToString(),
                       IVA = row.Cells[32].Value.ToString(),
                       RetenidoIVA = row.Cells[33].Value.ToString(),
                       RetenidoISR = row.Cells[34].Value.ToString(),
                       ISH = row.Cells[35].Value.ToString(),
                       Total = row.Cells[36].Value.ToString(),
                       TotalOriginal = row.Cells[37].Value.ToString(),
                       TotalTrasladados = row.Cells[38].Value.ToString(),
                       TotalRetenidos = row.Cells[39].Value.ToString(),
                       TotalLocalTrasladado = row.Cells[40].Value.ToString(),
                       TotalLocalRetenido = row.Cells[41].Value.ToString(),
                       Complemento = row.Cells[42].Value.ToString(),
                       Moneda = row.Cells[43].Value.ToString(),
                       TipoDeCambio = row.Cells[44].Value.ToString(),
                       FormaDePago = row.Cells[45].Value.ToString(),
                       MetodoDePago = row.Cells[46].Value.ToString(),
                       NumCtaPago = row.Cells[47].Value.ToString(),
                       CondicionDePago = row.Cells[48].Value.ToString(),
                       Conceptos = row.Cells[49].Value.ToString(),
                       Combustible = row.Cells[50].Value.ToString(),
                       IEPS3 = row.Cells[51].Value.ToString(),
                       IEPS6 = row.Cells[52].Value.ToString(),
                       IEPS7 = row.Cells[53].Value.ToString(),
                       IEPS8 = row.Cells[54].Value.ToString(),
                       IEPS9 = row.Cells[55].Value.ToString(),
                       IEPS265 = row.Cells[56].Value.ToString(),
                       IEPS30 = row.Cells[57].Value.ToString(),
                       IEPS53 = row.Cells[58].Value.ToString(),
                       IEPS160 = row.Cells[59].Value.ToString(),
                       AchivoXML = row.Cells[60].Value.ToString(),
                       DireccionEmisor = row.Cells[61].Value.ToString(),
                       LocalidadEmisor = row.Cells[62].Value.ToString(),
                       DireccionReceptor = row.Cells[63].Value.ToString(),
                       LocalidadReceptor = row.Cells[64].Value.ToString(),
                       Empresa = empresa.RFC,
                       realizada = 2,






                   };

                        db.JMRFACTRECIBIDAS.Add(jmrFACTRECIBIDAS);
                        db.SaveChanges();

                    }
                    else
                    {

                        JMRFACTSEMITIDAS jmrFACTEMITIDAS =
                      new JMRFACTSEMITIDAS
                      {

                          Verificado = row.Cells[0].Value.ToString(),
                          EstadoSat = row.Cells[1].Value.ToString(),
                          EstadoValidacion = row.Cells[2].Value.ToString(),
                          NoCertificadoEmisor = row.Cells[3].Value.ToString(),
                          NoCertificadoSAT = row.Cells[4].Value.ToString(),
                          Version = row.Cells[5].Value.ToString(),
                          TipoComprobante = row.Cells[6].Value.ToString(),
                          Tipo = row.Cells[7].Value.ToString(),
                          FechaEmision = DateTime.Parse(row.Cells[8].Value.ToString()),
                          FechaTimbrado = row.Cells[9].Value.ToString(),
                          Ano = int.Parse(row.Cells[10].Value.ToString()),
                          Mes = int.Parse(row.Cells[11].Value.ToString()),
                          Dia = int.Parse(row.Cells[12].Value.ToString()),
                          EstadoPago = row.Cells[13].Value.ToString(),
                          Serie = row.Cells[15].Value.ToString(),
                          Folio = row.Cells[16].Value.ToString(),
                          UUID = row.Cells[17].Value.ToString(),
                          TipoRelacion = row.Cells[18].Value.ToString(),
                          UUIDRelacion = row.Cells[19].Value.ToString(),
                          RFCEmisor = row.Cells[20].Value.ToString(),
                          NombreEmisor = row.Cells[21].Value.ToString(),
                          RegimenFiscal = row.Cells[22].Value.ToString(),
                          LugarDeExpedicion = row.Cells[23].Value.ToString(),
                          RFCReceptor = row.Cells[24].Value.ToString(),
                          NombreReceptor = row.Cells[25].Value.ToString(),
                          ResidenciaFiscal = row.Cells[26].Value.ToString(),
                          NumRegIdTrib = row.Cells[27].Value.ToString(),
                          UsoCFDI = row.Cells[28].Value.ToString(),
                          SubTotal = row.Cells[29].Value.ToString(),
                          Descuento = row.Cells[30].Value.ToString(),
                          TotaLIEPS = row.Cells[31].Value.ToString(),
                          IVA = row.Cells[32].Value.ToString(),
                          RetenidoIVA = row.Cells[33].Value.ToString(),
                          RetenidoISR = row.Cells[34].Value.ToString(),
                          ISH = row.Cells[35].Value.ToString(),
                          Total = row.Cells[36].Value.ToString(),
                          TotalOriginal = row.Cells[37].Value.ToString(),
                          TotalTrasladados = row.Cells[38].Value.ToString(),
                          TotalRetenidos = row.Cells[39].Value.ToString(),
                          TotalLocalTrasladado = row.Cells[40].Value.ToString(),
                          TotalLocalRetenido = row.Cells[41].Value.ToString(),
                          Complemento = row.Cells[42].Value.ToString(),
                          Moneda = row.Cells[43].Value.ToString(),
                          TipoDeCambio = row.Cells[44].Value.ToString(),
                          FormaDePago = row.Cells[45].Value.ToString(),
                          MetodoDePago = row.Cells[46].Value.ToString(),
                          NumCtaPago = row.Cells[47].Value.ToString(),
                          CondicionDePago = row.Cells[48].Value.ToString(),
                          Conceptos = row.Cells[49].Value.ToString(),
                          Combustible = row.Cells[50].Value.ToString(),
                          IEPS3 = row.Cells[51].Value.ToString(),
                          IEPS6 = row.Cells[52].Value.ToString(),
                          IEPS7 = row.Cells[53].Value.ToString(),
                          IEPS8 = row.Cells[54].Value.ToString(),
                          IEPS9 = row.Cells[55].Value.ToString(),
                          IEPS265 = row.Cells[56].Value.ToString(),
                          IEPS30 = row.Cells[57].Value.ToString(),
                          IEPS53 = row.Cells[58].Value.ToString(),
                          IEPS160 = row.Cells[59].Value.ToString(),
                          AchivoXML = row.Cells[60].Value.ToString(),
                          DireccionEmisor = row.Cells[61].Value.ToString(),
                          LocalidadEmisor = row.Cells[62].Value.ToString(),
                          DireccionReceptor = row.Cells[63].Value.ToString(),
                          LocalidadReceptor = row.Cells[64].Value.ToString(),
                          Empresa = empresa.RFC,
                          realizada = 2,





                      };


                        db.JMRFACTSEMITIDAS.Add(jmrFACTEMITIDAS);
                        db.SaveChanges();
                    }





                }


                //AJUSTE CON NOTAS DE CREDITO
                //if (swtBtn.Value == true)
                //{

                //    var factura = db.JMRFACTRECIBIDAS.Where(p => p.Tipo == "NotaCredito").ToList();
                //    foreach (var item in factura)
                //    {
                //        var facturaEncontrada = db.JMRFACTRECIBIDAS.Where(p => p.Tipo == "Factura" &&
                //                                                        p.UUID == item.UUIDRelacion && p.Total == item.Total).First();
                //        if (facturaEncontrada != null)
                //        {
                //            //PRIMERO LA NOTA DE CREDITO
                //            JMRFACTRECIBIDAS objeto = new JMRFACTRECIBIDAS();
                //            objeto = item;
                //            objeto.Total = "0.00";
                //            objeto.IVA = "0.00";
                //            objeto.SubTotal = "0.00";

                //            db.JMRFACTRECIBIDAS.Attach(objeto);

                //            db.Entry(objeto).State =
                //                EntityState.Modified;
                //            db.SaveChanges();

                //            //SEGUNDO LA FACTURA
                //            facturaEncontrada.Total = "0.00";
                //            facturaEncontrada.IVA = "0.00";
                //            facturaEncontrada.SubTotal = "0.00";

                //            db.JMRFACTRECIBIDAS.Attach(facturaEncontrada);

                //            db.Entry(facturaEncontrada).State =
                //                EntityState.Modified;
                //            db.SaveChanges();




                //        }



                //    }

                //}
            }
            if (letra.Trim() == "DDR")
            {
                //Ingreso a base de datos
                foreach (DataGridViewRow row in gridMuestra.Rows)
                {

                    periodo = int.Parse(row.Cells[10].Value.ToString());
                    mes = int.Parse(row.Cells[11].Value.ToString());
                    dia = int.Parse(row.Cells[12].Value.ToString());
                    letra = cmbEmpresa.SelectedValue.ToString();






                    if (swtBtn.Value == true)
                    {


                        DDRFACTRECIBIDAS ddrFACTRECIBIDAS =
                   new DDRFACTRECIBIDAS
                   {

                       Verificado = row.Cells[0].Value.ToString(),
                       EstadoSat = row.Cells[1].Value.ToString(),
                       EstadoValidacion = row.Cells[2].Value.ToString(),
                       NoCertificadoEmisor = row.Cells[3].Value.ToString(),
                       NoCertificadoSAT = row.Cells[4].Value.ToString(),
                       Version = row.Cells[5].Value.ToString(),
                       TipoComprobante = row.Cells[6].Value.ToString(),
                       Tipo = row.Cells[7].Value.ToString(),
                       FechaEmision = DateTime.Parse(row.Cells[8].Value.ToString()),
                       FechaTimbrado = row.Cells[9].Value.ToString(),
                       Ano = int.Parse(row.Cells[10].Value.ToString()),
                       Mes = int.Parse(row.Cells[11].Value.ToString()),
                       Dia = int.Parse(row.Cells[12].Value.ToString()),
                       EstadoPago = row.Cells[13].Value.ToString(),
                       Serie = row.Cells[15].Value.ToString(),
                       Folio = row.Cells[16].Value.ToString(),
                       UUID = row.Cells[17].Value.ToString(),
                       TipoRelacion = row.Cells[18].Value.ToString(),
                       UUIDRelacion = row.Cells[19].Value.ToString(),
                       RFCEmisor = row.Cells[20].Value.ToString(),
                       NombreEmisor = row.Cells[21].Value.ToString(),
                       RegimenFiscal = row.Cells[22].Value.ToString(),
                       LugarDeExpedicion = row.Cells[23].Value.ToString(),
                       RFCReceptor = row.Cells[24].Value.ToString(),
                       NombreReceptor = row.Cells[25].Value.ToString(),
                       ResidenciaFiscal = row.Cells[26].Value.ToString(),
                       NumRegIdTrib = row.Cells[27].Value.ToString(),
                       UsoCFDI = row.Cells[28].Value.ToString(),
                       SubTotal = row.Cells[29].Value.ToString(),
                       Descuento = row.Cells[30].Value.ToString(),
                       TotaLIEPS = row.Cells[31].Value.ToString(),
                       IVA = row.Cells[32].Value.ToString(),
                       RetenidoIVA = row.Cells[33].Value.ToString(),
                       RetenidoISR = row.Cells[34].Value.ToString(),
                       ISH = row.Cells[35].Value.ToString(),
                       Total = row.Cells[36].Value.ToString(),
                       TotalOriginal = row.Cells[37].Value.ToString(),
                       TotalTrasladados = row.Cells[38].Value.ToString(),
                       TotalRetenidos = row.Cells[39].Value.ToString(),
                       TotalLocalTrasladado = row.Cells[40].Value.ToString(),
                       TotalLocalRetenido = row.Cells[41].Value.ToString(),
                       Complemento = row.Cells[42].Value.ToString(),
                       Moneda = row.Cells[43].Value.ToString(),
                       TipoDeCambio = row.Cells[44].Value.ToString(),
                       FormaDePago = row.Cells[45].Value.ToString(),
                       MetodoDePago = row.Cells[46].Value.ToString(),
                       NumCtaPago = row.Cells[47].Value.ToString(),
                       CondicionDePago = row.Cells[48].Value.ToString(),
                       Conceptos = row.Cells[49].Value.ToString(),
                       Combustible = row.Cells[50].Value.ToString(),
                       IEPS3 = row.Cells[51].Value.ToString(),
                       IEPS6 = row.Cells[52].Value.ToString(),
                       IEPS7 = row.Cells[53].Value.ToString(),
                       IEPS8 = row.Cells[54].Value.ToString(),
                       IEPS9 = row.Cells[55].Value.ToString(),
                       IEPS265 = row.Cells[56].Value.ToString(),
                       IEPS30 = row.Cells[57].Value.ToString(),
                       IEPS53 = row.Cells[58].Value.ToString(),
                       IEPS160 = row.Cells[59].Value.ToString(),
                       AchivoXML = row.Cells[60].Value.ToString(),
                       DireccionEmisor = row.Cells[61].Value.ToString(),
                       LocalidadEmisor = row.Cells[62].Value.ToString(),
                       DireccionReceptor = row.Cells[63].Value.ToString(),
                       LocalidadReceptor = row.Cells[64].Value.ToString(),
                       Empresa = empresa.RFC,
                       realizada = 2,






                   };

                        db.DDRFACTRECIBIDAS.Add(ddrFACTRECIBIDAS);
                        db.SaveChanges();

                    }
                    else
                    {

                        DDRFACTSEMITIDAS ddrFACTEMITIDAS =
                      new DDRFACTSEMITIDAS
                      {

                          Verificado = row.Cells[0].Value.ToString(),
                          EstadoSat = row.Cells[1].Value.ToString(),
                          EstadoValidacion = row.Cells[2].Value.ToString(),
                          NoCertificadoEmisor = row.Cells[3].Value.ToString(),
                          NoCertificadoSAT = row.Cells[4].Value.ToString(),
                          Version = row.Cells[5].Value.ToString(),
                          TipoComprobante = row.Cells[6].Value.ToString(),
                          Tipo = row.Cells[7].Value.ToString(),
                          FechaEmision = DateTime.Parse(row.Cells[8].Value.ToString()),
                          FechaTimbrado = row.Cells[9].Value.ToString(),
                          Ano = int.Parse(row.Cells[10].Value.ToString()),
                          Mes = int.Parse(row.Cells[11].Value.ToString()),
                          Dia = int.Parse(row.Cells[12].Value.ToString()),
                          EstadoPago = row.Cells[13].Value.ToString(),
                          Serie = row.Cells[15].Value.ToString(),
                          Folio = row.Cells[16].Value.ToString(),
                          UUID = row.Cells[17].Value.ToString(),
                          TipoRelacion = row.Cells[18].Value.ToString(),
                          UUIDRelacion = row.Cells[19].Value.ToString(),
                          RFCEmisor = row.Cells[20].Value.ToString(),
                          NombreEmisor = row.Cells[21].Value.ToString(),
                          RegimenFiscal = row.Cells[22].Value.ToString(),
                          LugarDeExpedicion = row.Cells[23].Value.ToString(),
                          RFCReceptor = row.Cells[24].Value.ToString(),
                          NombreReceptor = row.Cells[25].Value.ToString(),
                          ResidenciaFiscal = row.Cells[26].Value.ToString(),
                          NumRegIdTrib = row.Cells[27].Value.ToString(),
                          UsoCFDI = row.Cells[28].Value.ToString(),
                          SubTotal = row.Cells[29].Value.ToString(),
                          Descuento = row.Cells[30].Value.ToString(),
                          TotaLIEPS = row.Cells[31].Value.ToString(),
                          IVA = row.Cells[32].Value.ToString(),
                          RetenidoIVA = row.Cells[33].Value.ToString(),
                          RetenidoISR = row.Cells[34].Value.ToString(),
                          ISH = row.Cells[35].Value.ToString(),
                          Total = row.Cells[36].Value.ToString(),
                          TotalOriginal = row.Cells[37].Value.ToString(),
                          TotalTrasladados = row.Cells[38].Value.ToString(),
                          TotalRetenidos = row.Cells[39].Value.ToString(),
                          TotalLocalTrasladado = row.Cells[40].Value.ToString(),
                          TotalLocalRetenido = row.Cells[41].Value.ToString(),
                          Complemento = row.Cells[42].Value.ToString(),
                          Moneda = row.Cells[43].Value.ToString(),
                          TipoDeCambio = row.Cells[44].Value.ToString(),
                          FormaDePago = row.Cells[45].Value.ToString(),
                          MetodoDePago = row.Cells[46].Value.ToString(),
                          NumCtaPago = row.Cells[47].Value.ToString(),
                          CondicionDePago = row.Cells[48].Value.ToString(),
                          Conceptos = row.Cells[49].Value.ToString(),
                          Combustible = row.Cells[50].Value.ToString(),
                          IEPS3 = row.Cells[51].Value.ToString(),
                          IEPS6 = row.Cells[52].Value.ToString(),
                          IEPS7 = row.Cells[53].Value.ToString(),
                          IEPS8 = row.Cells[54].Value.ToString(),
                          IEPS9 = row.Cells[55].Value.ToString(),
                          IEPS265 = row.Cells[56].Value.ToString(),
                          IEPS30 = row.Cells[57].Value.ToString(),
                          IEPS53 = row.Cells[58].Value.ToString(),
                          IEPS160 = row.Cells[59].Value.ToString(),
                          AchivoXML = row.Cells[60].Value.ToString(),
                          DireccionEmisor = row.Cells[61].Value.ToString(),
                          LocalidadEmisor = row.Cells[62].Value.ToString(),
                          DireccionReceptor = row.Cells[63].Value.ToString(),
                          LocalidadReceptor = row.Cells[64].Value.ToString(),
                          Empresa = empresa.RFC,
                          realizada = 2,





                      };


                        db.DDRFACTSEMITIDAS.Add(ddrFACTEMITIDAS);
                        db.SaveChanges();
                    }





                }

                //AJUSTE CON NOTAS DE CREDITO
                //if (swtBtn.Value == true)
                //{

                //    var factura = db.DDRFACTRECIBIDAS.Where(p => p.Tipo == "NotaCredito").ToList();
                //    foreach (var item in factura)
                //    {
                //        var facturaEncontrada = db.DDRFACTRECIBIDAS.Where(p => p.Tipo == "Factura" &&
                //                                                        p.UUID == item.UUIDRelacion && p.Total == item.Total).First();
                //        if (facturaEncontrada != null)
                //        {
                //            //PRIMERO LA NOTA DE CREDITO
                //            DDRFACTRECIBIDAS objeto = new DDRFACTRECIBIDAS();
                //            objeto = item;
                //            objeto.Total = "0.00";
                //            objeto.IVA = "0.00";
                //            objeto.SubTotal = "0.00";

                //            db.DDRFACTRECIBIDAS.Attach(objeto);

                //            db.Entry(objeto).State =
                //                EntityState.Modified;
                //            db.SaveChanges();

                //            //SEGUNDO LA FACTURA
                //            facturaEncontrada.Total = "0.00";
                //            facturaEncontrada.IVA = "0.00";
                //            facturaEncontrada.SubTotal = "0.00";

                //            db.DDRFACTRECIBIDAS.Attach(facturaEncontrada);

                //            db.Entry(facturaEncontrada).State =
                //                EntityState.Modified;
                //            db.SaveChanges();




                //        }



                //    }

                //}
            }
            if (letra.Trim() == "CMG")
            {
                //Ingreso a base de datos
                foreach (DataGridViewRow row in gridMuestra.Rows)
                {

                    periodo = int.Parse(row.Cells[10].Value.ToString());
                    mes = int.Parse(row.Cells[11].Value.ToString());
                    dia = int.Parse(row.Cells[12].Value.ToString());
                    letra = cmbEmpresa.SelectedValue.ToString();






                    if (swtBtn.Value == true)
                    {


                        CMGFACTRECIBIDAS cmgFACTRECIBIDAS =
                   new CMGFACTRECIBIDAS
                   {

                       Verificado = row.Cells[0].Value.ToString(),
                       EstadoSat = row.Cells[1].Value.ToString(),
                       EstadoValidacion = row.Cells[2].Value.ToString(),
                       NoCertificadoEmisor = row.Cells[3].Value.ToString(),
                       NoCertificadoSAT = row.Cells[4].Value.ToString(),
                       Version = row.Cells[5].Value.ToString(),
                       TipoComprobante = row.Cells[6].Value.ToString(),
                       Tipo = row.Cells[7].Value.ToString(),
                       FechaEmision = DateTime.Parse(row.Cells[8].Value.ToString()),
                       FechaTimbrado = row.Cells[9].Value.ToString(),
                       Ano = int.Parse(row.Cells[10].Value.ToString()),
                       Mes = int.Parse(row.Cells[11].Value.ToString()),
                       Dia = int.Parse(row.Cells[12].Value.ToString()),
                       EstadoPago = row.Cells[13].Value.ToString(),
                       Serie = row.Cells[15].Value.ToString(),
                       Folio = row.Cells[16].Value.ToString(),
                       UUID = row.Cells[17].Value.ToString(),
                       TipoRelacion = row.Cells[18].Value.ToString(),
                       UUIDRelacion = row.Cells[19].Value.ToString(),
                       RFCEmisor = row.Cells[20].Value.ToString(),
                       NombreEmisor = row.Cells[21].Value.ToString(),
                       RegimenFiscal = row.Cells[22].Value.ToString(),
                       LugarDeExpedicion = row.Cells[23].Value.ToString(),
                       RFCReceptor = row.Cells[24].Value.ToString(),
                       NombreReceptor = row.Cells[25].Value.ToString(),
                       ResidenciaFiscal = row.Cells[26].Value.ToString(),
                       NumRegIdTrib = row.Cells[27].Value.ToString(),
                       UsoCFDI = row.Cells[28].Value.ToString(),
                       SubTotal = row.Cells[29].Value.ToString(),
                       Descuento = row.Cells[30].Value.ToString(),
                       TotaLIEPS = row.Cells[31].Value.ToString(),
                       IVA = row.Cells[32].Value.ToString(),
                       RetenidoIVA = row.Cells[33].Value.ToString(),
                       RetenidoISR = row.Cells[34].Value.ToString(),
                       ISH = row.Cells[35].Value.ToString(),
                       Total = row.Cells[36].Value.ToString(),
                       TotalOriginal = row.Cells[37].Value.ToString(),
                       TotalTrasladados = row.Cells[38].Value.ToString(),
                       TotalRetenidos = row.Cells[39].Value.ToString(),
                       TotalLocalTrasladado = row.Cells[40].Value.ToString(),
                       TotalLocalRetenido = row.Cells[41].Value.ToString(),
                       Complemento = row.Cells[42].Value.ToString(),
                       Moneda = row.Cells[43].Value.ToString(),
                       TipoDeCambio = row.Cells[44].Value.ToString(),
                       FormaDePago = row.Cells[45].Value.ToString(),
                       MetodoDePago = row.Cells[46].Value.ToString(),
                       NumCtaPago = row.Cells[47].Value.ToString(),
                       CondicionDePago = row.Cells[48].Value.ToString(),
                       Conceptos = row.Cells[49].Value.ToString(),
                       Combustible = row.Cells[50].Value.ToString(),
                       IEPS3 = row.Cells[51].Value.ToString(),
                       IEPS6 = row.Cells[52].Value.ToString(),
                       IEPS7 = row.Cells[53].Value.ToString(),
                       IEPS8 = row.Cells[54].Value.ToString(),
                       IEPS9 = row.Cells[55].Value.ToString(),
                       IEPS265 = row.Cells[56].Value.ToString(),
                       IEPS30 = row.Cells[57].Value.ToString(),
                       IEPS53 = row.Cells[58].Value.ToString(),
                       IEPS160 = row.Cells[59].Value.ToString(),
                       AchivoXML = row.Cells[60].Value.ToString(),
                       DireccionEmisor = row.Cells[61].Value.ToString(),
                       LocalidadEmisor = row.Cells[62].Value.ToString(),
                       DireccionReceptor = row.Cells[63].Value.ToString(),
                       LocalidadReceptor = row.Cells[64].Value.ToString(),
                       Empresa = empresa.RFC,
                       realizada = 2,






                   };

                        db.CMGFACTRECIBIDAS.Add(cmgFACTRECIBIDAS);
                        db.SaveChanges();

                    }
                    else
                    {

                        CMGFACTSEMITIDAS cmgFACTEMITIDAS =
                      new CMGFACTSEMITIDAS
                      {

                          Verificado = row.Cells[0].Value.ToString(),
                          EstadoSat = row.Cells[1].Value.ToString(),
                          EstadoValidacion = row.Cells[2].Value.ToString(),
                          NoCertificadoEmisor = row.Cells[3].Value.ToString(),
                          NoCertificadoSAT = row.Cells[4].Value.ToString(),
                          Version = row.Cells[5].Value.ToString(),
                          TipoComprobante = row.Cells[6].Value.ToString(),
                          Tipo = row.Cells[7].Value.ToString(),
                          FechaEmision = DateTime.Parse(row.Cells[8].Value.ToString()),
                          FechaTimbrado = row.Cells[9].Value.ToString(),
                          Ano = int.Parse(row.Cells[10].Value.ToString()),
                          Mes = int.Parse(row.Cells[11].Value.ToString()),
                          Dia = int.Parse(row.Cells[12].Value.ToString()),
                          EstadoPago = row.Cells[13].Value.ToString(),
                          Serie = row.Cells[15].Value.ToString(),
                          Folio = row.Cells[16].Value.ToString(),
                          UUID = row.Cells[17].Value.ToString(),
                          TipoRelacion = row.Cells[18].Value.ToString(),
                          UUIDRelacion = row.Cells[19].Value.ToString(),
                          RFCEmisor = row.Cells[20].Value.ToString(),
                          NombreEmisor = row.Cells[21].Value.ToString(),
                          RegimenFiscal = row.Cells[22].Value.ToString(),
                          LugarDeExpedicion = row.Cells[23].Value.ToString(),
                          RFCReceptor = row.Cells[24].Value.ToString(),
                          NombreReceptor = row.Cells[25].Value.ToString(),
                          ResidenciaFiscal = row.Cells[26].Value.ToString(),
                          NumRegIdTrib = row.Cells[27].Value.ToString(),
                          UsoCFDI = row.Cells[28].Value.ToString(),
                          SubTotal = row.Cells[29].Value.ToString(),
                          Descuento = row.Cells[30].Value.ToString(),
                          TotaLIEPS = row.Cells[31].Value.ToString(),
                          IVA = row.Cells[32].Value.ToString(),
                          RetenidoIVA = row.Cells[33].Value.ToString(),
                          RetenidoISR = row.Cells[34].Value.ToString(),
                          ISH = row.Cells[35].Value.ToString(),
                          Total = row.Cells[36].Value.ToString(),
                          TotalOriginal = row.Cells[37].Value.ToString(),
                          TotalTrasladados = row.Cells[38].Value.ToString(),
                          TotalRetenidos = row.Cells[39].Value.ToString(),
                          TotalLocalTrasladado = row.Cells[40].Value.ToString(),
                          TotalLocalRetenido = row.Cells[41].Value.ToString(),
                          Complemento = row.Cells[42].Value.ToString(),
                          Moneda = row.Cells[43].Value.ToString(),
                          TipoDeCambio = row.Cells[44].Value.ToString(),
                          FormaDePago = row.Cells[45].Value.ToString(),
                          MetodoDePago = row.Cells[46].Value.ToString(),
                          NumCtaPago = row.Cells[47].Value.ToString(),
                          CondicionDePago = row.Cells[48].Value.ToString(),
                          Conceptos = row.Cells[49].Value.ToString(),
                          Combustible = row.Cells[50].Value.ToString(),
                          IEPS3 = row.Cells[51].Value.ToString(),
                          IEPS6 = row.Cells[52].Value.ToString(),
                          IEPS7 = row.Cells[53].Value.ToString(),
                          IEPS8 = row.Cells[54].Value.ToString(),
                          IEPS9 = row.Cells[55].Value.ToString(),
                          IEPS265 = row.Cells[56].Value.ToString(),
                          IEPS30 = row.Cells[57].Value.ToString(),
                          IEPS53 = row.Cells[58].Value.ToString(),
                          IEPS160 = row.Cells[59].Value.ToString(),
                          AchivoXML = row.Cells[60].Value.ToString(),
                          DireccionEmisor = row.Cells[61].Value.ToString(),
                          LocalidadEmisor = row.Cells[62].Value.ToString(),
                          DireccionReceptor = row.Cells[63].Value.ToString(),
                          LocalidadReceptor = row.Cells[64].Value.ToString(),
                          Empresa = empresa.RFC,
                          realizada = 2,





                      };


                        db.CMGFACTSEMITIDAS.Add(cmgFACTEMITIDAS);
                        db.SaveChanges();
                    }





                }

                //AJUSTE CON NOTAS DE CREDITO
                //if (swtBtn.Value == true)
                //{

                //    var factura = db.CMGFACTRECIBIDAS.Where(p => p.Tipo == "NotaCredito").ToList();
                //    foreach (var item in factura)
                //    {
                //        var facturaEncontrada = db.CMGFACTRECIBIDAS.Where(p => p.Tipo == "Factura" &&
                //                                                        p.UUID == item.UUIDRelacion && p.Total == item.Total).First();
                //        if (facturaEncontrada != null)
                //        {
                //            //PRIMERO LA NOTA DE CREDITO
                //            CMGFACTRECIBIDAS objeto = new CMGFACTRECIBIDAS();
                //            objeto = item;
                //            objeto.Total = "0.00";
                //            objeto.IVA = "0.00";
                //            objeto.SubTotal = "0.00";

                //            db.CMGFACTRECIBIDAS.Attach(objeto);

                //            db.Entry(objeto).State =
                //                EntityState.Modified;
                //            db.SaveChanges();

                //            //SEGUNDO LA FACTURA
                //            facturaEncontrada.Total = "0.00";
                //            facturaEncontrada.IVA = "0.00";
                //            facturaEncontrada.SubTotal = "0.00";

                //            db.CMGFACTRECIBIDAS.Attach(facturaEncontrada);

                //            db.Entry(facturaEncontrada).State =
                //                EntityState.Modified;
                //            db.SaveChanges();




                //        }



                //    }

                //}
            }




            MessageBoxEx.EnableGlass = false;
            MessageBoxEx.Show("Archivo Importado con Exito!" +
                "", "EKPolizaGastos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);




        }

        private void ExcelForm_Load(object sender, EventArgs e)
        {
            LoadCompanies();
        }

        private void swtBtn_ValueChanged(object sender, EventArgs e)
        {
            LoadCompaniesProperties();
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();



            LoadCompaniesProperties();

            openFD.InitialDirectory = pathDefaultL.Trim();
            openFD.Title = "Seleccionar archivos";
            openFD.Filter = "Todos los archivos (*.xlsx)|*.xlsx";
            openFD.Multiselect = false;
            DialogResult result = openFD.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txtPath.Text = openFD.FileName;

                if (string.IsNullOrEmpty(txtNameSheet.Text))
                {
                    MessageBoxEx.EnableGlass = false;
                    MessageBox.Show("No Existe el nombre de la Hoja!" +
                        "", "EKPolizaGastos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(txtPath.Text))
                {
                    MessageBoxEx.EnableGlass = false;
                    MessageBox.Show("No esta cargada la ruta del archivo!" +
                        "", "EKPolizaGastos",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable resultado = new DataTable();

                resultado = readSatFactura2.ExcelImport(txtPath.Text, txtNameSheet.Text);

                gridMuestra.DataSource = resultado;



            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBoxEx.EnableGlass = false;
                MessageBox.Show("No esta cargada la ruta del archivo!" +
                    "", "EKPolizaGastos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtNameSheet.Text))
            {
                MessageBoxEx.EnableGlass = false;
                MessageBox.Show("No Existe el nombre de la Hoja!" +
                    "", "EKPolizaGastos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (gridMuestra.Rows.Count == 0)
            {
                MessageBoxEx.EnableGlass = false;
                MessageBox.Show("No hay Filas para importar a Base de Datos!" +
                    "", "EKPolizaGastos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);


                return;

            }

            //REVISO SI EXITE EN BASE DE DATOS ESTE EJERCICIO

            if (gridMuestra.Rows.Count > 0)
            {

                int periodo;
                int mes;
                int dia;

                DateTime FechaRaiz = DateTime.Parse(gridMuestra.Rows[0].Cells[04].Value.ToString());

                periodo = FechaRaiz.Year;
                mes = FechaRaiz.Month;
                dia = FechaRaiz.Day;

                //periodo = int.Parse(gridMuestra.Rows[0].Cells[10].Value.ToString());
                //mes = int.Parse(gridMuestra.Rows[0].Cells[11].Value.ToString());
                //dia = int.Parse(gridMuestra.Rows[0].Cells[12].Value.ToString());


                if (swtBtn.Value == true)
                {
                    if (letra.Trim() == "CIS")
                    {
                        var existe = db.CISFACTRECIBIDAS.Where(p => p.Ano == periodo && p.Mes == mes).ToList();
                        if (existe.Count == 0)
                        {
                            Start();
                        }
                        else
                        {
                            MessageBoxEx.EnableGlass = false;
                            MessageBoxEx.Show("Este Ejercicio ya ha sido cargado!" +
                   "", "EKCFDI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (letra.Trim() == "MRO")
                    {
                        var existe = db.MROFACTRECIBIDAS.Where(p => p.Ano == periodo && p.Mes == mes).ToList();
                        if (existe.Count == 0)
                        {
                            Start();
                        }
                        else
                        {
                            MessageBoxEx.EnableGlass = false;
                            MessageBoxEx.Show("Este Ejercicio ya ha sido cargado!" +
                   "", "EKCFDI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (letra.Trim() == "DDR")
                    {
                        var existe = db.DDRFACTRECIBIDAS.Where(p => p.Ano == periodo && p.Mes == mes).ToList();
                        if (existe.Count == 0)
                        {
                            Start();
                        }
                        else
                        {
                            MessageBoxEx.EnableGlass = false;
                            MessageBoxEx.Show("Este Ejercicio ya ha sido cargado!" +
                   "", "EKCFDI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (letra.Trim() == "JMR")
                    {
                        var existe = db.JMRFACTRECIBIDAS.Where(p => p.Ano == periodo && p.Mes == mes).ToList();
                        if (existe.Count == 0)
                        {
                            Start();
                        }
                        else
                        {
                            MessageBoxEx.EnableGlass = false;
                            MessageBoxEx.Show("Este Ejercicio ya ha sido cargado!" +
                   "", "EKCFDI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (letra.Trim() == "CMG")
                    {
                        var existe = db.CMGFACTRECIBIDAS.Where(p => p.Ano == periodo && p.Mes == mes).ToList();
                        if (existe.Count == 0)
                        {
                            Start();
                        }
                        else
                        {
                            MessageBoxEx.EnableGlass = false;
                            MessageBoxEx.Show("Este Ejercicio ya ha sido cargado!" +
                   "", "EKCFDI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {

                    if (letra.Trim() == "CIS")
                    {
                        var existe = db.CISFACTSEMITIDAS.Where(p => p.Ano == periodo && p.Mes == mes).ToList();
                        if (existe.Count == 0)
                        {
                            Start();
                        }
                        else
                        {
                            MessageBoxEx.EnableGlass = false;
                            MessageBoxEx.Show("Este Ejercicio ya ha sido cargado!" +
                   "", "EKCFDI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (letra.Trim() == "MRO")
                    {
                        var existe = db.MROFACTSEMITIDAS.Where(p => p.Ano == periodo && p.Mes == mes).ToList();
                        if (existe.Count == 0)
                        {
                            Start();
                        }
                        else
                        {
                            MessageBoxEx.EnableGlass = false;
                            MessageBoxEx.Show("Este Ejercicio ya ha sido cargado!" +
                   "", "EKCFDI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (letra.Trim() == "DDR")
                    {
                        var existe = db.DDRFACTSEMITIDAS.Where(p => p.Ano == periodo && p.Mes == mes).ToList();
                        if (existe.Count == 0)
                        {
                            Start();
                        }
                        else
                        {
                            MessageBoxEx.EnableGlass = false;
                            MessageBoxEx.Show("Este Ejercicio ya ha sido cargado!" +
                   "", "EKCFDI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (letra.Trim() == "JMR")
                    {
                        var existe = db.JMRFACTSEMITIDAS.Where(p => p.Ano == periodo && p.Mes == mes).ToList();
                        if (existe.Count == 0)
                        {
                            Start();
                        }
                        else
                        {
                            MessageBoxEx.EnableGlass = false;
                            MessageBoxEx.Show("Este Ejercicio ya ha sido cargado!" +
                   "", "EKCFDI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (letra.Trim() == "CMG")
                    {
                        var existe = db.CMGFACTSEMITIDAS.Where(p => p.Ano == periodo && p.Mes == mes).ToList();
                        if (existe.Count == 0)
                        {
                            Start();
                        }
                        else
                        {
                            MessageBoxEx.EnableGlass = false;
                            MessageBoxEx.Show("Este Ejercicio ya ha sido cargado!" +
                   "", "EKCFDI",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }


                }








            }
        }

        private void Start()
        {
            MessageBoxEx.EnableGlass = false;

            DialogResult result = MessageBoxEx.Show("¿Importar Ejercicio?" +
                "", "EKCFDI",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {


                InsertarRegistros();
            }
        }

        private void lblLeyenda_Click(object sender, EventArgs e)
        {

        }
    }
}
