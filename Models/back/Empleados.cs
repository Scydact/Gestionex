using System;
using System.Collections.Generic;

namespace Gestionex.Models
{
    
    public partial class Empleados
    {
        public Empleados()
        {
            this.SolicitudArticulos = new HashSet<SolicitudArticulos>();
        }
    
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Estado { get; set; }
        public int DepartamentosId { get; set; }
    
        public virtual Departamentos Departamento { get; set; }
        public virtual ICollection<SolicitudArticulos> SolicitudArticulos { get; set; }
    }
}
