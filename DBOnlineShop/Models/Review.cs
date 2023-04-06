namespace DBOnlineShop.Models;

public class Review
{
    public int Id { get; set; }
    public string? ReviewText { get; set; }
    public int? ProductRate { get; set; }
    public virtual Product? Product { get; set; }
    public int? ProductId { get; set; }
    public virtual User? User { get; set; }
    public int? UserId { get; set; }
    
}