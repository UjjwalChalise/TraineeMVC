namespace TraineeMVC.Models;

public class Assignment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime DueDate { get; set; }
    public int MaxScore { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public ICollection<AssignmentSubmission> Submissions { get; set; }
}