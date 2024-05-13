
using Microsoft.EntityFrameworkCore;
using TodoList_Backend.Exceptions;
using TodoList_Backend.Extensions;

namespace TodoList_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ShowLicense();

            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddEnvironmentVariables();

            var isDevelopment = builder.Environment.IsDevelopment();
            var useMemoryDb = builder.Configuration.GetValue<bool>("UseMemoryDB");

            builder.Services.ConfigureServices(useMemoryDb);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.ConfigureSwagger();

            if (!useMemoryDb)
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                                       throw new AppSettingNotDefinedException("ConnectionString");
                builder.Services.AddDatabase(connectionString);
            }

            var app = builder.Build();

            if (!useMemoryDb)
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

        private static void ShowLicense()
        {
            Console.WriteLine("HSE Distributed Systems ToDo-List");
            Console.WriteLine("This project is licensed under the GNU General Public License 3.");
            Console.WriteLine("HSE Distributed Systems ToDo-List Copyright (C) 2024 Jason Patrick Duffy (https://github.com/JasonDuffy), Tom Nguyen Dinh (https://github.com/tomhuy-w)");
            Console.WriteLine("This program comes with ABSOLUTELY NO WARRANTY.");
            Console.WriteLine("This is free software, and you are welcome to redistribute it under certain conditions.");
            Console.WriteLine();
        }
    }
}
