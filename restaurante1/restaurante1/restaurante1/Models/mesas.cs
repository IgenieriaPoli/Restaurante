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
    
    public partial class mesas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mesas()
        {
            this.comanda = new HashSet<comanda>();
        }
    
        public int numero_mesa { get; set; }
        public int fk_id_estado { get; set; }
        public int comensales { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comanda> comanda { get; set; }
        public virtual estado_mesa estado_mesa { get; set; }
    }
}
