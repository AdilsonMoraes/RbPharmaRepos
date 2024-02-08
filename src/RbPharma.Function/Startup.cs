using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RbPharma.Infrastructure.Contexts.V1;
using RbPharma.IoC.V1;
using System;
using System.Configuration;
using System.Globalization;

[assembly: FunctionsStartup(typeof(RbPharma.Function.Startup))]
namespace RbPharma.Function
{
    public class Startup : FunctionsStartup
    {
        public Startup()
        {
            
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            //Get Configuration Options bind in class
            builder.Services.AddOptions<MyOptions>().Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.GetSection("MyOptions").Bind(settings);
            });

            
            builder.Services.AddDbContext<ContextSql>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings:ConnectionSql")));


            //Regiister Dependency
            DependencyResolver.RegisterServices(builder.Services);
            DependencyResolver.RegisterInfrastructure(builder.Services);
        }




    }
}
