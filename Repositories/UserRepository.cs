using Microsoft.EntityFrameworkCore;
using TraineeMVC.Models;

namespace TraineeMVC.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TraineeDbContext _context;

        public UserRepository(
            TraineeDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(
            UserDetails user)
        {
            _context.UserDetails.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UsernameExistsAsync(
            string username)
        {
            return await _context.UserDetails
                .AnyAsync(x => x.Username == username);
        }

        public async Task<UserDetails?> LoginAsync(
            string username,
            string passwordHash)
        {
            return await _context.UserDetails
                .FirstOrDefaultAsync(
                    x => x.Username == username
                    && x.PasswordHash == passwordHash);
        }
    }
}