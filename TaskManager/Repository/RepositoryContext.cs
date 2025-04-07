using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Repository
{
    public class RepositoryContext : DbContext
    {
        protected RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskFile> TaskFiles { get; set; }

    }
}
