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

            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "Rubns.Auth v1");
                option.SwaggerEndpoint("/swagger/v2/swagger.json", "Rubns.Auth v2");
            });

            app.MapControllers();

            return app;
        }

    }
}
