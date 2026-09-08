using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.ViewModels;


public class StudentCreateViewModel
{
    [Required]
    public int UserDetailsId { get; set; }

    [StringLength(50)]
    public string? StudentNumber { get; set; }

    [StringLength(200)]
    public string? Program { get; set; }

    [Range(1, 20)]
    public int? Semester { get; set; }
}


public class StudentUpdateViewModel
{
    public int Id { get; set; }

    [StringLength(50)]
    public string? StudentNumber { get; set; }

    [StringLength(200)]
    public string? Program { get; set; }

    [Range(1, 20)]
    public int? Semester { get; set; }
}


public class StudentDetailViewModel
{
    public int Id { get; set; }

    public string StudentNumber { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string? Program { get; set; }

    public int? Semester { get; set; }

    public int EnrolledCourseCount { get; set; }
}


public class StudentListViewModel
{
    public int Id { get; set; }

    public string StudentNumber { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string? Program { get; set; }

    public int? Semester { get; set; }
}


public class StudentDeleteViewModel
{
    public int Id { get; set; }

    public string StudentNumber { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string? Program { get; set; }
}

