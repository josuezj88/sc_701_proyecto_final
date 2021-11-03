using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Diarios
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DetalleId { get; set; }
        public string ApplicationUserId { get; set; }
        public int PollitoId { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual Detalles Detalle { get; set; }
        public virtual Pollitos Pollito { get; set; }
    }
}
