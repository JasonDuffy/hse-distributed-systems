using TodoList_Backend.Database;
using TodoList_Backend.Exceptions;

namespace TodoList_Backend.Repositories
{
    public class PostgresTodoDatabase : ITodoDatabase
    {
        private readonly ApiDbContext _context;

        public PostgresTodoDatabase(ApiDbContext apiDbContext)
        {
            _context = apiDbContext;
        }

        public string[] GetTodos()
        {
            CheckTodoListInitialization();

            return _context.Todos!.Select(todo => todo.Title).ToArray();
        }

        public void AddTodo(string todo)
        {
            CheckTodoListInitialization();

            var existTodoTitles = _context.Todos!.FirstOrDefault(t => t.Title == todo);
            if (existTodoTitles is not null)
                return;

            var todoTitles = new Todo() { Title = todo };
            _context.Todos!.Add(todoTitles);
            _context.SaveChanges();

        }

        public void DeleteTodo(string todo)
        {
            CheckTodoListInitialization();

            var value = _context.Todos!.FirstOrDefault(t => t.Title == todo);
            if (value is null)
                return;

            _context.Todos!.Remove(value);
            _context.SaveChanges();
        }

        private void CheckTodoListInitialization()
        {
            if (_context.Todos is null)
                throw new TodosNotInitializedException();
        }
    }
}
