using Scalar.AspNetCore;

namespace Rubns.Auth.API
{
    internal static class MiddlewaresConfigurations
    {
        public static WebApplication ConfigureMiddlewares(this WebApplication app)
        {

            app.UseCors(option =>
            {
                option.AllowAnyOrigin();
                option.AllowAnyMethod();
                option.AllowAnyHeader();
            });

            app.UseRouting();
            app.UseHttpsRedirection();


            app.MapControllers();
            app.MapOpenApi();
            app.MapScalarApiReference();

            return app;
        }

    }
}
