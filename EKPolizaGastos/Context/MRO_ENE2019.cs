//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EKPolizaGastos.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class MRO_ENE2019
    {
        public int IdFactura { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public string Fecha { get; set; }
        public string Versions { get; set; }
        public string Sello { get; set; }
        public string FormaPago { get; set; }
        public string NoCertificado { get; set; }
        public string MetodoPago { get; set; }
        public string LugarExpedicion { get; set; }
        public string schemaLocation { get; set; }
        public string CondicionesDePago { get; set; }
        public string SubTotal { get; set; }
        public string Descuento { get; set; }
        public string Moneda { get; set; }
        public string Total { get; set; }
        public string TipoDeComprobante { get; set; }
        public string Emisor { get; set; }
        public string RegimeFiscal_receptor { get; set; }
        public string RFC_emisor { get; set; }
        public string Receptor { get; set; }
        public string RFC_receptor { get; set; }
        public string UsoCFDI { get; set; }
        public string SelloCFD { get; set; }
        public string NoCertificadoSAT { get; set; }
        public string RFcProvCertif { get; set; }
        public string UUID { get; set; }
        public string FechaTimbrado { get; set; }
        public string SelloSAT { get; set; }
        public string Importe { get; set; }
        public string Impuesto { get; set; }
        public string TasaOCuota { get; set; }
        public string TipoFactor { get; set; }
        public Nullable<System.DateTime> Registro { get; set; }
        public int IdEstatus { get; set; }
        public Nullable<System.DateTime> FechaC { get; set; }
    }
}
