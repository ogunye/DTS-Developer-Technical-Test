using DTSContract;
using DTSDataAccess;
using Microsoft.EntityFrameworkCore;

namespace DTSTaskManagerApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryLayer(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        //public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        //    services.AddDbContext<RepositoryContext>(opts =>
        //    opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("DTSDataAccess")));

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqlConnection");

            services.AddDbContext<RepositoryContext>(options=> 
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("DTSDataAccess")));
        }

    }
}
