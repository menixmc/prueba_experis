﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace data.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class modeloEntities : DbContext
    {
        public modeloEntities()
            : base("name=modeloEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<candidato> candidato { get; set; }
        public virtual DbSet<entrevista> entrevista { get; set; }
        public virtual DbSet<opciones_tecnologia> opciones_tecnologia { get; set; }
        public virtual DbSet<tipo_entrevista> tipo_entrevista { get; set; }
        public virtual DbSet<tipo_tecnologia> tipo_tecnologia { get; set; }
    }
}
