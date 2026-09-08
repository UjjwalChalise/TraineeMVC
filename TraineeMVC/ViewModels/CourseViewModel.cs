using System.ComponentModel.DataAnnotations;
namespace TraineeMVC.ViewModels;

public class CourseCreateViewModel
{
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; }

    public int? ModuleId { get; set; }
}

public class CourseUpdateViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; }

    public int? ModuleId { get; set; }
}


public class CourseDetailViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? ModuleName { get; set; }

    public int TeacherCount { get; set; }

    public int StudentCount { get; set; }

    public int AssignmentCount { get; set; }
}

public class CourseListViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? ModuleName { get; set; }

    public int StudentCount { get; set; }

    public int AssignmentCount { get; set; }
}


public class CourseDeleteViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? ModuleName { get; set; }

    public int StudentCount { get; set; }
}
