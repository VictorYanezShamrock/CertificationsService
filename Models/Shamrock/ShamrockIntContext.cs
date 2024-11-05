using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CertsService.Models.Shamrock;

public partial class ShamrockIntContext : DbContext
{
    public ShamrockIntContext()
    {
    }

    public ShamrockIntContext(DbContextOptions<ShamrockIntContext> options)
        : base(options)
    {
    }

    public virtual DbSet<IntlInv> IntlInvs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sint-sap-20;Database=ShamrockINT;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IntlInv>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.GrpoStatus, "TWBS_IX_IntInvs_GRPOS");

            entity.Property(e => e.Cont)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Cont#");
            entity.Property(e => e.Ctns)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CTNS");
            entity.Property(e => e.GrpoStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GRPO_Status");
            entity.Property(e => e.Hbl)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HBL");
            entity.Property(e => e.Ii)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("II#");
            entity.Property(e => e.Inv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("INV#");
            entity.Property(e => e.InvDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("INV DATE");
            entity.Property(e => e.Kg)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KG");
            entity.Property(e => e.LineNum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Line Num");
            entity.Property(e => e.MasterPoNew)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Master PO# New");
            entity.Property(e => e.NetKg)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Net Kg");
            entity.Property(e => e.OfPartialCarton)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("# of  Partial Carton ");
            entity.Property(e => e.OfWholeCartons)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("# of Whole Cartons");
            entity.Property(e => e.PcsPartialCarton)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pcs Partial Carton");
            entity.Property(e => e.PcsWholeCarton)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName(" PCs Whole Carton");
            entity.Property(e => e.Pieces)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PIECES");
            entity.Property(e => e.Po)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PO#");
            entity.Property(e => e.ShamPN)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SHAM P N");
            entity.Property(e => e.ShamrockLot)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Shamrock Lot # ");
            entity.Property(e => e.Skid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SKID #");
            entity.Property(e => e.Supplier)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupplierLot)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Supplier Lot#");
            entity.Property(e => e.UniqueId).HasColumnName("UniqueID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
