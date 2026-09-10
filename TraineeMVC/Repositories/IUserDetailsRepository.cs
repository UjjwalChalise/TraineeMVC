using TraineeMVC.Models;

namespace TraineeMVC.Repositories;

public interface IUserDetailsRepository
{
    System.Threading.Tasks.Task<UserDetails?> GetById(int id);
    System.Threading.Tasks.Task<List<UserDetails>> GetAll();
    System.Threading.Tasks.Task Create(UserDetails user);
    System.Threading.Tasks.Task Update(UserDetails user);
    System.Threading.Tasks.Task Delete(int id);
}