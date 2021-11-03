using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class Detalles
    {
        public Detalles()
        {
            Diarios = new HashSet<Diarios>();
        }

        public int Id { get; set; }
        public int IdDiario { get; set; }
        public int ProductosId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public virtual Productos Productos { get; set; }
        public virtual ICollection<Diarios> Diarios { get; set; }
    }
}
