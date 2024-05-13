using TodoList_Backend.Repositories;
using TodoList_Backend.Services;

namespace TodoList_Backend.Extensions
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services, bool useMemoryDatabase)
        {
            if (!useMemoryDatabase)
            {
                services.AddScoped<ITodoDatabase, PostgresTodoDatabase>();
                services.AddScoped<ITodoService, TodoService>();
            }
            else
            {
                services.AddSingleton<ITodoDatabase, LocalTodoDatabase>();
                services.AddSingleton<ITodoService, TodoService>();
            }
        }
    }
}
