using System.ComponentModel.DataAnnotations;

namespace TodoList_Backend.Database
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
