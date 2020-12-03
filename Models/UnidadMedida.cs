//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gestionex.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class UnidadMedida
    {
        public UnidadMedida()
        {
            this.Articulos = new HashSet<Articulos>();
        }

        [DisplayName("Unidad de medida")]
        public int Id { get; set; }
        [DisplayName("Unidad de medida")]
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [DefaultValue(true)]
        public bool Estado { get; set; }
    
        public virtual ICollection<Articulos> Articulos { get; set; }
    }
}
