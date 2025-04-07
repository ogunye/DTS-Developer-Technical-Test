using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTSContract
{
    public interface IRepositoryManager
    {
        ITaskManagerRepository TaskManager { get; }
      
        Task SaveAsync();
    }
}
