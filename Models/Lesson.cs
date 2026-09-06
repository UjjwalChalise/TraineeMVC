using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeMVC.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        [ForeignKey("Module")]
        public int ModuleId { get; set; }

        [Required]
        [MaxLength(150)]
        public string LessonTitle { get; set; } = string.Empty;

        public string? Content { get; set; }

        public int Duration { get; set; }

        // Navigation properties
        public Module? Module { get; set; }

        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}