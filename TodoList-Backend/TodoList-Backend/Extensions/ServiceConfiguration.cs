using TodoList_Backend.Repositories;
using TodoList_Backend.Services;

namespace TodoList_Backend.Extensions
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ITodoDatabase, PostgresTodoDatabase>();
            services.AddScoped<ITodoService, TodoService>();
        }
    }
}
