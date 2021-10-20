using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoFinal.Models
{
    public partial class Distrito
    {
        public int IdDistrito { get; set; }
        public string Descripcion { get; set; }
        public int? IdCanton { get; set; }
        public string Senales { get; set; }

        public virtual Canton IdCantonNavigation { get; set; }
    }
}
