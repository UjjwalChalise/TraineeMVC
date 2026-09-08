using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeMVC.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        public string Specialization { get; set; } = string.Empty;

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User? User { get; set; }

        public ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}