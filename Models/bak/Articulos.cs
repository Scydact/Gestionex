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
    
    public partial class Articulos
    {
        public Articulos()
        {
            this.SolicitudArticulos = new HashSet<SolicitudArticulos>();
        }
    
        public int Id { get; set; }
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
