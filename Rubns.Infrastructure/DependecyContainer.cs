
namespace Rubns.Infrastructure
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection services)
        {

            return services.ConfigureServices(Assembly.GetExecutingAssembly().Location);

        }
    }
}
