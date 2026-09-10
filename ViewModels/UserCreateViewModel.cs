using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserType { get; set; }
    }
}