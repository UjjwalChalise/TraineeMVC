using Microsoft.AspNetCore.Identity;

namespace TraineeMVC.Models;

public class ApplicationUser: IdentityUser
{
    public UserDetails? UserDetails { get; set; }
}