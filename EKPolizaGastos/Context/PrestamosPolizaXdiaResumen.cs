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
    
    public partial class PrestamosPolizaXdiaResumen
    {
        public int prestamoId { get; set; }
        public Nullable<int> Contrato { get; set; }
        public Nullable<decimal> Prestamo { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Caja { get; set; }
        public string CajaLetra { get; set; }
        public Nullable<int> Mes { get; set; }
        public Nullable<int> Ano { get; set; }
        public string Suc { get; set; }
    }
}
