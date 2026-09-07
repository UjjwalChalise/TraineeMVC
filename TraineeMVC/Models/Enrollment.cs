namespace MVCappDotNet.Models;

public class Enrollment
{
    public int Id { get; set; }
    public DateTime EnrolledDate { get; set; }
    public string Status { get; set; } // "Active", "Completed", "Dropped"

    public int StudentId { get; set; }
    public User Student { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public ICollection<LessonProgress> LessonProgresses { get; set; }
}
