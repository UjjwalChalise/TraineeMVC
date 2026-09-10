using Microsoft.EntityFrameworkCore;
using TraineeMVC.Data;
using TraineeMVC.Models;

namespace TraineeMVC.Repositories;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly ApplicationDbContext _context;

    public AuthenticationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserDetails?> GetUserByUsername(string username)
    {
        return await _context.UserDetails
            .FirstOrDefaultAsync(u => u.Username == username);
    }
}