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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=upkeep.database.windows.net;Initial Catalog=UpKeep;Persist Security Info=True;User ID=Basic;Password=Polo1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kunde>(entity =>
            {
                entity.ToTable("Kunde");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasColumnName("adresse")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Nummer).HasColumnName("nummer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
