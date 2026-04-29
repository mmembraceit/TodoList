using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Common;

namespace Infrastructure.Persistence.Data.Maps;
public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> entity)
    {
        entity
            .HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        entity.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        entity.Property(e => e.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
        entity.Property(e => e.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);
        
        entity.HasQueryFilter(e => e.DeletedAt == null);
    }
}
