using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeMVC.Models
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(150)]
        public string ModuleName { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Navigation properties
        public Course? Course { get; set; }

        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}