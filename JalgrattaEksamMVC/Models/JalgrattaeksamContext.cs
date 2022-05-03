using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JalgrattaEksamMVC.Models
{
    public partial class JalgrattaeksamContext : DbContext
    {
        public JalgrattaeksamContext()
        {
        }

        public JalgrattaeksamContext(DbContextOptions<JalgrattaeksamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jalgrattaeksam> Jalgrattaeksams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JPU1SGT;Database=Jalgrattaeksam;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Jalgrattaeksam>(entity =>
            {
                entity.ToTable("jalgrattaeksam");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Eesnimi)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("eesnimi");

                entity.Property(e => e.Luba)
                    .HasColumnName("luba")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Perekonnanimi)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("perekonnanimi");

                entity.Property(e => e.Ringtee)
                    .HasColumnName("ringtee")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Slaalom)
                    .HasColumnName("slaalom")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Tanav)
                    .HasColumnName("tanav")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Teooriatulemus)
                    .HasColumnName("teooriatulemus")
                    .HasDefaultValueSql("((-1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
