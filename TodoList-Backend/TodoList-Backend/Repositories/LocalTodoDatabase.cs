namespace TodoList_Backend.Repositories
{
    public class LocalTodoDatabase : ITodoDatabase
    {
        private readonly List<string> _todos = [];

        public string[] GetTodos()
        {
            return _todos.ToArray();
        }

        public void AddTodo(string todo)
        {
            if (!_todos.Contains(todo))
                _todos.Add(todo);
        }

        public void DeleteTodo(string todo)
        {
            _todos.RemoveAll((dbTodo) => dbTodo == todo);
        }
    }
}
