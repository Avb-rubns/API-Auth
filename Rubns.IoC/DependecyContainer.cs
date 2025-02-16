using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rubns.Application;
using Rubns.Infrastructure;
namespace Rubns.IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddInfrastructure(configuration);
            service.AddApplication();
            return service;
        }
    }
}
