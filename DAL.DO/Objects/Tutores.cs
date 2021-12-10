using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class Tutores
    {
        public Tutores()
        {
            Pollitos = new HashSet<Pollitos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Pollitos> Pollitos { get; set; }
    }
}
