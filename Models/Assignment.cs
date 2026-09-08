public class Assignment
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime DueDate { get; set; }

    public int ModuleId { get; set; }

    public Module Module { get; set; }
}