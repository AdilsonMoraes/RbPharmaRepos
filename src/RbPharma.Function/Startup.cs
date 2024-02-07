using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RbPharma.IoC.V1;

[assembly: FunctionsStartup(typeof(RbPharma.Function.Startup))]
namespace RbPharma.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //Get Configuration Options bind in class
            builder.Services.AddOptions<MyOptions>().Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.GetSection("MyOptions").Bind(settings);
            });

            //Regiister Dependency
            DependencyResolver.RegisterServices(builder.Services);
            DependencyResolver.RegisterInfrastructure(builder.Services);
        }
    }
}
