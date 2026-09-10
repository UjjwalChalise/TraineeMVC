using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TraineeMVC.Data;
using TraineeMVC.Models;

namespace TraineeMVC.Repositories;

public class UserDetailsRepository : IUserDetailsRepository
{
    private readonly ApplicationDbContext _context;
    private readonly PasswordHasher<UserDetails> _passwordHasher = new();

    public UserDetailsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async System.Threading.Tasks.Task<List<UserDetails>> GetAll()
    {
        return await _context.UserDetails.ToListAsync();
    }

    public async System.Threading.Tasks.Task<UserDetails?> GetById(int id)
    {
        return await _context.UserDetails
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async System.Threading.Tasks.Task Create(UserDetails user)
    {
        user.Password = _passwordHasher.HashPassword(
            user,
            user.Password);

        _context.UserDetails.Add(user);

        await _context.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task Update(UserDetails user)
    {
        var existingUser = await _context.UserDetails
            .FirstOrDefaultAsync(u => u.Id == user.Id);

        if (existingUser == null)
            return;

        existingUser.Username = user.Username;
        existingUser.Role = user.Role;
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.DateOfBirth = user.DateOfBirth;
        existingUser.Address = user.Address;

        // Only change password if a new password was provided
        if (!string.IsNullOrWhiteSpace(user.Password))
        {
            existingUser.Password = _passwordHasher.HashPassword(
                existingUser,
                user.Password);
        }

        await _context.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task Delete(int id)
    {
        var user = await GetById(id);

        if (user == null)
            return;

        _context.UserDetails.Remove(user);

        await _context.SaveChangesAsync();
    }
}