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
    
    public partial class DeduccionesNominas
    {
        public int IdDeducciones { get; set; }
        public Nullable<int> IdNomina { get; set; }
        public string UUID { get; set; }
        public string NumEmpleado { get; set; }
        public Nullable<System.DateTime> FechaConvert { get; set; }
        public string Clave { get; set; }
        public string Concepto { get; set; }
        public string Importe { get; set; }
        public string TipoDeduccion { get; set; }
    }
}
