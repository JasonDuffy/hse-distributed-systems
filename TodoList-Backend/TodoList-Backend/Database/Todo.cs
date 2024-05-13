using System.ComponentModel.DataAnnotations;

namespace TodoList_Backend.Database
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
    }
}
