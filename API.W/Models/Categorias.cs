﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Categorias
    {
        public Categorias()
        {
            Productos = new HashSet<Productos>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
