using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataModels
{
    public class Detalles
    {
        public int Id { get; set; }
        public int IdDiario { get; set; }
        public int ProductosId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public virtual Productos Productos { get; set; }
    }
}
