using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.ViewModels;

public class AssignmentCreateViewModel
{
    [Required]
    public int CourseId { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? MaximumMarks { get; set; }
}

public class AssignmentUpdateViewModel
{
    public int Id { get; set; }

    [Required]
    public int CourseId { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? MaximumMarks { get; set; }
}

public class AssignmentDetailViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime DueDate { get; set; }

    public decimal? MaximumMarks { get; set; }

    public string CourseTitle { get; set; } = string.Empty;

    public int SubmissionCount { get; set; }
}


public class AssignmentListViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string CourseTitle { get; set; } = string.Empty;

    public DateTime DueDate { get; set; }

    public decimal? MaximumMarks { get; set; }
}


public class AssignmentDeleteViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string CourseTitle { get; set; } = string.Empty;

    public DateTime DueDate { get; set; }
}
