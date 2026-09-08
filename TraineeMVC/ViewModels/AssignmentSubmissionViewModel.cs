using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.ViewModels;

public class AssignmentSubmissionCreateViewModel
{
    [Required]
    public int AssignmentId { get; set; }

    [StringLength(10000)]
    public string? Content { get; set; }

    public string? FilePath { get; set; }
}


public class AssignmentSubmissionDetailViewModel
{
    public int Id { get; set; }

    public string AssignmentTitle { get; set; } = string.Empty;

    public string StudentName { get; set; } = string.Empty;

    public DateTime SubmittedAt { get; set; }

    public string? Content { get; set; }

    public string? FilePath { get; set; }

    public decimal? Grade { get; set; }

    public string? Feedback { get; set; }
}
