namespace TodoList_Backend.Extensions
{
    public static class CorsConfiguration
    {
        public static void ConfigureCors(this IApplicationBuilder app)
        {
            app.UseCors((options) =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });
        }
    }
}
