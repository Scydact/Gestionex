using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gestionex.Models
{
    
    public partial class Departamentos
    {
        public Departamentos()
        {
            this.Empleados = new HashSet<Empleados>();
        }
    
        public int Id { get; set; }

        [DisplayName("Departamento")]
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    
        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
