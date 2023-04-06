namespace DBOnlineShop.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public int UserId { get; set; }
    public virtual User? User { get; set; }

}