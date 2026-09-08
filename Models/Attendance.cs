using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeMVC.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Required]
        public DateTime AttendanceDate { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        // Navigation Property
        public Student? Student { get; set; }

        // Navigation Property
        public Course? Course { get; set; }
    }
}