using System.Reflection;

namespace TraineeMVC.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } // "Draft", "Published"

    public int InstructorId { get; set; }
    public User Instructor { get; set; }

    public ICollection<Module> Modules { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<Quiz> Quizzes { get; set; }
    public ICollection<Assignment> Assignments { get; set; }
    public ICollection<Announcement> Announcements { get; set; }
}
