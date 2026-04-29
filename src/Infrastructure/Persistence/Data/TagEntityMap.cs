using Domain.Entities;
using Infrastructure.Persistence.Data.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data;

public sealed class TagEntityMap : BaseMap<TagEntity>
{
    public override void Configure(EntityTypeBuilder<TagEntity> entity)
    {
        base.Configure(entity);

        entity.ToTable("tags");

        entity.Property(tag => tag.Name)
            .HasMaxLength(100)
            .IsRequired();

        entity.HasIndex(tag => tag.Name)
            .IsUnique();
    }
}