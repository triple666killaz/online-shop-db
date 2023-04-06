using DBOnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBOnlineShop.EntityConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        
        builder.Property(p => p.Description).HasDefaultValue($"Good item from famous brand!");
        
        // Microsoft.EntityFrameworkCore.DbUpdateException
        builder.ToTable(t => t.HasCheckConstraint("Price", "Price > 0"));
        
        builder.Property(p => p.Description).HasMaxLength(255);

        builder.HasOne(p => p.Brand)
            .WithMany(b => b.Products)
            .OnDelete(DeleteBehavior.Cascade);
        
        var product1 = new Product() 
            { Id = 1, Name = "Coat", Price = 65, Description = "Pretty coat with a few colors", BrandId = 1};
        var product2 = new Product() 
            { Id = 2, Name = "Jeans", Price = 40, Description = "Basic blue jeans", BrandId = 4};
        var product3 = new Product() 
            { Id = 3, Name = "Basic hoodie", Price = 60, Description = "Simple basic hoodie with many colors", BrandId = 1};
        var product4 = new Product() 
            { Id = 4, Name = "Printed T-shirt", Price = 25, BrandId = 3};
        var product5 = new Product() 
            { Id = 5, Name = "Basic T-shirt", Price = 20, Description = "T-shirt with basic colors and no printing", BrandId = 2};
        var product6 = new Product() 
            { Id = 6, Name = "Streetwear trousers", Price = 50, Description = "Fashion trousers for casual wearing", BrandId = 1};
        var product7 = new Product() 
            { Id = 7, Name = "Baseball hat", Price = 15, Description = "Support your favorite team!", BrandId = 3};
        var product8 = new Product() 
            { Id = 8, Name = "Zip hoodie", Price = 60, Description = "Comfortable hoodie for cold weather", BrandId = 2};
        var product9 = new Product()
            { Id = 9, Name = "Sweater", Price = 50, BrandId = 4};
        var product10 = new Product()
            { Id = 10, Name = "Printed hoodie", Price = 65, Description = "Hoodie with different prints", BrandId = 2};
        
        builder.HasData(product1, product2, product3, product4, product5, product6, product7, product8, product9, product10);

    }
}