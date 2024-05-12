using Microsoft.EntityFrameworkCore;

namespace TodoList_Backend.Database
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions options)   :base(options) { }   
        public DbSet<Todo> Todos { get; set; }
    }
}
