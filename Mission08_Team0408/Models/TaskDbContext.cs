using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0408.Models
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
    }
}
