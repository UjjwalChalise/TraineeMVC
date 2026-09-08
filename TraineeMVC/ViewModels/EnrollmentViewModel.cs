using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.ViewModels;

public class EnrollmentCreateViewModel
{
    [Required]
    public int StudentId { get; set; }

    [Required]
    public int CourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }
        = DateTime.UtcNow;

    [Required]
    public string Status { get; set; } = "Active";
}
public class EnrollmentDetailViewModel
{
    public int Id { get; set; }

    public string StudentName { get; set; } = string.Empty;

    public string CourseTitle { get; set; } = string.Empty;

    public DateTime EnrollmentDate { get; set; }

    public string Status { get; set; } = string.Empty;
}


public class EnrollmentListViewModel
{
    public int Id { get; set; }

    public string StudentName { get; set; } = string.Empty;

    public string CourseTitle { get; set; } = string.Empty;

    public DateTime EnrollmentDate { get; set; }

    public string Status { get; set; } = string.Empty;
}
