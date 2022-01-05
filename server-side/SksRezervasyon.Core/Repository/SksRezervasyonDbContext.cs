using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SksRezervasyon.Core.Repository.Models;

#nullable disable

namespace SksRezervasyon.Core.Repository
{
    public partial class SksRezervasyonDbContext : DbContext
    {
        public SksRezervasyonDbContext()
        {
        }

        public SksRezervasyonDbContext(DbContextOptions<SksRezervasyonDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kutuphane> Kutuphanes { get; set; }
        public virtual DbSet<Misafirhane> Misafirhanes { get; set; }
        public virtual DbSet<Ogrenci> Ogrencis { get; set; }
        public virtual DbSet<Tesi> Teses { get; set; }
        public virtual DbSet<Yemekhane> Yemekhanes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PHE2G6S;Initial Catalog=RezervasyonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Kutuphane>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Ogrenci)
                    .WithMany(p => p.Kutuphanes)
                    .HasForeignKey(d => d.OgrenciId)
                    .HasConstraintName("FK_Kutuphane_Ogrenci1");
            });

            modelBuilder.Entity<Misafirhane>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Ogrenci)
                    .WithMany(p => p.Misafirhanes)
                    .HasForeignKey(d => d.OgrenciId)
                    .HasConstraintName("FK_Misafirhane_Ogrenci");
            });

            modelBuilder.Entity<Ogrenci>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Tesi>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Ogrenci)
                    .WithMany(p => p.Tesis)
                    .HasForeignKey(d => d.OgrenciId)
                    .HasConstraintName("FK_Tesis_Ogrenci");
            });

            modelBuilder.Entity<Yemekhane>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsRandevu).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Ogrenci)
                    .WithMany(p => p.Yemekhanes)
                    .HasForeignKey(d => d.OgrenciId)
                    .HasConstraintName("FK_Yemekhane_Ogrenci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
