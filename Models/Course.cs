using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeMVC.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public User? Instructor { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public ICollection<Module> Modules { get; set; } = new List<Module>();

        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();

        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
    }
}