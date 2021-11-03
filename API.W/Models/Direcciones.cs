using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Direcciones
    {
        public Direcciones()
        {
            Pollitos = new HashSet<Pollitos>();
        }

        public int Id { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Detalles { get; set; }

        public virtual ICollection<Pollitos> Pollitos { get; set; }
    }
}
