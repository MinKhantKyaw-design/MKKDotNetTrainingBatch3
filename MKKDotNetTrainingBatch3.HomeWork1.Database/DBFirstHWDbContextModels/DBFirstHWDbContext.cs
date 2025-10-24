using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MKKDotNetTrainingBatch3.HomeWork1.Database.DBFirstHWDbContextModels;

public partial class DBFirstHWDbContext : DbContext
{
    public DBFirstHWDbContext()
    {
    }

    public DBFirstHWDbContext(DbContextOptions<DBFirstHWDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblProductCategory> TblProductCategories { get; set; }

    public virtual DbSet<TblSale> TblSales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=MKKBatch3MiniPOS;User ID=sa;Password=P@ssw0rd;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CD273BBE2F");

            entity.ToTable("Tbl_Products");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
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

        modelBuilder.Entity<TblSale>(entity =>
        {
            entity.HasKey(e => e.SaleId);

            entity.ToTable("Tbl_Sales");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.TblSales)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_Sales_Tbl_Products");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
