using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Diarios
    {
        public Diarios()
        {
            Detalles = new HashSet<Detalles>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ApplicationUserId { get; set; }
        public int PollitoId { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual Pollitos Pollito { get; set; }
        public virtual ICollection<Detalles> Detalles { get; set; }
    }
}
