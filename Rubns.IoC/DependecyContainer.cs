using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rubns.IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration configuration)
        {
            return service;
        }
    }
}
