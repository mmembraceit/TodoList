using Domain.Entities;
using Infrastructure.Persistence.Data.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data;

public sealed class CategoryEntityMap : BaseMap<CategoryEntity>
{
    public override void Configure(EntityTypeBuilder<CategoryEntity> entity)
    {
        base.Configure(entity);

        entity.ToTable("categories");

        entity.Property(category => category.Name)
            .HasMaxLength(100)
            .IsRequired();

        entity.HasIndex(category => category.Name)
            .IsUnique();
    }
}