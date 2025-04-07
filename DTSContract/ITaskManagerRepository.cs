using DTSDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTSContract
{
    public interface ITaskManagerRepository
    {
        void AddTask(TaskManager task);
        void DeleteTask(TaskManager task);
        Task<TaskManager?> GetTaskManagerAsync(Guid id, bool trackChanges);
        Task<IEnumerable<TaskManager>> GetAllTaskManagersAsync(bool trackChanges);
    }
}
