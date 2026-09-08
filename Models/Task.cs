using System.ComponentModel.DataAnnotations;
namespace TraineeMVC.Models
{
    public class Task    {
        [Key]
        public int Id { get; set; }
        public String title { get; set; }
        public string description { get; set; }
        public bool IsCompleted { get; set; }
    }
}