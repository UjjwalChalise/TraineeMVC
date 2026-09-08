using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.Models
{
    public class Teacher : User
    {
        [Required]
        [StringLength(20)]
        public string EmployeeCode { get; set; } = string.Empty;

        public string? Specialization { get; set; }

        public string? Qualification { get; set; }

        // Courses taught by teacher
        public ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}