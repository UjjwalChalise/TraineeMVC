namespace TraineeMVC.ViewModel
{
    public class AssignmentCreateViewModel
    {
        public int CourseId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public decimal? MaximumMarks { get; set; }
    }

    public class AssignmentUpdateViewModel
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public decimal? MaximumMarks { get; set; }
    }

    public class AssignmentDetailViewModel
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string CourseTitle { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public decimal? MaximumMarks { get; set; }
    }

    public class AssignmentListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string CourseTitle { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }

        public decimal? MaximumMarks { get; set; }
    }

    public class AssignmentDeleteViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string CourseTitle { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }
    }
}
