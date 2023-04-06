using DBOnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBOnlineShop.EntityConfiguration;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(b => b.Name).IsRequired();
        
        var brand1 = new Brand() { Id = 1, Name = "Cropp", Country = "Poland" };
        var brand2 = new Brand() { Id = 2, Name = "Bershka", Country = "Spain" };
        var brand3 = new Brand() { Id = 3, Name = "Staff", Country = "Ukraine" };
        var brand4 = new Brand() { Id = 4, Name = "Off-White", Country = "Italy" };

        builder.HasData(brand1, brand2, brand3, brand4);
    }
}