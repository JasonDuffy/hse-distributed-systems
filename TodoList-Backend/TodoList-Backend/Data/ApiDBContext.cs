using Microsoft.EntityFrameworkCore;

namespace TodoList_Backend.Model
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions options)   :base(options) { }   
        public DbSet<Todo> Todos { get; set; }
    }
}
