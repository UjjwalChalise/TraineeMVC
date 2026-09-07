using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.Models;


public class TaskItem
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string IsCompleted { get; set; }

}