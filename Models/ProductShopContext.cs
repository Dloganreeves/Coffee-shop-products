using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop_Product_List.Models;

public partial class ProductShopContext : DbContext
{
    public ProductShopContext()
    {
    }

    public ProductShopContext(DbContextOptions<ProductShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=CoffeeShop; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3213E83F1C0BDC7D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category).HasMaxLength(40);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(40);
            entity.Property(e => e.Price).HasColumnType("decimal(4, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
