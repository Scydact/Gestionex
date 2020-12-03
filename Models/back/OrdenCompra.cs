using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gestionex.Models
{
    
    public partial class OrdenCompra
    {
        public int Id { get; set; }

        [DisplayName("Numero de orden")]
        public int NumeroOrden { get; set; }
        public System.DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public int Cantidad { get; set; }

        [DisplayName("Costo por unidad")]
        public double CostoUnitario { get; set; }
        public int SolicitudArticulosId { get; set; }
    
        public virtual SolicitudArticulos SolicitudArticulo { get; set; }
    }
}
