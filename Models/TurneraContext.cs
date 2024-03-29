﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace turnera.Models;

public partial class TurneraContext : DbContext
{
    public TurneraContext()
    {
    }

    public TurneraContext(DbContextOptions<TurneraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

    public virtual DbSet<Entity> Entities { get; set; }

    public virtual DbSet<EntityProfessional> EntityProfessionals { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Professional> Professionals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EfmigrationsHistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Entity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("entity");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(2083)
                .HasColumnName("logo_url");
            entity.Property(e => e.MainPageMessage)
                .HasColumnType("text")
                .HasColumnName("main_page_message");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UrlIdentifier)
                .HasMaxLength(100)
                .HasColumnName("url_identifier");
        });

        modelBuilder.Entity<EntityProfessional>(entity =>
        {
            entity.HasKey(e => new { e.IdEntity, e.IdProfessional }).HasName("PRIMARY");

            entity.ToTable("entity_professional");

            entity.Property(e => e.IdEntity)
                .HasColumnType("int(11)")
                .HasColumnName("id_entity");
            entity.Property(e => e.IdProfessional)
                .HasColumnType("int(11)")
                .HasColumnName("id_professional");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("marca");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.HasIndex(e => e.MarcaId, "marca_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(2000)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("img_url");
            entity.Property(e => e.MarcaId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("marca_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Professional>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("professional");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AvailableTimes)
                .HasMaxLength(1024)
                .HasColumnName("available_times");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
