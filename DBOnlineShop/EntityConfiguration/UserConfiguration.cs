using DBOnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBOnlineShop.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Login).IsRequired();
        builder.Property(u => u.Password).IsRequired();

        builder.HasOne(u => u.UserProfile)
            .WithOne(p => p.User);
        
        var user1 = new User() { Id = 1, Login = "login1", Password = "password1" };
        var user2 = new User() { Id = 2, Login = "login2", Password = "password2" };
        var user3 = new User() { Id = 3, Login = "login3", Password = "password3" };
        var user4 = new User() { Id = 4, Login = "login4", Password = "password4" };
        
        builder.HasData(user1, user2, user3, user4);
    }
}