namespace TraineeMVC.ViewModel
{
    public class EnrollmentCreateViewModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; } = "Active";
    }

    public class EnrollmentUpdateViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; } = "Active";
    }

    public class EnrollmentDetailViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class EnrollmentListViewModel
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string CourseTitle { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; }

        public string Status { get; set; } = string.Empty;
    }

    public class EnrollmentDeleteViewModel
    {
        public int Id { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string CourseTitle { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
