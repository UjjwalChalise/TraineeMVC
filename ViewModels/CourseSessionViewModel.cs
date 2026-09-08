using System.ComponentModel.DataAnnotations;
namespace TraineeMVC.ViewModels;

public class CourseSessionCreateViewModel
{
    [Required]
    public int CourseId { get; set; }

    [Required]
    public DateTime SessionDate { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    [StringLength(500)]
    public string? Topic { get; set; }
}

public class CourseSessionDetailViewModel
{
    public int Id { get; set; }

    public string CourseTitle { get; set; } = string.Empty;

    public DateTime SessionDate { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    public string? Topic { get; set; }

    public int AttendanceCount { get; set; }

}