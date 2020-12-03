using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gestionex.Models
{
    
    public partial class Proveedores
    {
        public Proveedores()
        {
            this.Marcas = new HashSet<Marcas>();
        }
    
        public int Id { get; set; }
        public string Cedula { get; set; }

        [DisplayName("Nombre Comercial")]
        public string NombreComercial { get; set; }
        public bool Estado { get; set; }
    
        public virtual ICollection<Marcas> Marcas { get; set; }
    }
}
