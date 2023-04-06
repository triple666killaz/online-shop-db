using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DBOnlineShop.Models;

// class for migrations with connection string in .json file
public class ContextFactory : IDesignTimeDbContextFactory<OnlineShopContext> 
{
    public OnlineShopContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder();

        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");

        var config = builder.Build();

        string? connectionString = config.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<OnlineShopContext>();

        optionsBuilder.UseSqlServer(connectionString);

        return new OnlineShopContext(optionsBuilder.Options);
    }
}