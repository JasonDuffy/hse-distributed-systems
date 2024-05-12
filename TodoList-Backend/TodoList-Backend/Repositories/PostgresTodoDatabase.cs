using TodoList_Backend.Database;

namespace TodoList_Backend.Repositories
{
    public class PostgresTodoDatabase :ITodoDatabase
    {
        private readonly ApiDBContext context;

        public PostgresTodoDatabase(ApiDBContext apiDBContext)
        {
            context = apiDBContext;
        }

        public string[] GetTodos()
        {
            return context.Todos.Select(todo => todo.Title).ToArray();
        }

        public void AddTodo(string todo)
        {
            var existTodoTitles = context.Todos.FirstOrDefault(t => t.Title == todo);
            if (existTodoTitles is null)
            {
                var todoTitles = new Todo() { Title = todo };
                context.Todos.Add(todoTitles);
                context.SaveChanges();
            }

        }

        public void DeleteTodo(string todo)
        {
            var value = context.Todos.FirstOrDefault(t => t.Title == todo);
            if (value == null)
            {
                return ;
            }
            context.Todos.Remove(value);
            context.SaveChanges();
        }

    }
}
