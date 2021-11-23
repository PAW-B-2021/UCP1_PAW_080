using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_080.Models
{
    public partial class JualBarangContext : DbContext
    {
        public JualBarangContext()
        {
        }

        public JualBarangContext(DbContextOptions<JualBarangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barang> Barangs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Pembayaran> Pembayarans { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdBarang);

                entity.ToTable("Barang");

                entity.Property(e => e.IdBarang)
                    .ValueGeneratedNever()
                    .HasColumnName("id_barang");

                entity.Property(e => e.Harga).HasColumnName("harga");

                entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");

                entity.Property(e => e.NamaBarang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_barang");

                entity.Property(e => e.Stok).HasColumnName("stok");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.Barangs)
                    .HasForeignKey(d => d.IdSupplier)
                    .HasConstraintName("FK_Barang_Supplier");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("id_customer");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alamat");

                entity.Property(e => e.NamaPembeli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_pembeli");

                entity.Property(e => e.NoTelp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("no_telp");
            });

            modelBuilder.Entity<Pembayaran>(entity =>
            {
                entity.HasKey(e => e.IdPembayaran);

                entity.ToTable("Pembayaran");

                entity.Property(e => e.IdPembayaran)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pembayaran");

                entity.Property(e => e.IdTransaksi).HasColumnName("id_transaksi");

                entity.Property(e => e.TglBayar)
                    .HasColumnType("datetime")
                    .HasColumnName("tgl_bayar");

                entity.Property(e => e.TotalBayar).HasColumnName("total_bayar");

                entity.HasOne(d => d.IdTransaksiNavigation)
                    .WithMany(p => p.Pembayarans)
                    .HasForeignKey(d => d.IdTransaksi)
                    .HasConstraintName("FK_Pembayaran_Transaksi");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.IdSupplier);

                entity.ToTable("Supplier");

                entity.Property(e => e.IdSupplier)
                    .ValueGeneratedNever()
                    .HasColumnName("id_supplier");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alamat");

                entity.Property(e => e.NamaSupplier)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_supplier");

                entity.Property(e => e.NoTelp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("no_telp");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("id_transaksi");

                entity.Property(e => e.IdBarang).HasColumnName("id_barang");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("datetime")
                    .HasColumnName("tanggal");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Transaksi_Customer");

                entity.HasOne(d => d.IdTransaksiNavigation)
                    .WithOne(p => p.Transaksi)
                    .HasForeignKey<Transaksi>(d => d.IdTransaksi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaksi_Barang");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
