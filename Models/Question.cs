namespace TraineeMVC.Models;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Type { get; set; } // "MCQ", "TrueFalse", "ShortAnswer"

    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }

    public ICollection<AnswerOption> AnswerOptions { get; set; }
}