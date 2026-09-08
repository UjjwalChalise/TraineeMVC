using System.ComponentModel.DataAnnotations;
namespace TraineeMVC.ViewModels;

public class AttendanceCreateViewModel
{
    [Required]
    public int CourseSessionId { get; set; }

    [Required]
    public int StudentId { get; set; }

    [Required]
    public string Status { get; set; } = "Present";

    [StringLength(500)]
    public string? Remarks { get; set; }
}

public class AttendanceDetailViewModel
{
    public int Id { get; set; }

    public string StudentName { get; set; } = string.Empty;

    public string CourseTitle { get; set; } = string.Empty;

    public DateTime SessionDate { get; set; }

    public string Status { get; set; } = string.Empty;

    public string? Remarks { get; set; }
}
