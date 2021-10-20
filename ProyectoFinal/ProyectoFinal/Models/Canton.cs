using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoFinal.Models
{
    public partial class Canton
    {
        public Canton()
        {
            Distrito = new HashSet<Distrito>();
        }

        public int IdCanton { get; set; }
        public string Descripcion { get; set; }
        public int IdProvincia { get; set; }

        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual ICollection<Distrito> Distrito { get; set; }
    }
}
