namespace TodoList_Backend.Exceptions
{
    public class TodosNotInitializedException : Exception
    {
        public TodosNotInitializedException() : base("Todo list is not initialized in database!")
        {
        }
    }
}
