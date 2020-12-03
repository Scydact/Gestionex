using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gestionex.Models
{

    public partial class Articulos
    {
        public Articulos()
        {
            this.SolicitudArticulos = new HashSet<SolicitudArticulos>();
        }
    
        public int Id { get; set; }

        [DisplayName("Artículo")]
        public string Nombre { get; set; }

        public int Existencia { get; set; }
        public bool Estado { get; set; }
        public string Descripcion { get; set; }
        public int UnidadMedidaId { get; set; }
        public int MarcasId { get; set; }
    
        public virtual UnidadMedida UnidadMedida { get; set; }
        public virtual Marcas Marca { get; set; }
        public virtual ICollection<SolicitudArticulos> SolicitudArticulos { get; set; }
    }
}
