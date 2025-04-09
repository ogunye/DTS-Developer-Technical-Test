using DTSContract;
using DTSDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTSDataAccess
{
    public class TaskManagerRepository : RepositoryBase<TaskManager>, ITaskManagerRepository
    {
        public TaskManagerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void AddTask(TaskManager task)
        {
            Create(task);
        }
        public void DeleteTask(TaskManager task)
        {
            Delete(task);
        }
        public async Task<TaskManager?> GetTaskManagerAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(x => x.Id.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<TaskManager>> GetAllTaskManagersAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public void UpdateTask(TaskManager task) => Update(task);
    }
}
