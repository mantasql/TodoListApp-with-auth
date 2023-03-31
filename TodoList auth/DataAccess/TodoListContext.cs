using Microsoft.EntityFrameworkCore;
using TodoList_auth.Models;

namespace TodoList_auth.DataAccess
{
    public class TodoListContext : DbContext
    {
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoEntry> TodoEnties { get; set; }

        public TodoListContext(DbContextOptions<TodoListContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoList>().HasMany(c => c.TodoEntries).WithOne(a => a.TodoList).HasForeignKey(a => a.TodoListId);
            modelBuilder.Entity<TodoEntry>().HasOne(x => x.TodoList);
        }
    }
}
