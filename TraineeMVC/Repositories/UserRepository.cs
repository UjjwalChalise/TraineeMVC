using Microsoft.EntityFrameworkCore;
using TraineeMVC.Data;
using TraineeMVC.Models;

namespace TraineeMVC.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserDetails?> GetByUsernameAsync(string username)
    {
        return await _context.UserDetails
            .Include(u => u.Teacher)
            .Include(u => u.Student)
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _context.UserDetails
            .AnyAsync(u => u.Username == username);
    }

    public async Task AddAsync(UserDetails user)
    {
        await _context.UserDetails.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}