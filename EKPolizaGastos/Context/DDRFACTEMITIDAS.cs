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
    
    public partial class DDRFACTEMITIDAS
    {
        public int facturaId { get; set; }
        public string Verificado { get; set; }
        public string EstadoSat { get; set; }
        public string EstadoValidacion { get; set; }
        public string NoCertificadoEmisor { get; set; }
        public string NoCertificadoSAT { get; set; }
        public string Version { get; set; }
        public string TipoComprobante { get; set; }
        public string Tipo { get; set; }
        public Nullable<System.DateTime> FechaEmision { get; set; }
        public string FechaTimbrado { get; set; }
        public Nullable<int> Ano { get; set; }
        public Nullable<int> Mes { get; set; }
        public Nullable<int> Dia { get; set; }
        public string EstadoPago { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public string UUID { get; set; }
        public string TipoRelacion { get; set; }
        public string UUIDRelacion { get; set; }
        public string RFCEmisor { get; set; }
        public string NombreEmisor { get; set; }
        public string RegimenFiscal { get; set; }
        public string LugarDeExpedicion { get; set; }
        public string RFCReceptor { get; set; }
        public string NombreReceptor { get; set; }
        public string ResidenciaFiscal { get; set; }
        public string NumRegIdTrib { get; set; }
        public string UsoCFDI { get; set; }
        public string SubTotal { get; set; }
        public string Descuento { get; set; }
        public string TotaLIEPS { get; set; }
        public string IVA { get; set; }
        public string RetenidoIVA { get; set; }
        public string RetenidoISR { get; set; }
        public string ISH { get; set; }
        public string Total { get; set; }
        public string TotalOriginal { get; set; }
        public string TotalTrasladados { get; set; }
        public string TotalRetenidos { get; set; }
        public string TotalLocalTrasladado { get; set; }
        public string TotalLocalRetenido { get; set; }
        public string Complemento { get; set; }
        public string Moneda { get; set; }
        public string TipoDeCambio { get; set; }
        public string FormaDePago { get; set; }
        public string MetodoDePago { get; set; }
        public string NumCtaPago { get; set; }
        public string CondicionDePago { get; set; }
        public string Conceptos { get; set; }
        public string Combustible { get; set; }
        public string IEPS3 { get; set; }
        public string IEPS6 { get; set; }
        public string IEPS7 { get; set; }
        public string IEPS8 { get; set; }
        public string IEPS9 { get; set; }
        public string IEPS265 { get; set; }
        public string IEPS30 { get; set; }
        public string IEPS53 { get; set; }
        public string IEPS160 { get; set; }
        public string AchivoXML { get; set; }
        public string DireccionEmisor { get; set; }
        public string LocalidadEmisor { get; set; }
        public string DireccionReceptor { get; set; }
        public string LocalidadReceptor { get; set; }
        public string Empresa { get; set; }
        public Nullable<int> realizada { get; set; }
    }
}
