using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.ViewModels;

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

    // This is a ViewModel/UI property.
    // It is NOT stored in UserDetails.
    [Required]
    public string AccountType { get; set; } = string.Empty;

    // Determines whether a Teacher record should be created
    public bool IsTeacher { get; set; }

    // Determines whether a Student record should be created
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


public class UserDetailsLoginViewModel
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
}