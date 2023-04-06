using DBOnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBOnlineShop.EntityConfiguration;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.Property(u => u.FirstName).IsRequired();
        builder.Property(u => u.LastName).IsRequired();
        
        builder
            .Property(u => u.Name)
            .HasComputedColumnSql("FirstName + ' ' + LastName");

        builder.Property(u => u.BirthDate).HasDefaultValue(new DateTime(2000, 1, 1));
        
        var userProfile1 = new UserProfile() {Id = 1, FirstName = "Yaroslav", LastName = "Arestov", UserId = 1};
        var userProfile2 = new UserProfile() {Id = 2, FirstName = "Denis", LastName = "Martynyuk", UserId = 2};
        var userProfile3 = new UserProfile() {Id = 3, FirstName = "Vladislav", LastName = "Pushkarov", UserId = 3};
        var userProfile4 = new UserProfile() { Id = 4, FirstName = "Zoya", LastName = "Stronchinskya", UserId = 4};
        
        builder.HasData(userProfile1, userProfile2, userProfile3, userProfile4);
    }
    
}