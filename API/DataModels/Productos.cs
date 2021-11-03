using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataModels
{
    public class Productos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }

        public Categorias Categoria { get; set; }
    }
}
