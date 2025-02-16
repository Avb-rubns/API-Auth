namespace Rubns.Auth.API
{
    internal static class ServiceConfigurations
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();

            // Configuración para Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                // Asegúrate de que las versiones estén configuradas correctamente
                var apiVersions = new[] { "1.0", "2.0" };

                foreach (var version in apiVersions)
                {
                    options.SwaggerDoc($"v{version}", new OpenApiInfo
                    {
                        Title = "Rubns.Auth",
                        Version = $"v{version}"
                    });
                }

                // Configurar el tipo de documento y el uso de versiones en los controladores
                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    var versions = apiDesc.CustomAttributes()
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);
                    return versions.Any(v => $"v{v.ToString()}" == docName);
                });
            });

            builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });
            if (builder.Configuration.GetSection(EnvironmentOptions.SectionKey).Get<EnvironmentOptions>() is { } environmentOptions)
            {
                builder.Configuration.AddJsonFile($"appsettings.{environmentOptions.EnvironmentName}.json", optional: true, reloadOnChange: true);
            }

            return builder.Build();
        }
    }
}
