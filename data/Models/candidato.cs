//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class candidato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public candidato()
        {
            this.entrevista = new HashSet<entrevista>();
        }
    
        public int id_candidato { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string direccion_calle { get; set; }
        public string direccion_suite { get; set; }
        public string direccion_ciudad { get; set; }
        public string direccion_codigo_postal { get; set; }
        public string telefono { get; set; }
        public string sitio_web { get; set; }
        public string compañia_nombre { get; set; }
        public string compañia_catchPhrase { get; set; }
        public string compañia_bs { get; set; }
        public int api_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<entrevista> entrevista { get; set; }
    }
}
