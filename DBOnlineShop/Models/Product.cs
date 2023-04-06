using System.ComponentModel.DataAnnotations;

namespace DBOnlineShop.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public virtual Brand? Brand { get; set; }
    public int? BrandId { get; set; }
    public virtual List <Review> Reviews { get; set; } = new();
    //TODO : create variable for gender type of product
    //TODO : create variable for colors for specific product
    
    public double? GetOverallRating()
    {
        double? allRatings = 0;
        foreach (var r in this.Reviews)
        {
            allRatings += r.ProductRate;
        }

        if (allRatings.HasValue)
            return Math.Round(allRatings.Value / Reviews.Count, 2);
        
        return default(double);
    }
}
