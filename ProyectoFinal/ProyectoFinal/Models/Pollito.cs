using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoFinal.Models
{
    public partial class Pollito
    {
        public Pollito()
        {
            Diario = new HashSet<Diario>();
        }

        public int CedulaP { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int IdCondicion { get; set; }
        public int CedulaU { get; set; }
        public int? IdProvincia { get; set; }
        public int? Cedula { get; set; }

        public virtual PadresTutor CedulaNavigation { get; set; }
        public virtual Condicion IdCondicionNavigation { get; set; }
        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual ICollection<Diario> Diario { get; set; }
    }
}
