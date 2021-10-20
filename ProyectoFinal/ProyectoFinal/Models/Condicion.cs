using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoFinal.Models
{
    public partial class Condicion
    {
        public Condicion()
        {
            Pollito = new HashSet<Pollito>();
        }

        public int IdCondicion { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Pollito> Pollito { get; set; }
    }
}
