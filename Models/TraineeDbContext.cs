using Microsoft.EntityFrameworkCore;

namespace TraineeMVC.Models;


public class TraineeDbContext : DbContext
{

    public TraineeDbContext(DbContextOptions<TraineeDbContext> options) : base(options)

    {
     
    }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<LessonProgress> LessonProgresses { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<AnswerOption> AnswerOptions { get; set; }
    public DbSet<QuizAttempt> QuizAttempts { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
  
    

   
}


