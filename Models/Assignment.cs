using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public int MaxMarks { get; set; }

        public int ModuleId { get; set; }

        // Module this assignment belongs to
        public Module? Module { get; set; }
    }
}