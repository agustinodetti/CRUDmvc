using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MVCCRUD.Models;

namespace MVCCRUD.Models
{
    public partial class MVCCRUDContext : DbContext
    {
        public MVCCRUDContext()
        {
        }

        public MVCCRUDContext(DbContextOptions<MVCCRUDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=(localdb)\\Serverlocal;Database=MVCCRUD;Integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Articulo>(entity =>
            {
                //entity.HasKey(e => e.Id); // Definir clave primaria

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)  // Limita el nombre a 100 caracteres
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)  // Limita la descripción a 255 caracteres
                    .IsUnicode(false);

                entity.Property(e => e.Cantidad)
                    .HasColumnType("int"); // Asegura que la columna sea de tipo entero

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("date"); // Define tipo datetime en la BD
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
