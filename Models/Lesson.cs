namespace TraineeMVC.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string LessonTitle { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}