using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public class ProductContext : DbContext {
    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options){
    }
    
    public DbSet<Category> Categories {get;set;}
    public DbSet<Product> Products {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}