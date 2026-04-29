using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data;

public sealed class TaskTagEntityMap : IEntityTypeConfiguration<TaskTagEntity>
{
    public void Configure(EntityTypeBuilder<TaskTagEntity> entity)
    {
        entity.ToTable("task_tags");

        entity.HasKey(taskTag => new { taskTag.TaskItemId, taskTag.TagId });

        entity.HasOne<TaskItemEntity>()
            .WithMany(task => task.TaskTags)
            .HasForeignKey(taskTag => taskTag.TaskItemId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne<TagEntity>()
            .WithMany()
            .HasForeignKey(taskTag => taskTag.TagId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}