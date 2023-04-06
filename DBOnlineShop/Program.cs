using DBOnlineShop;
using DBOnlineShop.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var options = OnlineShopContext.GetOptions();
    
using (var db = new OnlineShopContext(options))
{
    var products = db.Products
        .Include(p => p.Reviews)
        .ToList();
    
    foreach (var p in products)
    {
        Console.WriteLine($"{p.Id}. {p.Name} - {p.Price}$\nDescription : {p.Description}");

        if (p.Reviews.Count > 0)
        {
            Console.WriteLine("Reviews : ");
            
            foreach (var r in p.Reviews)
            {
                Console.WriteLine($"{r.Id}). {r.ReviewText} - {r.User?.UserProfile?.Name}\nRate : {r.ProductRate}");
            }
            
            Console.WriteLine($"Overall product rating : {p.GetOverallRating()}");
        }
    }

    var brands = db.Brands.ToList();

    foreach (var b in brands)
    {
        Console.WriteLine($"{b.Id}. {b.Name}({b.Country})\nOverall brand rating : {b.GetOverallRating()}\n ");
    }
}




