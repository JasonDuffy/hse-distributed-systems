namespace TodoList_Backend.Repositories
{
    public interface ITodoDatabase
    {

        public string[] GetTodos();
        public void AddTodo(string todo);
        public void DeleteTodo(string todo);
    }
}
