using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Productos
    {
        public Productos()
        {
            Detalles = new HashSet<Detalles>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categorias Categoria { get; set; }
        public virtual ICollection<Detalles> Detalles { get; set; }
    }
}
