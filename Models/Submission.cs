using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeMVC.Models
{
    public class Submission
    {
        [Key]
        public int SubmissionId { get; set; }

        [ForeignKey("Assignment")]
        public int AssignmentId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public string? FilePath { get; set; }

        public DateTime SubmittedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public Assignment? Assignment { get; set; }

        public User? Student { get; set; }
    }
}