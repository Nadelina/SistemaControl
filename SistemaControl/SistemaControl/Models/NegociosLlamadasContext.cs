using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaControl.Models
{
    public partial class NegociosLlamadasContext : DbContext
    {
        public NegociosLlamadasContext()
        {
        }

        public NegociosLlamadasContext(DbContextOptions<NegociosLlamadasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Llamadas> Llamadas { get; set; }
        public virtual DbSet<Negocios> Negocios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-6R7D46Q\\SQLEXPRESS;Database=NegociosLlamadas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Llamadas>(entity =>
            {
                entity.HasKey(e => e.IdLlamadas);

                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.HasOne(d => d.IdNegocioNavigation)
                    .WithMany(p => p.Llamadas)
                    .HasForeignKey(d => d.IdNegocio)
                    .HasConstraintName("FK__Llamadas__IdNego__3C69FB99");
            });

            modelBuilder.Entity<Negocios>(entity =>
            {
                entity.HasKey(e => e.IdNegocio);

                entity.Property(e => e.Contacto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Negocio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
