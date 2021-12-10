using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class Detalles
    {

        public int Id { get; set; }
        public int IdDiario { get; set; }
        public int ProductosId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public int DiarioId { get; set; }
        public int Pendiente { get; set; }

        public virtual Diarios Diario { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
