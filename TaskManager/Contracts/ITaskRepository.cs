namespace TaskManagerAPI.Contracts
{
    public interface ITaskRepository
    {
        Task<bool> CreateTask(Task task);
        Task<bool> UpdateTask(Task task);
        Task<bool> DeleteTask(Guid id);
        Task<Task?> GetTaskById(Guid id);
        Task<ICollection<Task>> GetAllTasks();
        Task<bool> Save();
    }
}
