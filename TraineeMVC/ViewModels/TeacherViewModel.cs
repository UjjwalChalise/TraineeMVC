using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.ViewModels;


public class TeacherCreateViewModel
{
    [Required]
    public int UserDetailsId { get; set; }

    [StringLength(50)]
    public string? EmployeeNumber { get; set; }

    [StringLength(200)]
    public string? Department { get; set; }

    [StringLength(300)]
    public string? Qualification { get; set; }
}


public class TeacherUpdateViewModel
{
    public int Id { get; set; }

    [StringLength(50)]
    public string? EmployeeNumber { get; set; }

    [StringLength(200)]
    public string? Department { get; set; }

    [StringLength(300)]
    public string? Qualification { get; set; }
}


public class TeacherDetailViewModel
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string? EmployeeNumber { get; set; }

    public string? Department { get; set; }

    public string? Qualification { get; set; }

    public int CourseCount { get; set; }
}


public class TeacherListViewModel
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string? EmployeeNumber { get; set; }

    public string? Department { get; set; }

    public int CourseCount { get; set; }
}


public class TeacherDeleteViewModel
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string? EmployeeNumber { get; set; }

    public string? Department { get; set; }

    public int CourseCount { get; set; }
}