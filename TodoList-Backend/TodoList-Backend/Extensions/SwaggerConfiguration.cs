using Microsoft.OpenApi.Models;

namespace TodoList_Backend.Extensions
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TodoList API",
                    Description = "A simple API to manage a TODO list",
                    Version = "v1"
                });
            });
        }
    }
}
