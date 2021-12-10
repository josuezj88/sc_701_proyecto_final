using Microsoft.EntityFrameworkCore;
using DAL.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public partial class SolutionDbContext:DbContext
    {
        public SolutionDbContext(DbContextOptions<SolutionDbContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Condicion> Condicion { get; set; }
        public virtual DbSet<Detalles> Detalles { get; set; }
        public virtual DbSet<Diarios> Diarios { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Noticias> Noticias { get; set; }
        public virtual DbSet<Pollitos> Pollitos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Tutores> Tutores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.CedulaU).HasMaxLength(9);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PrimerApellido)
                    .HasColumnName("Primer_Apellido")
                    .HasMaxLength(100);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("Segundo_Apellido")
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono).HasMaxLength(8);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Condicion>(entity =>
            {
                entity.Property(e => e.DetalleCondicion).HasColumnName("Detalle_Condicion");
            });

            modelBuilder.Entity<Detalles>(entity =>
            {
                entity.HasIndex(e => e.DiarioId);

                entity.HasIndex(e => e.ProductosId);

                entity.Property(e => e.IdDiario).HasColumnName("Id_Diario");

                entity.HasOne(d => d.Diario)
                    .WithMany(p => p.Detalles)
                    .HasForeignKey(d => d.DiarioId);

                entity.HasOne(d => d.Productos)
                    .WithMany(p => p.Detalles)
                    .HasForeignKey(d => d.ProductosId);
            });

            modelBuilder.Entity<Diarios>(entity =>
            {
                entity.HasIndex(e => e.ApplicationUserId);

                entity.HasIndex(e => e.PollitoId);

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Diarios)
                    .HasForeignKey(d => d.ApplicationUserId);

                entity.HasOne(d => d.Pollito)
                    .WithMany(p => p.Diarios)
                    .HasForeignKey(d => d.PollitoId);
            });

            modelBuilder.Entity<Noticias>(entity =>
            {
                entity.HasIndex(e => e.ApplicationUserId);

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Noticias)
                    .HasForeignKey(d => d.ApplicationUserId);
            });

            modelBuilder.Entity<Pollitos>(entity =>
            {
                entity.HasIndex(e => e.ApplicationUserId);

                entity.HasIndex(e => e.CondicionId);

                entity.HasIndex(e => e.DireccionId);

                entity.HasIndex(e => e.TutorId);

                entity.Property(e => e.PrimerApellido).HasColumnName("Primer_Apellido");

                entity.Property(e => e.SegundoApellido).HasColumnName("Segundo_Apellido");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Pollitos)
                    .HasForeignKey(d => d.ApplicationUserId);

                entity.HasOne(d => d.Condicion)
                    .WithMany(p => p.Pollitos)
                    .HasForeignKey(d => d.CondicionId);

                entity.HasOne(d => d.Direccion)
                    .WithMany(p => p.Pollitos)
                    .HasForeignKey(d => d.DireccionId);

                entity.HasOne(d => d.Tutor)
                    .WithMany(p => p.Pollitos)
                    .HasForeignKey(d => d.TutorId);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasIndex(e => e.CategoriaId);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoriaId);
            });

            modelBuilder.Entity<Tutores>(entity =>
            {
                entity.Property(e => e.PrimerApellido).HasColumnName("Primer_Apellido");

                entity.Property(e => e.SegundoApellido).HasColumnName("Segundo_Apellido");
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
