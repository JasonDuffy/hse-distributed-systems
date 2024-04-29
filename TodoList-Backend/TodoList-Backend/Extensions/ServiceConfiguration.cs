using TodoList_Backend.Repositories;
using TodoList_Backend.Services;

namespace TodoList_Backend.Extensions
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<ITodoDatabase, LocalTodoDatabase>(); // Replace LocalTodoDatabase with real database implementation once done
            services.AddSingleton<ITodoService, TodoService>();
        }
    }
}
