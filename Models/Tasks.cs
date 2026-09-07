using System.ComponentModel.DataAnnotations;

namespace TraineeMVC.Models;

public class Tasks
{
    [Key]
    public int id { get; set; }
    public string name { get; set; }

    public string description { get; set; }
}
