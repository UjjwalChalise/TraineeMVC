using Microsoft.AspNetCore.Identity;
using TraineeMVC.Models;

namespace TraineeMVC.Services
{
    public class PasswordService
    {
        private readonly PasswordHasher<User> _hasher = new();

        public string HashPassword(User user, string password)
        {
            return _hasher.HashPassword(user, password);
        }

        public bool VerifyPassword(
            User user,
            string enteredPassword,
            string storedHash)
        {
            var result =
                _hasher.VerifyHashedPassword(
                    user,
                    storedHash,
                    enteredPassword);

            return result ==
                   PasswordVerificationResult.Success;
        }
    }
}