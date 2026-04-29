using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public sealed class TodoListDbContext : DbContext
{
    public TodoListDbContext(DbContextOptions<TodoListDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserEntity> Users => Set<UserEntity>();

    public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();

    public DbSet<TagEntity> Tags => Set<TagEntity>();

    public DbSet<TaskItemEntity> Tasks => Set<TaskItemEntity>();

    public DbSet<SubtaskEntity> Subtasks => Set<SubtaskEntity>();

    public DbSet<TaskCategoryEntity> TaskCategories => Set<TaskCategoryEntity>();

    public DbSet<TaskTagEntity> TaskTags => Set<TaskTagEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoListDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}