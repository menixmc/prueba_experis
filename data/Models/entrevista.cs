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
    
    public partial class entrevista
    {
        public int id_entrevista { get; set; }
        public int candidato_id { get; set; }
        public System.DateTime fecha_entrevista { get; set; }
        public string hora_entrevista { get; set; }
        public string observaciones { get; set; }
        public int tipo_entrevista_id { get; set; }
    
        public virtual candidato candidato { get; set; }
        public virtual tipo_entrevista tipo_entrevista { get; set; }
    }
}
