using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProfanityScanner.Business.Database
{
    public partial class ProfanityScannerContext : DbContext
    {
        public ProfanityScannerContext()
        {
        }

        public ProfanityScannerContext(DbContextOptions<ProfanityScannerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BadWords> BadWords { get; set; }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BadWords>(entity =>
            {
                entity.HasKey(e => e.BadWordId)
                    .HasName("PK__BadWords__A761A40EC84FAC49");

                entity.Property(e => e.BadWordId).HasColumnName("badWordId");

                entity.Property(e => e.Word)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
