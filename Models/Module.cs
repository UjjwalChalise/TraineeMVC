namespace TraineeMVC.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}