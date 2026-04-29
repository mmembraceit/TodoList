using Domain.Common;

namespace Domain.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
}