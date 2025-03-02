namespace Rubns.Infrastructure
{
    public static class DependecyContainer
    {
        private const string V = "Enviroment";
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            int level = 120;

            services.AddDbContext<AuthDbContextEFC>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("dbAuth"), options =>
                {
                    options.EnableRetryOnFailure();
                    options.UseCompatibilityLevel(level);
                    options.CommandTimeout(240);
                });
                if (configuration[V].ToString() == "dev")
                {
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });



            return services.ConfigureServices(Assembly.GetExecutingAssembly().Location);

        }
    }
}
