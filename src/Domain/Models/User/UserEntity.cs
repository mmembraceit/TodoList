using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class UserEntity : BaseEntity
{
    public string Email { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public PhoneNumber? PhoneNumber { get; set; }

    public DateTimeOffset DateOfBirth { get; set; }

    public DateTimeOffset? LastSeenOnline { get; set; }

    public bool IsAdmin { get; set; }
}
