namespace TraineeMVC.ViewModel
{
    public class AssignmentSubmissionCreateViewModel
    {
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string? FilePath { get; set; }
        public string? Content { get; set; }
    }

    public class AssignmentSubmissionUpdateViewModel
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string? FilePath { get; set; }
        public string? Content { get; set; }
        public decimal? Grade { get; set; }
        public string? Feedback { get; set; }
    }

    public class AssignmentSubmissionDetailViewModel
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public string AssignmentTitle { get; set; } = string.Empty;
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; }
        public string? FilePath { get; set; }
        public string? Content { get; set; }
        public decimal? Grade { get; set; }
        public string? Feedback { get; set; }
    }

    public class AssignmentSubmissionListViewModel
    {
        public int Id { get; set; }
        public string AssignmentTitle { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; }

        public decimal? Grade { get; set; }
    }

    public class AssignmentSubmissionDeleteViewModel
    {
        public int Id { get; set; }

        public string AssignmentTitle { get; set; } = string.Empty;

        public string StudentName { get; set; } = string.Empty;

        public DateTime SubmittedAt { get; set; }
    }
}
