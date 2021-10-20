using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoFinal.Models
{
    public partial class PollitosContext : DbContext
    {
        public PollitosContext()
        {
        }

        public PollitosContext(DbContextOptions<PollitosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<Condicion> Condicion { get; set; }
        public virtual DbSet<Diario> Diario { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<InfoUsuario> InfoUsuario { get; set; }
        public virtual DbSet<ListaArticulos> ListaArticulos { get; set; }
        public virtual DbSet<Noticias> Noticias { get; set; }
        public virtual DbSet<PadresTutor> PadresTutor { get; set; }
        public virtual DbSet<Pollito> Pollito { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=JOSUE\\DEV;Database=Pollitos;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Address");

                entity.Property(e => e.Canton)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Distrito)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Provincia)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Senales)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Canton>(entity =>
            {
                entity.HasKey(e => e.IdCanton);

                entity.Property(e => e.IdCanton)
                    .HasColumnName("Id_Canton")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.IdProvincia).HasColumnName("Id_Provincia");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Canton)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Canton_Provincia");
            });

            modelBuilder.Entity<Condicion>(entity =>
            {
                entity.HasKey(e => e.IdCondicion);

                entity.Property(e => e.IdCondicion)
                    .HasColumnName("Id_Condicion")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Diario>(entity =>
            {
                entity.HasKey(e => e.IdArticulo)
                    .HasName("PK_Diario_1");

                entity.Property(e => e.IdArticulo)
                    .HasColumnName("id_articulo")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.HasOne(d => d.CedulaPNavigation)
                    .WithMany(p => p.Diario)
                    .HasForeignKey(d => d.CedulaP)
                    .HasConstraintName("FK_Diario_Pollito");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithOne(p => p.Diario)
                    .HasForeignKey<Diario>(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diario_Lista_articulos");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.IdDistrito);

                entity.Property(e => e.IdDistrito)
                    .HasColumnName("Id_Distrito")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.IdCanton).HasColumnName("Id_Canton");

                entity.Property(e => e.Senales)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.HasOne(d => d.IdCantonNavigation)
                    .WithMany(p => p.Distrito)
                    .HasForeignKey(d => d.IdCanton)
                    .HasConstraintName("FK_Distrito_Canton");
            });

            modelBuilder.Entity<InfoUsuario>(entity =>
            {
                entity.HasKey(e => e.CedulaU);

                entity.ToTable("Info_Usuario");

                entity.Property(e => e.CedulaU).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.PrimerApellido)
                    .HasColumnName("Primer_Apellido")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("Segundo_Apellido")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Usuario)
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.InfoUsuario)
                    .HasForeignKey(d => d.Usuario)
                    .HasConstraintName("FK_Info_Usuario_Usuario");
            });

            modelBuilder.Entity<ListaArticulos>(entity =>
            {
                entity.HasKey(e => e.IdArticulo);

                entity.ToTable("Lista_articulos");

                entity.Property(e => e.IdArticulo)
                    .HasColumnName("id_articulo")
                    .ValueGeneratedNever();

                entity.Property(e => e.DescArticulo)
                    .IsRequired()
                    .HasColumnName("desc_articulo")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Noticias>(entity =>
            {
                entity.HasKey(e => e.IdNoticias);

                entity.Property(e => e.IdNoticias)
                    .HasColumnName("Id_Noticias")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PadresTutor>(entity =>
            {
                entity.HasKey(e => e.Cedula);

                entity.ToTable("Padres_Tutor");

                entity.Property(e => e.Cedula).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.PrimerApellido)
                    .HasColumnName("Primer Apellido")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("Segundo Apellido")
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Pollito>(entity =>
            {
                entity.HasKey(e => e.CedulaP);

                entity.Property(e => e.CedulaP).ValueGeneratedNever();

                entity.Property(e => e.IdCondicion).HasColumnName("id_Condicion");

                entity.Property(e => e.IdProvincia).HasColumnName("Id_Provincia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("Primer_Apellido")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasColumnName("Segundo Apellido")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.CedulaNavigation)
                    .WithMany(p => p.Pollito)
                    .HasForeignKey(d => d.Cedula)
                    .HasConstraintName("FK_Pollito_Padres_Tutor1");

                entity.HasOne(d => d.IdCondicionNavigation)
                    .WithMany(p => p.Pollito)
                    .HasForeignKey(d => d.IdCondicion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pollito_Condicion");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Pollito)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK_Pollito_Provincia");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.IdProvincia);

                entity.Property(e => e.IdProvincia)
                    .HasColumnName("Id_Provincia")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Usuario1);

                entity.Property(e => e.Usuario1)
                    .HasColumnName("Usuario")
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
