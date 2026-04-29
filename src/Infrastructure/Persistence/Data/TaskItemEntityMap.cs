using Domain.Entities;
using Infrastructure.Persistence.Data.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data;

public sealed class TaskItemEntityMap : BaseMap<TaskItemEntity>
{
    public override void Configure(EntityTypeBuilder<TaskItemEntity> entity)
    {
        base.Configure(entity);

        entity.ToTable("tasks");

        entity.Property(task => task.Title)
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(task => task.Description)
            .HasMaxLength(4000);

        entity.Property(task => task.Status)
            .HasConversion<int>()
            .IsRequired();

        entity.HasIndex(task => task.UserId);
        entity.HasIndex(task => task.Status);

        entity.HasMany(task => task.Subtasks)
            .WithOne()
            .HasForeignKey(subtask => subtask.TaskItemId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(task => task.TaskCategories)
            .WithOne()
            .HasForeignKey(taskCategory => taskCategory.TaskItemId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(task => task.TaskTags)
            .WithOne()
            .HasForeignKey(taskTag => taskTag.TaskItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}