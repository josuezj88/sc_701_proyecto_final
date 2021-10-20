using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoFinal.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            InfoUsuario = new HashSet<InfoUsuario>();
        }

        public string Usuario1 { get; set; }
        public string Contrasena { get; set; }

        public virtual ICollection<InfoUsuario> InfoUsuario { get; set; }
    }
}
