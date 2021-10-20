using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoFinal.Models
{
    public partial class Diario
    {
        public int Cantidad { get; set; }
        public int IdArticulo { get; set; }
        public int? CedulaP { get; set; }

        public virtual Pollito CedulaPNavigation { get; set; }
        public virtual ListaArticulos IdArticuloNavigation { get; set; }
    }
}
