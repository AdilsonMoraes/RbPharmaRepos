using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RbPharma.Infrastructure.V1.Interfaces;
using RbPharma.Services.V1;
using RbPharma.Services.V1.Interfaces;

namespace RbPharma.IoC.V1
{
    public static class DependencyResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }

        public static void RegisterInfrastructure(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void RegisterLogging(this IServiceCollection services)
        {
            services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
        }
    }
}
