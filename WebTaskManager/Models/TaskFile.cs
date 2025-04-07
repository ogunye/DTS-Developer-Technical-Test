namespace WebTaskManager.Models
{
    public class TaskFile
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; } //Completed, Pending, No Action
        public DateTime DateCreated { get; set; } = DateTime.Today;
        public DateTime? DueDate { get; set; }
    }
}
