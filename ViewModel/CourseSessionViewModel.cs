namespace TraineeMVC.ViewModel
{
    public class CourseSessionCreateViewModel
    {
        public int CourseId { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Topic { get; set; }
    }

    public class CourseSessionUpdateViewModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Topic { get; set; }
    }

    public class CourseSessionDetailViewModel
    {
        public int Id { get; set; }

        public int CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public DateTime SessionDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Topic { get; set; }
    }

    public class CourseSessionListViewModel
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public DateTime SessionDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Topic { get; set; }
    }

    public class CourseSessionDeleteViewModel
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public DateTime SessionDate { get; set; }
        public string? Topic { get; set; }
    }
}
