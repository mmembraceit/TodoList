using Domain.Common;

namespace Domain.Entities;

public sealed class Tag : BaseEntity
{
    public string Name { get; set; } = string.Empty;
}