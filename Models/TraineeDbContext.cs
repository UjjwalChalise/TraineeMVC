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
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    }
}