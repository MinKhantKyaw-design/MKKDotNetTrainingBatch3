using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MKKDotNetTrainingBatch3.ConsoleApp1.Database.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalesProduct> SalesProducts { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblProductCategory> TblProductCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=MKKBatch3MiniPOS;User ID=sa;Password=P@ssw0rd;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sales__1EE3C41F9F063868");

            entity.Property(e => e.SaleId)
                .ValueGeneratedNever()
                .HasColumnName("SaleID");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DeleteFlag).HasDefaultValue(false);
            entity.Property(e => e.SaleDate).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<SalesProduct>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SaleId).HasColumnName("SaleID");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__SalesProd__Produ__4E88ABD4");

            entity.HasOne(d => d.Sale).WithMany()
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__SalesProd__SaleI__4F7CD00D");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CD273BBE2F");

            entity.ToTable("Tbl_Products");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.DeleteFlag).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblProductCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_ProductCategory");

            entity.Property(e => e.ProductCategoryCode).HasMaxLength(50);
            entity.Property(e => e.ProductCategoryId).ValueGeneratedOnAdd();
            entity.Property(e => e.ProductCategoryName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
