using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.Models
{
    public class Student : User
    {
        [Required]
        [StringLength(20)]
        public string StudentCode { get; set; } = string.Empty;

        public string? Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        // Attendance records
        public ICollection<Attendance> Attendances { get; set; }
            = new List<Attendance>();
    }
}