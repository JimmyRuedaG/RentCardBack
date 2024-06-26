using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RentCard.Models.BD;

public partial class RentCarDbContext : DbContext
{
    public RentCarDbContext()
    {
    }

    public RentCarDbContext(DbContextOptions<RentCarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alquiler> Alquilers { get; set; }

    public virtual DbSet<Carro> Carros { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JIMMY_R;Database=RentCarDB;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alquiler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alquiler__3213E83F0FE149CC");

            entity.ToTable("Alquiler");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AbonoInicial)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("abono_inicial");
            entity.Property(e => e.CedulaCliente).HasColumnName("cedula_cliente");
            entity.Property(e => e.Devuelto)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("devuelto");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.PlacaCarro)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("placa_carro");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("saldo");
            entity.Property(e => e.Tiempo).HasColumnName("tiempo");
            entity.Property(e => e.ValorTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor_total");

            entity.HasOne(d => d.CedulaClienteNavigation).WithMany(p => p.Alquilers)
                .HasForeignKey(d => d.CedulaCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Alquiler__cedula__3E52440B");

            entity.HasOne(d => d.PlacaCarroNavigation).WithMany(p => p.Alquilers)
                .HasForeignKey(d => d.PlacaCarro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Alquiler__placa___3D5E1FD2");
        });

        modelBuilder.Entity<Carro>(entity =>
        {
            entity.HasKey(e => e.Placa).HasName("PK__Carro__0C0574246DB1DDBE");

            entity.ToTable("Carro");

            entity.Property(e => e.Placa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("placa");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.Disponible)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("disponible");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Cedula).HasName("PK__Cliente__415B7BE4ED2F6B8E");

            entity.ToTable("Cliente");

            entity.Property(e => e.Cedula)
                .ValueGeneratedNever()
                .HasColumnName("cedula");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono1");
            entity.Property(e => e.Telefono2)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono2");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pagos__3213E83F710FB733");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlquilerId).HasColumnName("alquiler_id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.Alquiler).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.AlquilerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pagos__alquiler___412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
