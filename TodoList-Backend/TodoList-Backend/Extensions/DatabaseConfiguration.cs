using Microsoft.EntityFrameworkCore;
using TodoList_Backend.Database;

namespace TodoList_Backend.Extensions
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApiDbContext>(u => u.UseNpgsql(connectionString));
        }

        public static void RunDatabaseMigrations(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var serviceProvider = scope.ServiceProvider;

            var context = serviceProvider.GetRequiredService<ApiDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            scope.Dispose();
        }
    }
}