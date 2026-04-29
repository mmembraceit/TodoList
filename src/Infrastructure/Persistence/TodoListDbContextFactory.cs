using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence;

public sealed class TodoListDbContextFactory : IDesignTimeDbContextFactory<TodoListDbContext>
{
    public TodoListDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TodoListDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=todolistdb;Username=postgres;Password=postgres");

        return new TodoListDbContext(optionsBuilder.Options);
    }
}