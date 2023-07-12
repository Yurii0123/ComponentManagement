using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCM.Core.Interfaces;
using TCM.Core.Interfaces.Persistence;
using TCM.Core.Interfaces.Repositories;
using TCM.Infrastructure.Contexts;
using TCM.Infrastructure.Repositories;
using TCM.Infrastructure.Services;

namespace TCM.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext(configuration);
            services.AddRepositories();
            services.AddServices();

            return services;
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)), ServiceLifetime.Transient);
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<ITrainComponentRepository, TrainComponentRepository>();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<ITrainComponentService, TrainComponentService>();
        }

    }
}
