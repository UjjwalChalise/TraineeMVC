namespace TraineeMVC.ViewModel
{
    public class StudentCreateViewModel
    {
        // User Details
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }

        // Student Details
        public string? StudentNumber { get; set; }
        public string? Program { get; set; }
        public int? Semester { get; set; }
    }

    public class StudentUpdateViewModel
    {
        public int Id { get; set; }
        public int UserDetailsId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? StudentNumber { get; set; }
        public string? Program { get; set; }
        public int? Semester { get; set; }
    }

    public class StudentDetailViewModel
    {
        public int Id { get; set; }
        public int UserDetailsId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? StudentNumber { get; set; }
        public string? Program { get; set; }
        public int? Semester { get; set; }
    }

    public class StudentListViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? StudentNumber { get; set; }
        public string? Program { get; set; }
        public int? Semester { get; set; }
    }

    public class StudentDeleteViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string? StudentNumber { get; set; }

        public string? Program { get; set; }
    }
}
