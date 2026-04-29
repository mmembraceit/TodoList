using Domain.Common;

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

public record PhoneNumber
{
    public string CountryCode { get; set; } = string.Empty;

    public string Number { get; set; } = string.Empty;
}