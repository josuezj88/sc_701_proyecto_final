using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class Direcciones
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
