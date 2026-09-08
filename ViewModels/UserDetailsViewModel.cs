namespace TraineeMVC.ViewModels;
using System.ComponentModel.DataAnnotations;

public class UserDetailsViewModel
{
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    [StringLength(500)]
    public string? Address { get; set; }

    public string? Email { get; set; }
}