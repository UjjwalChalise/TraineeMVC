namespace MVCappDotNet.Models;

public class QuizAttempt
{
    public int Id { get; set; }
    public DateTime AttemptedAt { get; set; }
    public int Score { get; set; }

    public int StudentId { get; set; }
    public User Student { get; set; }

    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }

    public Grade Grade { get; set; }
}