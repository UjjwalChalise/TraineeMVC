using TraineeMVC.Models;

namespace TraineeMVC.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);

        Task<List<User>> GetAllAsync();

        Task AddAsync(User user);
    }
}