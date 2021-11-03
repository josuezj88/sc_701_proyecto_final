using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Condicion
    {
        public Condicion()
        {
            Pollitos = new HashSet<Pollitos>();
        }

        public int Id { get; set; }
        public string DetalleCondicion { get; set; }

        public virtual ICollection<Pollitos> Pollitos { get; set; }
    }
}
