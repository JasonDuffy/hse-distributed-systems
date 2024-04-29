using TodoList_Backend.Repositories;

namespace TodoList_Backend.Services
{
    public interface ITodoService
    {
        public string[] GetTodos();
        public void AddTodo(string todo);
        public void DeleteTodo(string todo);
    }

    public class TodoService : ITodoService
    {
        private readonly ITodoDatabase _todoDatabase;

        public TodoService(ITodoDatabase todoDatabase)
        {
            _todoDatabase = todoDatabase;
        }

        public string[] GetTodos()
        {
            var todos = _todoDatabase.GetTodos();
            return todos;
        }

        public void AddTodo(string todo)
        {
            _todoDatabase.AddTodo(todo);
        }

        public void DeleteTodo(string todo)
        {
            _todoDatabase.DeleteTodo(todo);
        }
    }
}
