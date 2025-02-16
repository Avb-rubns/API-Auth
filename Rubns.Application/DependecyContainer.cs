
namespace Rubns.Application
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
        {
            return services.ConfigureServices(Assembly.GetExecutingAssembly().Location);
        }
    }
}
