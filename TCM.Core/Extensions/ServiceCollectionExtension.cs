using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TCM.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection services)
        {

            services.AddServices();

            return services;
        }

        private static void AddServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

    }
}
