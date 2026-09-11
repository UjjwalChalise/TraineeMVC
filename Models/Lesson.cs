namespace TraineeMVC.Models;

public class Lesson
{

    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int OrderIndex { get; set; }

    public int ModuleId { get; set; }
    public Module Module { get; set; }

    public ICollection<Attachment> Attachments { get; set; }
    public ICollection<LessonProgress> LessonProgresses { get; set; }
}