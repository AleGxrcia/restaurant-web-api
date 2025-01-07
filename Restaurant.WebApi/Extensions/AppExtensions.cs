namespace Restaurant.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API"); // Ruta que queremos que tengan por defecto todas nuestras configuraciones de Swagger y nombre de nuestra API.
            });
        }
    }
}
