﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class restaurante_el_buen_saborEntities6 : DbContext
    {
        public restaurante_el_buen_saborEntities6()
            : base("name=restaurante_el_buen_saborEntities6")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<comanda> comanda { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }
        public virtual DbSet<estado_mesa> estado_mesa { get; set; }
        public virtual DbSet<facturacion> facturacion { get; set; }
        public virtual DbSet<mesas> mesas { get; set; }
        public virtual DbSet<pedidos> pedidos { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<rol> rol { get; set; }
        public virtual DbSet<tipo_documento> tipo_documento { get; set; }
        public virtual DbSet<productos_mesa> productos_mesa { get; set; }
        public virtual DbSet<view_empleado> view_empleado { get; set; }
    
        public virtual ObjectResult<procedure_factura_Result> procedure_factura(Nullable<int> numero_mesa)
        {
            var numero_mesaParameter = numero_mesa.HasValue ?
                new ObjectParameter("numero_mesa", numero_mesa) :
                new ObjectParameter("numero_mesa", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procedure_factura_Result>("procedure_factura", numero_mesaParameter);
        }
    }
}
