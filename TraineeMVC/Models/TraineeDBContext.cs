using Microsoft.EntityFrameworkCore;

public class TraineeDBContext : DbContext{
    public TraineeDBContext(DbContextOptions<TraineeDBContext> options)
        : base(options)
    {
    }

    public DbSet<MVCappDotNet.Models.Task> Tasks { get; set; }
    public DbSet<MVCappDotNet.Models.Quiz> Quizs { get; set; }
}