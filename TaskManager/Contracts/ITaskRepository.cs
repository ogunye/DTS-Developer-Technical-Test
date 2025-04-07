using TaskManagerAPI.Models;

namespace TaskManagerAPI.Contracts
{
    public interface ITaskRepository
    {
        Task<bool> CreateTask(TaskFile taskFile);
        Task<bool> UpdateTask(TaskFile taskFile);
        Task<bool> DeleteTask(Guid id);
        Task<TaskFile?> GetTaskById(Guid id);
        Task<ICollection<TaskFile>> GetAllTasks();
        Task<bool> Save();
    }
}
