namespace TraineeMVC.ViewModel
{
    public class TeacherCreateViewModel
    {
        // User Details
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }

        // Teacher Details
        public string? EmployeeNumber { get; set; }
        public string? Department { get; set; }
        public string? Qualification { get; set; }
    }

    public class TeacherUpdateViewModel
    {
        public int Id { get; set; }
        public int UserDetailsId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? Department { get; set; }
        public string? Qualification { get; set; }
    }

    public class TeacherDetailViewModel
    {
        public int Id { get; set; }
        public int UserDetailsId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? Department { get; set; }
        public string? Qualification { get; set; }
    }

    public class TeacherListViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? EmployeeNumber { get; set; }
        public string? Department { get; set; }
        public string? Qualification { get; set; }
    }

    public class TeacherDeleteViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? EmployeeNumber { get; set; }
        public string? Department { get; set; }
    }
}
