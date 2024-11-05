using System;
using System.Collections.Generic;
using BlazorApp1.Data.Entities;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data;

public partial class DbProject1Context : DbContext
{
    public DbProject1Context()
    {
    }

    public DbProject1Context(DbContextOptions<DbProject1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Gestiuni> Gestiunis { get; set; }

    public virtual DbSet<Iesiri> Iesiris { get; set; }

    public virtual DbSet<IesiriDetaliu> IesiriDetalius { get; set; }

    public virtual DbSet<Intrari> Intraris { get; set; }

    public virtual DbSet<IntrariDetaliu> IntrariDetalius { get; set; }

    public virtual DbSet<Parteneri> Parteneris { get; set; }

    public virtual DbSet<Produse> Produses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-7JUSON1\\SQLEXPRESS;Initial Catalog=DB_Project1;Integrated Security=True; TrustServerCertificate = True; MultipleActiveResultSets=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gestiuni>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_table_gestiuni_1");

            entity.ToTable("gestiuni");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.Cod).HasColumnName("cod");
            entity.Property(e => e.Denumire)
                .HasColumnType("text")
                .HasColumnName("denumire");
        });

        modelBuilder.Entity<Iesiri>(entity =>
        {
            entity.ToTable("iesiri");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.Gestiunea)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("gestiunea");
            entity.Property(e => e.Numar)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("numar");

            entity.HasOne(d => d.GestiuneaNavigation).WithMany(p => p.Iesiris)
                .HasForeignKey(d => d.Gestiunea)
                .HasConstraintName("FK_iesiri_gestiuni");
        });

        modelBuilder.Entity<IesiriDetaliu>(entity =>
        {
            entity.ToTable("iesiri_detaliu");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.Cantitate)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("cantitate");
            entity.Property(e => e.IdIesiri)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id_iesiri");
            entity.Property(e => e.Produs)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("produs");
            entity.Property(e => e.Valoare)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("valoare");

            entity.HasOne(d => d.IdIesiriNavigation).WithMany(p => p.IesiriDetalius)
                .HasForeignKey(d => d.IdIesiri)
                .HasConstraintName("FK_iesiri_detaliu_iesiri1");

            entity.HasOne(d => d.ProdusNavigation).WithMany(p => p.IesiriDetalius)
                .HasForeignKey(d => d.Produs)
                .HasConstraintName("FK_iesiri_detaliu_produse");
        });

        modelBuilder.Entity<Intrari>(entity =>
        {
            entity.ToTable("intrari");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.Gestiune)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("gestiune");
            entity.Property(e => e.Numar)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("numar");
            entity.Property(e => e.Partener)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("partener");

            entity.HasOne(d => d.GestiuneNavigation).WithMany(p => p.Intraris)
                .HasForeignKey(d => d.Gestiune)
                .HasConstraintName("FK_intrari_gestiuni");

            entity.HasOne(d => d.PartenerNavigation).WithMany(p => p.Intraris)
                .HasForeignKey(d => d.Partener)
                .HasConstraintName("FK_intrari_parteneri");
        });

        modelBuilder.Entity<IntrariDetaliu>(entity =>
        {
            entity.ToTable("intrari_detaliu");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.Cantitate)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("cantitate");
            entity.Property(e => e.IdIntrari)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id_intrari");
            entity.Property(e => e.Produs)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("produs");
            entity.Property(e => e.Valoare)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("valoare");

            entity.HasOne(d => d.IdIntrariNavigation).WithMany(p => p.IntrariDetalius)
                .HasForeignKey(d => d.IdIntrari)
                .HasConstraintName("FK_intrari_detaliu_intrari");

            entity.HasOne(d => d.ProdusNavigation).WithMany(p => p.IntrariDetalius)
                .HasForeignKey(d => d.Produs)
                .HasConstraintName("FK_intrari_detaliu_produse");
        });

        modelBuilder.Entity<Parteneri>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_table_parteneri_1");

            entity.ToTable("parteneri");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.Adresa)
                .HasColumnType("text")
                .HasColumnName("adresa");
            entity.Property(e => e.Cod).HasColumnName("cod");
            entity.Property(e => e.Cui)
                .HasColumnType("text")
                .HasColumnName("cui");
            entity.Property(e => e.Denumire)
                .HasColumnType("text")
                .HasColumnName("denumire");
        });

        modelBuilder.Entity<Produse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_table_produse_1");

            entity.ToTable("produse");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.Cod).HasColumnName("cod");
            entity.Property(e => e.Denumire)
                .HasColumnType("text")
                .HasColumnName("denumire");
            entity.Property(e => e.PretUnitar)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("pret_unitar");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
