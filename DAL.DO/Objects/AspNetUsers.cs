using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class AspNetUsers
    {
        public AspNetUsers()
        {
            //AspNetUserClaims = new HashSet<AspNetUserClaims>();
            //AspNetUserLogins = new HashSet<AspNetUserLogins>();
            //AspNetUserRoles = new HashSet<AspNetUserRoles>();
            //AspNetUserTokens = new HashSet<AspNetUserTokens>();
            Diarios = new HashSet<Diarios>();
            Noticias = new HashSet<Noticias>();
            Pollitos = new HashSet<Pollitos>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string CedulaU { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Telefono { get; set; }
        public DateTime? BirthDate { get; set; }

        //public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        //public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual ICollection<Diarios> Diarios { get; set; }
        public virtual ICollection<Noticias> Noticias { get; set; }
        public virtual ICollection<Pollitos> Pollitos { get; set; }
    }
}
