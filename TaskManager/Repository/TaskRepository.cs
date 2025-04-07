using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Contracts;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public TaskRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<bool> CreateTask(TaskFile task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            await _repositoryContext.TaskFiles.AddAsync(task);
            return await Save();
        }

        public async Task<bool> DeleteTask(Guid id)
        {
            await _repositoryContext.TaskFiles
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();
            return await Save();
        }

        public async Task<ICollection<TaskFile>> GetAllTasks() =>
            await _repositoryContext.TaskFiles
                .AsNoTracking()
                .ToListAsync();

        public async Task<TaskFile?> GetTaskById(Guid id)
        {
            return await _repositoryContext.TaskFiles
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
            
        }

        public async Task<bool> Save()
        {
            return await _repositoryContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateTask(TaskFile taskFile)
        {
            if (taskFile == null)
            {
                throw new ArgumentNullException(nameof(taskFile));
            }

            var existingTask = await _repositoryContext.TaskFiles.FindAsync(taskFile.Id);
            if (existingTask == null)
            {
                return false;
            }

            _repositoryContext.Entry(existingTask).CurrentValues.SetValues(taskFile);
            return await Save();
        }
       
    }
}
