using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Antisya.YaprakDemir.Entity.Model
{
    public partial class YdSatisAppContext : DbContext
    {
        public YdSatisAppContext()
        {
        }

        public YdSatisAppContext(DbContextOptions<YdSatisAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlisFaturaListesiTable> AlisFaturaListesiTable { get; set; }
        public virtual DbSet<BirimTable> BirimTable { get; set; }
        public virtual DbSet<MusteriTable> MusteriTable { get; set; }
        public virtual DbSet<SiparisListesiTable> SiparisListesiTable { get; set; }
        public virtual DbSet<SiparisTable> SiparisTable { get; set; }
        public virtual DbSet<TedarikciTable> TedarikciTable { get; set; }
        public virtual DbSet<UrunTable> UrunTable { get; set; }
        public virtual DbSet<VergiTable> VergiTable { get; set; }

        // Unable to generate entity type for table 'dbo.AlisFaturasiTable'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=BURYAZ\\SQLEXPRESS;Database=YDSatisApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AlisFaturaListesiTable>(entity =>
            {
                entity.HasKey(e => e.AlisFaturaListesiId);

                entity.Property(e => e.AlisFiyati).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AlisMiktari).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.AlisFaturaListesiTable)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AlisFaturaListesiTable_UrunTable");

                entity.HasOne(d => d.Vergi)
                    .WithMany(p => p.AlisFaturaListesiTable)
                    .HasForeignKey(d => d.VergiId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AlisFaturaListesiTable_VergiTable");
            });

            modelBuilder.Entity<BirimTable>(entity =>
            {
                entity.HasKey(e => e.BirimId);

                entity.Property(e => e.BirimAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MusteriTable>(entity =>
            {
                entity.HasKey(e => e.MusteriId);

                entity.Property(e => e.IletisimNumarasi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MusteriAdi)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MusteriAdresi).IsUnicode(false);

                entity.Property(e => e.VergiDairesi)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SiparisListesiTable>(entity =>
            {
                entity.HasKey(e => e.SiparisListesiId);

                entity.Property(e => e.Miktar).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SatisFiyati).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Siparis)
                    .WithMany(p => p.SiparisListesiTable)
                    .HasForeignKey(d => d.SiparisId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SiparisListesiTable_SiparisTable");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.SiparisListesiTable)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SiparisListesiTable_UrunTable");

                entity.HasOne(d => d.Vergi)
                    .WithMany(p => p.SiparisListesiTable)
                    .HasForeignKey(d => d.VergiId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SiparisListesiTable_VergiTable");
            });

            modelBuilder.Entity<SiparisTable>(entity =>
            {
                entity.HasKey(e => e.SiparisId);

                entity.Property(e => e.IskontoYuzdesi).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.Property(e => e.ToplamTutar).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VergiTutari).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Musteri)
                    .WithMany(p => p.SiparisTable)
                    .HasForeignKey(d => d.MusteriId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SiparisTable_MusteriTable");
            });

            modelBuilder.Entity<TedarikciTable>(entity =>
            {
                entity.HasKey(e => e.TedarikciId);

                entity.Property(e => e.TedarikciAdi)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UrunTable>(entity =>
            {
                entity.HasKey(e => e.UrunId);

                entity.Property(e => e.UrunAciklama).IsUnicode(false);

                entity.Property(e => e.UrunAdi)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Birim)
                    .WithMany(p => p.UrunTable)
                    .HasForeignKey(d => d.BirimId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UrunTable_BirimTable");
            });

            modelBuilder.Entity<VergiTable>(entity =>
            {
                entity.HasKey(e => e.VergiId);

                entity.Property(e => e.VergiAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VergiOrani).HasColumnType("decimal(18, 2)");
            });
        }
    }
}
