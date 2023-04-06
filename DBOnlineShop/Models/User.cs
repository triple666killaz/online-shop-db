namespace DBOnlineShop.Models;

public class User
{
    public int Id { get; set; }
  
    public string? Login { get; set; }
    public string? Password { get; set; }
    public virtual List<Review>? Reviews { get; set; } = new();
    public virtual UserProfile? UserProfile { get; set; }
}
