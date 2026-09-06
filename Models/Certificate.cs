using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeMVC.Models
{
    public class Certificate
    {
        [Key]
        public int CertificateId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public DateTime IssueDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(100)]
        public string CertificateNumber { get; set; } = string.Empty;

        // Navigation properties
        public User? Student { get; set; }

        public Course? Course { get; set; }
    }
}