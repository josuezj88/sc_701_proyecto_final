using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoFinal.Models
{
    public partial class ListaArticulos
    {
        public int IdArticulo { get; set; }
        public string DescArticulo { get; set; }

        public virtual Diario Diario { get; set; }
    }
}
