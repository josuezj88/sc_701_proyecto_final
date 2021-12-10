using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class Productos
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
