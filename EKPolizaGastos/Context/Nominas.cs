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
    
    public partial class Nominas
    {
        public int IdNomina { get; set; }
        public string Version { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public string Fecha { get; set; }
        public string Sello { get; set; }
        public string FormaPago { get; set; }
        public string NoCertificado { get; set; }
        public string Certificado { get; set; }
        public string SubTotal { get; set; }
        public string Descuento { get; set; }
        public string Moneda { get; set; }
        public string Total { get; set; }
        public string TipodeComprobante { get; set; }
        public string MetodoPago { get; set; }
        public string LugarExpedicion { get; set; }
        public string Emisor_Rfc { get; set; }
        public string Emisor_Nombre { get; set; }
        public string Emisor_RegimenFiscal { get; set; }
        public string Receptor_Rfc { get; set; }
        public string Receptor_Nombre { get; set; }
        public string Receptor_UsoCFDI { get; set; }
        public string FechaFinalPago { get; set; }
        public string FechaInicialPago { get; set; }
        public string FechaPago { get; set; }
        public string NumDiasPagados { get; set; }
        public string TipoNomina { get; set; }
        public string TotalDeducciones { get; set; }
        public string TotalPercepciones { get; set; }
        public string Complemento_Version { get; set; }
        public string RegistroPatronal { get; set; }
        public string Antiguedad { get; set; }
        public string Banco { get; set; }
        public string ClaveEntFed { get; set; }
        public string CuentaBancaria { get; set; }
        public string Curp { get; set; }
        public string Departamento { get; set; }
        public string FechaInicioRelLaboral { get; set; }
        public string NumEmpleado { get; set; }
        public string NumSeguridadSocial { get; set; }
        public string PeriodicidadPago { get; set; }
        public string Puesto { get; set; }
        public string RiesgoPuesto { get; set; }
        public string SalarioBaseCotApor { get; set; }
        public string SalarioDiarioIntegrado { get; set; }
        public string Sindicalizado { get; set; }
        public string TipoContrato { get; set; }
        public string TipoJornada { get; set; }
        public string TipoRegimen { get; set; }
        public string TotalExento { get; set; }
        public string TotalGravado { get; set; }
        public string TotalSueldos { get; set; }
        public string TotalImpuestoRetenidos { get; set; }
        public string TotalOtrasDeducciones { get; set; }
        public string T_RfcProvCertif { get; set; }
        public string T_Version { get; set; }
        public string UUID { get; set; }
        public string T_FechaTimbrado { get; set; }
        public string T_SelloCFD { get; set; }
        public string NoCertificadoSAT { get; set; }
        public Nullable<System.DateTime> FechaConvert { get; set; }
        public Nullable<int> EstatusNomina { get; set; }
        public Nullable<int> Año { get; set; }
        public Nullable<int> Mes { get; set; }
    }
}
