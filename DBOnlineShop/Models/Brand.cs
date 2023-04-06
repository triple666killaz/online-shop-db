namespace DBOnlineShop.Models;

public class Brand
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public virtual List<Product>? Products { get; set; } = new();

    public double? GetOverallRating()
    {
        double? allRatings = 0;

        foreach (var product in Products)
        {
            allRatings += product.GetOverallRating();
        }

        if (allRatings.HasValue)
            return Math.Round(allRatings.Value / Products.Count, 2);

        return default(double);
    }
}