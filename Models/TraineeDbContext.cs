using Microsoft.EntityFrameworkCore;
using System.Data;
namespace MVC.Models
{
    public class TraineeDbContext : DbContext
    {

        public TraineeDbContext(DbContextOptions<TraineeDbContext> options)
             : base(options)
        {
        }

        public DbSet<Task> Trainees { get; set; }
    }
}
