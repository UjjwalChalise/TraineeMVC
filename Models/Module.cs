using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeMVC.Models
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }

        [Required]
        public string ModuleName { get; set; } = string.Empty;

        public string? Content { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public Course? Course { get; set; }
    }
}