using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Pollitos
    {
        public Pollitos()
        {
            Diarios = new HashSet<Diarios>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Telefono { get; set; }
        public int CondicionId { get; set; }
        public string ApplicationUserId { get; set; }
        public int DireccionId { get; set; }
        public int TutorId { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual Condicion Condicion { get; set; }
        public virtual Direcciones Direccion { get; set; }
        public virtual Tutores Tutor { get; set; }
        public virtual ICollection<Diarios> Diarios { get; set; }
    }
}
