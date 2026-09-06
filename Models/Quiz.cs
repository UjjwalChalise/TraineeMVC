using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeMVC.Models
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        public int TotalMarks { get; set; }

        // Navigation properties
        public Course? Course { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}