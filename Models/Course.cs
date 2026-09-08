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

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        public DateTime CreatedDate { get; set; }
            = DateTime.Now;

        public ICollection<Module> Modules { get; set; }
            = new List<Module>();

        public ICollection<Assignment> Assignments { get; set; }
            = new List<Assignment>();

        public ICollection<Attendance> Attendances { get; set; }
            = new List<Attendance>();
    }
}