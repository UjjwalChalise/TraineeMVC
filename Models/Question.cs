using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeMVC.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [ForeignKey("Quiz")]
        public int QuizId { get; set; }

        [Required]
        public string QuestionText { get; set; } = string.Empty;

        [Required]
        public string CorrectAnswer { get; set; } = string.Empty;

        // Navigation property
        public Quiz? Quiz { get; set; }
    }
}