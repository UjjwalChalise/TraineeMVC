using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        [Required]
        public string Role { get; set; } = string.Empty;
        // Admin, Teacher, Student

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties

        public ICollection<Course> CoursesTeaching { get; set; }
            = new List<Course>();

        public ICollection<Student> Students { get; set; }
            = new List<Student>();

        public ICollection<Teacher> Teachers { get; set; }
            = new List<Teacher>();
    }
}