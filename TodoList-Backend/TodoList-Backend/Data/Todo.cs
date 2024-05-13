using System.ComponentModel.DataAnnotations;

namespace TodoList_Backend.Model
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
