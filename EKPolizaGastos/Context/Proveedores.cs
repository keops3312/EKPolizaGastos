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
    
    public partial class Proveedores
    {
        public int IdProveedor { get; set; }
        public string Proveedor { get; set; }
        public string RFC { get; set; }
        public string NoProveedor { get; set; }
        public int IdEmpresa { get; set; }
        public int IdLocalidad { get; set; }
        public string Cuenta_cargo_1 { get; set; }
        public string Cuenta_cargo_2 { get; set; }
        public string Cuenta_cargo_3 { get; set; }
        public string Cuenta_Cargo_Iva { get; set; }
        public string Cuenta_Abono_1 { get; set; }
        public string Cuenta_Abono_2 { get; set; }
        public string Cuenta_Abono_3 { get; set; }
        public string Titulo_principal { get; set; }
        public string Titulo_secundario { get; set; }
        public string Titulo_tercero { get; set; }
        public string Departamento { get; set; }
    
        public virtual Empresas Empresas { get; set; }
        public virtual Localidades Localidades { get; set; }
    }
}