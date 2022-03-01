using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MiniProjet.Models
{
    public partial class MiniProjetContext : DbContext
    {
        public MiniProjetContext()
        {
        }

        public MiniProjetContext(DbContextOptions<MiniProjetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empreint> Empreint { get; set; }
        public virtual DbSet<Etudiant> Etudiant { get; set; }
        public virtual DbSet<Livre> Livre { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MiniProjet;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empreint>(entity =>
            {
                entity.HasKey(e => e.IdEmpreinte);

                entity.Property(e => e.Au).HasColumnType("date");

                entity.Property(e => e.Du).HasColumnType("date");

                entity.HasOne(d => d.IdEtudiantNavigation)
                    .WithMany(p => p.Empreint)
                    .HasForeignKey(d => d.IdEtudiant)
                    .HasConstraintName("FK_Empreint_Etudiant");

                entity.HasOne(d => d.IdLivreNavigation)
                    .WithMany(p => p.Empreint)
                    .HasForeignKey(d => d.IdLivre)
                    .HasConstraintName("FK_Empreint_Livre");
            });

            modelBuilder.Entity<Etudiant>(entity =>
            {
                entity.HasKey(e => e.IdEtudiant);

                entity.Property(e => e.Classe)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Livre>(entity =>
            {
                entity.HasKey(e => e.IdLivre);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Isbm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resume)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Titre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
          

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
