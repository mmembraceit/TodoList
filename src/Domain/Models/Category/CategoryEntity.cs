using Domain.Common;

namespace Domain.Entities;

public sealed class CategoryEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
}