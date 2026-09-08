using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.Models
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }

        [Required]
        [StringLength(150)]
        public string ModuleName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int CourseId { get; set; }

        // Course this module belongs to
        public Course? Course { get; set; }

        // Assignments in this module
        public ICollection<Assignment> Assignments { get; set; }
            = new List<Assignment>();
    }
}