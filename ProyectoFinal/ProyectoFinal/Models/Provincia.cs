using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoFinal.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Canton = new HashSet<Canton>();
            Pollito = new HashSet<Pollito>();
        }

        public int IdProvincia { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Canton> Canton { get; set; }
        public virtual ICollection<Pollito> Pollito { get; set; }
    }
}
