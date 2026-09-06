using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeMVC.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public DateTime EnrolledDate { get; set; } = DateTime.Now;

        [Required]
        public string Status { get; set; } = "Active";

        // Navigation properties
        public User? Student { get; set; }

        public Course? Course { get; set; }
    }
}