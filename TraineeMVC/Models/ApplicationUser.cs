namespace TraineeMVC.Models;

public class ApplicationUser
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public UserDetails? UserDetails { get; set; }
}