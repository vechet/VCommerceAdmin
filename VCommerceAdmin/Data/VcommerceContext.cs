using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VCommerceAdmin.Models;

namespace VCommerceAdmin.Data;

public partial class VcommerceContext : DbContext
{
    public VcommerceContext()
    {
    }

    public VcommerceContext(DbContextOptions<VcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<ConfigurationParam> ConfigurationParams { get; set; }

    public virtual DbSet<DocumentFormat> DocumentFormats { get; set; }

    public virtual DbSet<ErrorReport> ErrorReports { get; set; }

    public virtual DbSet<GlobalParam> GlobalParams { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Um> Ums { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");

            entity.HasOne(d => d.Status).WithMany(p => p.Brands)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Brand_Status");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Category_ParentId_Category");

            entity.HasOne(d => d.Status).WithMany(p => p.Categories)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category_Status");
        });

        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.ToTable("Configuration");

            entity.Property(e => e.KeyName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Value).UseCollation("SQL_Latin1_General_CP850_BIN");
        });

        modelBuilder.Entity<ConfigurationParam>(entity =>
        {
            entity.ToTable("ConfigurationParam");

            entity.Property(e => e.ConfiguratonKeyType)
                .HasMaxLength(300)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Value)
                .HasMaxLength(300)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
        });

        modelBuilder.Entity<DocumentFormat>(entity =>
        {
            entity.ToTable("DocumentFormat");

            entity.Property(e => e.ColumnName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.FirstFooterFour)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.FirstFooterOne)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.FirstFooterThree)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.FirstFooterTwo)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.FirstPrintDisplay)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.FirstPrintFileName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.FirstRemark)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Prefix)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.SecondFooterFour)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.SecondFooterOne)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.SecondFooterThree)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.SecondFooterTwo)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.SecondPrintDisplay)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.SecondPrintFileName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.SecondRemark)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.StoreId)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Suffix)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.TransactionTypeColumnName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasComment("1 : Purchased, 2 : SaleReturn, 3 : SaleChanged, 4 : Transfer, 5 : AdjustQty, 6 : AdjustCost, 7 : Sale, 8 : PurchaseReturn")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
        });

        modelBuilder.Entity<ErrorReport>(entity =>
        {
            entity.ToTable("ErrorReport");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Message)
                .HasMaxLength(4000)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
        });

        modelBuilder.Entity<GlobalParam>(entity =>
        {
            entity.ToTable("GlobalParam");

            entity.Property(e => e.KeyName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Value2)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.ToTable("PaymentMethod");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.KeyName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");

            entity.HasOne(d => d.Status).WithMany(p => p.PaymentMethods)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentMethod_Status");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Product");

            entity.Property(e => e.Barcode)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.MaxPoint).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.OpenningBalanceDate).HasColumnType("datetime");
            entity.Property(e => e.Photo).UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ReorderPoint).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.Brand).WithMany()
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_Product_Brand");

            entity.HasOne(d => d.Category).WithMany()
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.ProductType).WithMany()
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductType");

            entity.HasOne(d => d.Status).WithMany()
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Status");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("ProductType");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.KeyName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");

            entity.HasOne(d => d.Status).WithMany(p => p.ProductTypes)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductType_Status");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.KeyName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
        });

        modelBuilder.Entity<Um>(entity =>
        {
            entity.ToTable("Um");

            entity.Property(e => e.Abbreviation)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");

            entity.HasOne(d => d.Status).WithMany(p => p.Ums)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Um_Status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
