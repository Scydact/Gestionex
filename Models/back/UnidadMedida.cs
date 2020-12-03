using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gestionex.Models
{
    
    public partial class UnidadMedida
    {
        public UnidadMedida()
        {
            this.Articulos = new HashSet<Articulos>();
        }
    
        public int Id { get; set; }

        [DisplayName("Unidad de medida")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    
        public virtual ICollection<Articulos> Articulos { get; set; }
    }
}
