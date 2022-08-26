using Microsoft.EntityFrameworkCore;
using TWTodos.Data.EntityConfigs;
using TWTodos.Models;

namespace TWTodos.Data.Contexts;

public class TWTodoContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlite("Data Source=twtodos.sqlite3");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TodoEntityConfig());
    }
}