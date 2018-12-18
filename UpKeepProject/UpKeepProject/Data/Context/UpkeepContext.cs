using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UpKeepProject
{
    public partial class UpkeepContext : DbContext
    {
        public UpkeepContext()
        {
        }

        public UpkeepContext(DbContextOptions<UpkeepContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kunde> Kundes { get; set; }
        public virtual DbSet<Personale> Personales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=upkeep2.database.windows.net;Initial " +
                    "Catalog=UpKeep;Persist Security Info=True;User " +
                    "ID=Basic;" +
                    "Password=Polo1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kunde>(entity =>
            {
                entity.ToTable("Kunde");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Personale>(entity =>
            {
                entity.ToTable("Personale");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
