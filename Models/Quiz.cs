namespace TraineeMVC.Models;

public class Quiz
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int TotalMarks { get; set; }
    public int TimeLimitMinutes { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public ICollection<Question> Questions { get; set; }
    public ICollection<QuizAttempt> QuizAttempts { get; set; }
}