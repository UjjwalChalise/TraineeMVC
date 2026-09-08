using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeMVC.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime EnrollmentDate { get; set; }
            = DateTime.Now;

        public User? User { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
            = new List<Attendance>();
    }
}