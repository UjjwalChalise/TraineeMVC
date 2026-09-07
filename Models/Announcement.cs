using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.Models;

public class Announcement
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime PostedDate { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }
}