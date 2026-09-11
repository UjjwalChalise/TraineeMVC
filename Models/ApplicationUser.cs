namespace TraineeMVC.Models;

public class ApplicationUser
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public UserDetails? UserDetails { get; set; }
}