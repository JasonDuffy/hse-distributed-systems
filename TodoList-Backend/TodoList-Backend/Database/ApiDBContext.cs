using Microsoft.EntityFrameworkCore;

namespace TodoList_Backend.Database
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Todo>? Todos { get; set; }
    }
}
