namespace TraineeMVC.ViewModel
{
    public class CourseCreateViewModel
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int? ModuleId { get; set; }
    }

    public class CourseUpdateViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int? ModuleId { get; set; }
    }

    public class CourseDetailViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int? ModuleId { get; set; }

        public string? ModuleName { get; set; }
    }

    public class CourseListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? ModuleName { get; set; }
    }

    public class CourseDeleteViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? ModuleName { get; set; }
    }
}
