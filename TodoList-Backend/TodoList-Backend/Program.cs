
using Microsoft.EntityFrameworkCore;
using TodoList_Backend.Exceptions;
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

            builder.Services.ConfigureServices();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.ConfigureSwagger();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new AppSettingNotDefinedException("ConnectionString");
            builder.Services.AddDatabase(connectionString);

            var app = builder.Build();

            app.Services.RunDatabaseMigrations();

            if (isDevelopment)
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.ConfigureCors();

            app.MapControllers();

            app.Run();
        }
    }
}
