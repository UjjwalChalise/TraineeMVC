using TraineeMVC.Models;
namespace TraineeMVC.Repositories;

public interface IUserRepository
{
    Task<UserDetails?> GetByUsernameAsync(string username);

    Task<bool> UsernameExistsAsync(string username);

    Task AddAsync(UserDetails user);
}