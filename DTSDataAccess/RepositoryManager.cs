using DTSContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTSDataAccess
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ITaskManagerRepository> _taskManagerRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _taskManagerRepository = new Lazy<ITaskManagerRepository>(() => new TaskManagerRepository(_repositoryContext));
        }

        public ITaskManagerRepository TaskManager => _taskManagerRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
