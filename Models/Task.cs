using System.ComponentModel.DataAnnotations;


namespace TraineeMVC.Models
{
    public class Task
    {
        [Key]
        public int id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string IsCompleted { get; set; }
    }
}
