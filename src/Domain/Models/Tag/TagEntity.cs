using Domain.Common;

namespace Domain.Entities;

public sealed class TagEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
}