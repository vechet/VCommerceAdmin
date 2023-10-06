using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VCommerceAdmin.Models;

namespace VCommerceAdmin.Data;

public partial class VcommerceContext : IdentityDbContext<IdentityUser>
{
    public VcommerceContext(DbContextOptions<VcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<AuditLogAction> AuditLogActions { get; set; }

    public virtual DbSet<AuditLogController> AuditLogControllers { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<ConfigurationParam> ConfigurationParams { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerShippingAddress> CustomerShippingAddresses { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<DocumentFormat> DocumentFormats { get; set; }

    public virtual DbSet<ErrorReport> ErrorReports { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<GlobalParam> GlobalParams { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<PhotoAndVideo> PhotoAndVideos { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductStore> ProductStores { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<ProductUmPrice> ProductUmPrices { get; set; }

    public virtual DbSet<SaleOrder> SaleOrders { get; set; }

    public virtual DbSet<SaleOrderDetail> SaleOrderDetails { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierType> SupplierTypes { get; set; }

    public virtual DbSet<Um> Ums { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.ToTable("AuditLog");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.TransactionKeyValue).HasMaxLength(100);

            entity.HasOne(d => d.AuditLogAction).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.AuditLogActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditLog_AuditLogAction");

            entity.HasOne(d => d.AuditLogController).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.AuditLogControllerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditLog_AuditLogController");
        });

        modelBuilder.Entity<AuditLogAction>(entity =>
        {
            entity.ToTable("AuditLogAction");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.KeyName)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
        });

        modelBuilder.Entity<AuditLogController>(entity =>
        {
            entity.ToTable("AuditLogController");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.KeyName)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
        });

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
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");

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
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");

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

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("Currency");

            entity.Property(e => e.Abbreviate)
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
            entity.Property(e => e.RoundValue).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Status).WithMany(p => p.Currencies)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Currency_Status");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ContactName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CreditLimited).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Fax)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.OpenningBalance).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.OpenningBalanceDate).HasColumnType("datetime");
            entity.Property(e => e.Phone1)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Phone2)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Vatin)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");
            entity.Property(e => e.Website)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");

            entity.HasOne(d => d.CustomerType).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_CustomerType");

            entity.HasOne(d => d.Status).WithMany(p => p.Customers)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Status");
        });

        modelBuilder.Entity<CustomerShippingAddress>(entity =>
        {
            entity.ToTable("CustomerShippingAddress");

            entity.Property(e => e.AddressDisplay)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Latitude)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Longitude)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerShippingAddresses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerShippingAddress_Customer");

            entity.HasOne(d => d.Status).WithMany(p => p.CustomerShippingAddresses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerShippingAddress_Status");
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.ToTable("CustomerType");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");
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

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Gender_1");

            entity.ToTable("Gender");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Status).WithMany(p => p.Genders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gender_Status");
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
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Status).WithMany(p => p.PaymentMethods)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentMethod_Status");
        });

        modelBuilder.Entity<PhotoAndVideo>(entity =>
        {
            entity.ToTable("PhotoAndVideo");

            entity.Property(e => e.FileName)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP850_BIN");

            entity.HasOne(d => d.Brand).WithMany(p => p.PhotoAndVideos)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_PhotoAndVideo_Brand");

            entity.HasOne(d => d.Category).WithMany(p => p.PhotoAndVideos)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_PhotoAndVideo_Category");

            entity.HasOne(d => d.Product).WithMany(p => p.PhotoAndVideos)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_PhotoAndVideo_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Barcode)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.OpenningBalanceDate).HasColumnType("datetime");
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_Product_Brand");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductType");

            entity.HasOne(d => d.Status).WithMany(p => p.Products)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Status");
        });

        modelBuilder.Entity<ProductStore>(entity =>
        {
            entity.ToTable("ProductStore");

            entity.Property(e => e.MaxPoint).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.QtyAvailable).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.QtyOnHand).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ReorderPoint).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductStores)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductStore_Product");

            entity.HasOne(d => d.Store).WithMany(p => p.ProductStores)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductStore_Store");
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
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Status).WithMany(p => p.ProductTypes)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductType_Status");
        });

        modelBuilder.Entity<ProductUmPrice>(entity =>
        {
            entity.ToTable("ProductUmPrice");

            entity.Property(e => e.Multiplier).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductUmPrices)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductUmPrice_Product");

            entity.HasOne(d => d.Um).WithMany(p => p.ProductUmPrices)
                .HasForeignKey(d => d.UmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductUmPrice_Um");
        });

        modelBuilder.Entity<SaleOrder>(entity =>
        {
            entity.ToTable("SaleOrder");

            entity.Property(e => e.ClosedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepositAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ExchangeRate).HasColumnType("decimal(24, 10)");
            entity.Property(e => e.GrandTotalAmount)
                .HasComment("Amount after discount invoice")
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.InternalMemo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .HasComment("1= Pending, 2 = Purchased, 3 = Reject")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentReferenceNo)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ReferenceNo)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.RemainAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.SaleDate).HasColumnType("datetime");
            entity.Property(e => e.SaleOrderNo)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.TotalAmount)
                .HasComment("Amount before discount invoice and deposit")
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TotalAmountAfterDiscount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TotalAmountAfterItemDiscount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TotalItemDiscountAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionFlag).HasComment("Pending, Sale, Deleted");
            entity.Property(e => e.VatAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.VatPercentage).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Currency).WithMany(p => p.SaleOrders)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleOrder_Currency");

            entity.HasOne(d => d.Customer).WithMany(p => p.SaleOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleOrder_Customer");

            entity.HasOne(d => d.CustomerShippingAddress).WithMany(p => p.SaleOrders)
                .HasForeignKey(d => d.CustomerShippingAddressId)
                .HasConstraintName("FK_SaleOrder_CustomerShippingAddress");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.SaleOrders)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleOrder_PaymentMethod");

            entity.HasOne(d => d.Store).WithMany(p => p.SaleOrders)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleOrder_Store");
        });

        modelBuilder.Entity<SaleOrderDetail>(entity =>
        {
            entity.ToTable("SaleOrderDetail");

            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.GrandTotalAmount)
                .HasComment("Amount after disount on item")
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Memo)
                .HasMaxLength(300)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Price)
                .HasComment("Price has changed by cashier in backend sale module")
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Qty).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.QtySold).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TotalAmount)
                .HasComment("Amount before disount on item,Amount=Qty* Price")
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TotalQty).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleOrderDetail_Product");

            entity.HasOne(d => d.SaleOrder).WithMany(p => p.SaleOrderDetails)
                .HasForeignKey(d => d.SaleOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleOrderDetail_SaleOrder");

            entity.HasOne(d => d.Um).WithMany(p => p.SaleOrderDetails)
                .HasForeignKey(d => d.UmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleOrderDetail_Um");
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
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.ToTable("Store");

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Fax)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.InvoiceName)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ShortcutInvoice)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Vatin)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");
            entity.Property(e => e.Website)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");

            entity.HasOne(d => d.Status).WithMany(p => p.Stores)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Store_Status");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Stores)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Store_GlobalParam");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Supplier");

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ContactName)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CreditLimited).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Fax)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.OpenningBalance).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.OpenningBalanceDate).HasColumnType("datetime");
            entity.Property(e => e.Phone1)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Phone2)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");
            entity.Property(e => e.Website)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");

            entity.HasOne(d => d.Status).WithMany()
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_Status");

            entity.HasOne(d => d.SupplierType).WithMany()
                .HasForeignKey(d => d.SupplierTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_SupplierType");
        });

        modelBuilder.Entity<SupplierType>(entity =>
        {
            entity.ToTable("SupplierType");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Memo)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");
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
            entity.Property(e => e.Version).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Status).WithMany(p => p.Ums)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Um_Status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
