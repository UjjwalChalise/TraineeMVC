namespace TraineeMVC.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public bool IsDeleted { get; set; } // New property to indicate if the task is deleted

    }
}
