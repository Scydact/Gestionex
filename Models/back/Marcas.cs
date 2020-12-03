using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gestionex.Models
{
    
    public partial class Marcas
    {
        public Marcas()
        {
            this.Articulos = new HashSet<Articulos>();
        }
    
        public int Id { get; set; }

        [DisplayName("Marca")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ProveedoresId { get; set; }
        public bool Estado { get; set; }
    
        public virtual Proveedores Proveedor { get; set; }
        public virtual ICollection<Articulos> Articulos { get; set; }
    }
}
