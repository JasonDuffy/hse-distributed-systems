
using Microsoft.EntityFrameworkCore;
using TodoList_Backend.Exceptions;
using TodoList_Backend.Extensions;
using TodoList_Backend.Model;

namespace TodoList_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddEnvironmentVariables();

            var isDevelopment = builder.Environment.IsDevelopment();
            var frontendUrl = builder.Configuration["FrontendUrl"] ?? 
                              throw new AppSettingNotDefinedException("FrontendUrl");

            builder.Services.ConfigureServices();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.ConfigureSwagger();

            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApiDBContext>(u => u.UseNpgsql(connection));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ApiDBContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }

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
