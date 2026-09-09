namespace TraineeMVC.Controllers;

using System.ComponentModel.DataAnnotations;

// namespace TraineeMVC.ViewModels.User;

public class UserCreateViewModel
{
    [Required]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? ProfileImagePath { get; set; }

    // Determines whether the user also has a Teacher record
    public bool IsTeacher { get; set; }

    // Determines whether the user also has a Student record
    public bool IsStudent { get; set; }

    // Teacher information
    public string? EmployeeNumber { get; set; }

    public string? Department { get; set; }

    public string? Qualification { get; set; }

    // Student information
    public string? StudentNumber { get; set; }

    public string? Program { get; set; }

    public int? Semester { get; set; }
}

public class UserDetailsViewModel
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? ProfileImagePath { get; set; }

    public bool IsTeacher { get; set; }

    public bool IsStudent { get; set; }

    public string? StudentNumber { get; set; }

    public string? Program { get; set; }

    public string? EmployeeNumber { get; set; }

    public string? Department { get; set; }
}


public class UserListViewModel
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string? ProfileImagePath { get; set; }

    public bool IsTeacher { get; set; }

    public bool IsStudent { get; set; }
}


public class UserEditViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? ProfileImagePath { get; set; }

    public bool IsTeacher { get; set; }

    public bool IsStudent { get; set; }

    public string? EmployeeNumber { get; set; }

    public string? Department { get; set; }

    public string? Qualification { get; set; }

    public string? StudentNumber { get; set; }

    public string? Program { get; set; }

    public int? Semester { get; set; }
}