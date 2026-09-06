namespace TraineeMVC.Models
{
    public class TraineeDbContext
    {

        TraineeDbContext()
        {
            //Constructor logic here
        }
        public TraineeDbContext(DbContextOptions<TraineeDbContext> options)
             : base(options)
        {
        }

        public DbSet<Task> Trainees { get; set; }
    }
}
