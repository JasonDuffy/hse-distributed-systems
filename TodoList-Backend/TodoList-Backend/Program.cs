
using TodoList_Backend.Extensions;

namespace TodoList_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddEnvironmentVariables();

            var isDevelopment = builder.Environment.IsDevelopment();
            var frontendUrl = builder.Configuration["FrontendUrl"] ?? "";

            builder.Services.ConfigureServices();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.ConfigureSwagger();

            var app = builder.Build();

            if (isDevelopment)
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.ConfigureCors(frontendUrl);
            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
