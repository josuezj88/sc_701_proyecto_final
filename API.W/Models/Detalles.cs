using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Detalles
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
