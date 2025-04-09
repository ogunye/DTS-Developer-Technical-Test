using DTSDomain;
using Microsoft.EntityFrameworkCore;

namespace DTSDataAccess
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        public DbSet<TaskManager> TaskManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskManager>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<TaskManager>()
                .Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(500);
            modelBuilder.Entity<TaskManager>()
                .Property(t => t.DueDate)
                .IsRequired();                
        }
    }
}
