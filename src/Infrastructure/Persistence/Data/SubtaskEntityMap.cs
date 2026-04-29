using Domain.Entities;
using Infrastructure.Persistence.Data.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data;

public sealed class SubtaskEntityMap : BaseMap<SubtaskEntity>
{
    public override void Configure(EntityTypeBuilder<SubtaskEntity> entity)
    {
        base.Configure(entity);

        entity.ToTable("subtasks");

        entity.Property(subtask => subtask.Title)
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(subtask => subtask.IsCompleted)
            .IsRequired();

        entity.HasIndex(subtask => subtask.TaskItemId);
    }
}