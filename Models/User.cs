using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.Models
{
    public class User
        {
            [Key]
            public int UserId { get; set; }

            [Required]
            [StringLength(100)]
            public string FullName { get; set; } = string.Empty;
        [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            public string PasswordHash { get; set; } = string.Empty;

            public string? PhoneNumber { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.Now;
        }
    }


    //[Required]
    //public string Role { get; set; } = string.Empty;

    //// Navigation properties
    //public ICollection<Course> Courses { get; set; } = new List<Course>();

    //public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    //public ICollection<Submission> Submissions { get; set; } = new List<Submission>();

    //public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

