using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class Categorias
    {
        public Categorias()
        {
            Productos = new HashSet<Productos>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
