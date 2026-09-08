using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        [Required]
        public DateTime AttendanceDate { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        // Student who attended
        public Student? Student { get; set; }

        // Course for which attendance was taken
        public Course? Course { get; set; }
    }
}