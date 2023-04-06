using DBOnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBOnlineShop.EntityConfiguration;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.Property(r => r.ReviewText).HasMaxLength(255);
        
        // obsolete version is builder.HasCheckConstraint("ProductRate", "ProductRate > 0 AND ProductRate <= 10");
        builder.ToTable(t => t.HasCheckConstraint("ProductRate", "ProductRate > 0 AND ProductRate <= 10"));
        
        builder.Property(r => r.ProductRate).HasDefaultValue(1);
        
        builder.HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .OnDelete(DeleteBehavior.Cascade);

        
        //TODO : fill with information
        var review1 = new Review()
            { Id = 1, ProductId = 1, ReviewText = "Cool product", ProductRate = 7, UserId = 2 };
        var review2 = new Review()
            { Id = 2, ProductId = 1, ReviewText = "Nice coat!!", ProductRate = 8, UserId = 1 };
        var review3 = new Review()
            { Id = 3, ProductId = 2, ReviewText = "very comfortable jeans", ProductRate = 9, UserId = 3};
        var review4 = new Review()
            { Id = 4, ProductId = 2, ReviewText = "comfortable jeans but quality not so good", ProductRate = 6, UserId = 2};
        var review5 = new Review()
            { Id = 5, ProductId = 3, ReviewText = "nice!", ProductRate = 10, UserId = 2};
        var review6 = new Review()
            { Id = 6, ProductId = 3, ReviewText = "simple = good", ProductRate = 9, UserId = 4};
        var review7 = new Review()
            { Id = 7, ProductId = 4, ReviewText = "cool print with my favourite movie", ProductRate = 8, UserId = 4};
        var review8 = new Review()
            { Id = 8, ProductId = 4, ReviewText = "print not so good", ProductRate = 5, UserId = 3};
        var review9 = new Review()
            { Id = 9, ProductId = 5, ReviewText = "cool basic t-shirt", ProductRate = 8, UserId = 1};
        var review10 = new Review()
            { Id = 10, ProductId = 5, ReviewText = "nice t-shirt", ProductRate = 8, UserId = 3};
        var review11 = new Review()
            { Id = 11, ProductId = 6, ReviewText = "cool fashion trousers", ProductRate = 8, UserId = 2};
        var review12 = new Review()
            { Id = 12, ProductId = 6, ReviewText = "i got wrong size", ProductRate = 2, UserId = 4};
        var review13 = new Review()
            { Id = 13, ProductId = 7, ReviewText = "i hate it!", ProductRate = 1, UserId = 1};
        var review14 = new Review()
            { Id = 14, ProductId = 7, ReviewText = "quality is so bad", ProductRate = 1, UserId = 4};
        var review15 = new Review()
            { Id = 15, ProductId = 8, ReviewText = "i got hoodie with broken zip, but overall it`s cool", ProductRate = 7, UserId = 1};
        var review16 = new Review()
            { Id = 16, ProductId = 8, ReviewText = "great fleece quality", ProductRate = 10, UserId = 3};
        var review17 = new Review()
            { Id = 17, ProductId = 9, ReviewText = "sweater weather", ProductRate = 9, UserId = 4};
        var review18 = new Review()
            { Id = 18, ProductId = 9, ReviewText = "scratchy sweater", ProductRate = 4, UserId = 2};
        var review19 = new Review()
            { Id = 19, ProductId = 10, ReviewText = "bad print quality", ProductRate = 4, UserId = 3};
        var review20 = new Review()
            { Id = 20, ProductId = 10, ReviewText = "i got hoodie with wrong print", ProductRate = 2, UserId = 1};

        builder.HasData(review1, review2, review3, review4,review5,review6,review7,review8,review9,review10);
        builder.HasData(review11, review12, review13, review14,review15,review16,review17,review18,review19,review20);

    }
}