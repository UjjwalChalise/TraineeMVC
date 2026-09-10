using TraineeMVC.Models;

namespace TraineeMVC.Repositories;

public interface IAuthenticationRepository
{
    Task<UserDetails?> GetUserByUsername(string username);
}