//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace restaurante1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class empleado
    {
        public int identificacion { get; set; }
        public string fkpk_tipo_doc { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string contrasenia { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public int fk_rol { get; set; }
    
        public virtual rol rol { get; set; }
        public virtual tipo_documento tipo_documento { get; set; }
    }
}
