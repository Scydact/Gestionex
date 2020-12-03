using System;
using System.Collections.Generic;

namespace Gestionex.Models
{

    public partial class SolicitudArticulos
    {
        public SolicitudArticulos()
        {
            this.OrdenCompras = new HashSet<OrdenCompra>();
        }

        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public int Cantidad { get; set; }
        public int ArticulosId { get; set; }
        public int EmpleadosId { get; set; }

        public virtual Articulos Articulo { get; set; }
        public virtual Empleados Empleado { get; set; }
        public virtual ICollection<OrdenCompra> OrdenCompras { get; set; }
    }
}
