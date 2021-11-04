using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataModels
{
    public class Diarios
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DetalleId { get; set; }
        public string ApplicationUserId { get; set; }
        public int PollitoId { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual Detalles Detalle { get; set; }
        public virtual Pollitos Pollito { get; set; }
    }
}
