namespace TraineeMVC.Models;

public class AssignmentSubmission
{
    public int Id { get; set; }
    public string FilePath { get; set; }
    public DateTime SubmittedAt { get; set; }

    public int StudentId { get; set; }
    public User Student { get; set; }

    public int AssignmentId { get; set; }
    public Assignment Assignment { get; set; }

    public Grade Grade { get; set; }
}