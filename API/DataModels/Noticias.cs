using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataModels
{
    public class Noticias
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Date { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
    }
}
