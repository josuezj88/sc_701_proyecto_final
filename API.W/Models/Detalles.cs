using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Detalles
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
