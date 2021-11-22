using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_077.Models
{
    public partial class JajananContext : DbContext
    {
        public JajananContext()
        {
        }

        public JajananContext(DbContextOptions<JajananContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<JenisProduk> JenisProduks { get; set; }
        public virtual DbSet<Pedagang> Pedagangs { get; set; }
        public virtual DbSet<Produk> Produks { get; set; }
        public virtual DbSet<Testimoni> Testimonis { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("admin");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("id_admin");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .HasColumnName("password")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<JenisProduk>(entity =>
            {
                entity.HasKey(e => e.KodeJenisProduk);

                entity.ToTable("jenis_produk");

                entity.Property(e => e.KodeJenisProduk)
                    .ValueGeneratedNever()
                    .HasColumnName("kode_jenis_produk");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nama");
            });

            modelBuilder.Entity<Pedagang>(entity =>
            {
                entity.HasKey(e => e.IdPedagang);

                entity.ToTable("pedagang");

                entity.Property(e => e.IdPedagang)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pedagang");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nama");
            });

            modelBuilder.Entity<Produk>(entity =>
            {
                entity.HasKey(e => e.KodeProduk);

                entity.ToTable("produk");

                entity.Property(e => e.KodeProduk)
                    .ValueGeneratedNever()
                    .HasColumnName("kode_produk");

                entity.Property(e => e.Harga)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("harga");

                entity.Property(e => e.IdPedagang).HasColumnName("id_pedagang");

                entity.Property(e => e.NamaProduk)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nama_produk");

                entity.HasOne(d => d.IdPedagangNavigation)
                    .WithMany(p => p.Produks)
                    .HasForeignKey(d => d.IdPedagang)
                    .HasConstraintName("FK_produk_pedagang");
            });

            modelBuilder.Entity<Testimoni>(entity =>
            {
                entity.HasKey(e => e.IdTestimoni);

                entity.ToTable("Testimoni");

                entity.Property(e => e.IdTestimoni)
                    .ValueGeneratedNever()
                    .HasColumnName("id_testimoni");

                entity.Property(e => e.Deskripsi)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("deskripsi");

                entity.Property(e => e.KodeJenisProduk).HasColumnName("kode_jenis_produk");

                entity.Property(e => e.KodeProduk)
                    .HasMaxLength(10)
                    .HasColumnName("kode_produk")
                    .IsFixedLength(true);

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nama");

                entity.HasOne(d => d.IdTestimoniNavigation)
                    .WithOne(p => p.Testimoni)
                    .HasForeignKey<Testimoni>(d => d.IdTestimoni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Testimoni_produk");

                entity.HasOne(d => d.KodeJenisProdukNavigation)
                    .WithMany(p => p.Testimonis)
                    .HasForeignKey(d => d.KodeJenisProduk)
                    .HasConstraintName("FK_Testimoni_jenis_produk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
