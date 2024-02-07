using Microsoft.Extensions.DependencyInjection;
using RbPharma.Infrastructure.GenericInterfaces.V1;
using RbPharma.Infrastructure.GenericInterfaces.V1.Interfaces;
using RbPharma.Infrastructure.Users.V1.Repositories;
using RbPharma.Infrastructure.Users.V1.Repositories.Interfaces;
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
    }
}
