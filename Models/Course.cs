using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeMVC.Models
{
    public class Course

        {
            [Key]
            public int CourseId { get; set; }

            [Required]
            [StringLength(150)]
            public string CourseName { get; set; } = string.Empty;

            public string? Description { get; set; }

            public int TeacherId { get; set; }

            // Teacher who teaches the course
            public Teacher? Teacher { get; set; }

            // Modules inside the course
            public ICollection<Module> Modules { get; set; }
                = new List<Module>();

            // Attendance records for this course
            public ICollection<Attendance> Attendances { get; set; }
                = new List<Attendance>();
        }
    }

    //public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    //public ICollection<Module> Modules { get; set; } = new List<Module>();

    //public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();

    //public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
