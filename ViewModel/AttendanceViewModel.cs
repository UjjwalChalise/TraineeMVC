namespace TraineeMVC.ViewModel
{
    public class AttendanceCreateViewModel
    {
        public int CourseSessionId { get; set; }
        public int StudentId { get; set; }
        public string Status { get; set; } = "Present";
        public string? Remarks { get; set; }
    }

    public class AttendanceUpdateViewModel
    {
        public int Id { get; set; }
        public int CourseSessionId { get; set; }
        public int StudentId { get; set; }
        public string Status { get; set; } = "Present";
        public string? Remarks { get; set; }
    }

    public class AttendanceDetailViewModel
    {
        public int Id { get; set; }
        public int CourseSessionId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public DateTime SessionDate { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? Remarks { get; set; }
    }

    public class AttendanceListViewModel
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public DateTime SessionDate { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    public class AttendanceDeleteViewModel
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public DateTime SessionDate { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
