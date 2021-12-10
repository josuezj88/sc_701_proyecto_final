using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class Diarios
    {
        public Diarios()
        {
            Detalles = new HashSet<Detalles>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ApplicationUserId { get; set; }
        public int PollitoId { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual Pollitos Pollito { get; set; }
        public virtual ICollection<Detalles> Detalles { get; set; }
    }
}
