using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class Condicion
    {
        public Condicion()
        {
            Pollitos = new HashSet<Pollitos>();
        }

        public int Id { get; set; }
        public string DetalleCondicion { get; set; }

        public virtual ICollection<Pollitos> Pollitos { get; set; }
    }
}
