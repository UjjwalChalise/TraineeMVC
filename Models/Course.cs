using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        // Course belongs to a Teacher
        [Required]
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        // Students enrolled in this course
        public ICollection<Enrollment> Enrollments { get; set; }
            = new List<Enrollment>();

        // Modules in this course
        public ICollection<Module> Modules { get; set; }
            = new List<Module>();

        // Assignments in this course
        public ICollection<Assignment> Assignments { get; set; }
            = new List<Assignment>();

        // Attendance for this course
        public ICollection<Attendance> Attendances { get; set; }
            = new List<Attendance>();
    }
}