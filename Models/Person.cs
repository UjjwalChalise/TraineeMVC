namespace TraineeMVC.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Role { get; set; } // "Student", "Instructor", "Admin"

    public ICollection<Course> CoursesTaught { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
}