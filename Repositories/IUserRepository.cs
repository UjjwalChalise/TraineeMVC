using TraineeMVC.Models;

namespace TraineeMVC.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(UserDetails user);

        Task<UserDetails?> LoginAsync(
            string username,
            string passwordHash);

        Task<bool> UsernameExistsAsync(
            string username);
    }
}