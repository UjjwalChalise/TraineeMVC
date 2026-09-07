using Microsoft.EntityFrameworkCore;

namespace TraineeMVC.Models
{
    public class TraineeDbContext : DbContext
    {
        public TraineeDbContext(DbContextOptions<TraineeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }
    }
}