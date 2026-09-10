namespace TraineeMVC.ViewModel
{
    public class CourseTeacherCreateViewModel
    {
        public int CourseId { get; set; }

        public int TeacherId { get; set; }

        public bool IsPrimaryTeacher { get; set; }
    }

    public class CourseTeacherUpdateViewModel
    {
        public int CourseId { get; set; }

        public int TeacherId { get; set; }

        public bool IsPrimaryTeacher { get; set; }
    }

    public class CourseTeacherDetailViewModel
    {
        public int CourseId { get; set; }

        public string CourseTitle { get; set; } = string.Empty;

        public int TeacherId { get; set; }

        public string TeacherName { get; set; } = string.Empty;

        public bool IsPrimaryTeacher { get; set; }
    }

    public class CourseTeacherListViewModel
    {
        public int CourseId { get; set; }

        public string CourseTitle { get; set; } = string.Empty;

        public int TeacherId { get; set; }

        public string TeacherName { get; set; } = string.Empty;

        public bool IsPrimaryTeacher { get; set; }
    }

    public class CourseTeacherDeleteViewModel
    {
        public int CourseId { get; set; }

        public string CourseTitle { get; set; } = string.Empty;

        public int TeacherId { get; set; }

        public string TeacherName { get; set; } = string.Empty;
    }
}
