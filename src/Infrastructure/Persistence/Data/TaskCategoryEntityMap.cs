using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data;

public sealed class TaskCategoryEntityMap : IEntityTypeConfiguration<TaskCategoryEntity>
{
    public void Configure(EntityTypeBuilder<TaskCategoryEntity> entity)
    {
        entity.ToTable("task_categories");

        entity.HasKey(taskCategory => new { taskCategory.TaskItemId, taskCategory.CategoryId });

        entity.HasOne<TaskItemEntity>()
            .WithMany(task => task.TaskCategories)
            .HasForeignKey(taskCategory => taskCategory.TaskItemId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne<CategoryEntity>()
            .WithMany()
            .HasForeignKey(taskCategory => taskCategory.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}