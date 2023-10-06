/*
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
*/