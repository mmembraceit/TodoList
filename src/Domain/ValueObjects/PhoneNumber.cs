namespace Domain.ValueObjects;

public sealed record PhoneNumber
{
    public string CountryCode { get; init; } = string.Empty;

    public string Number { get; init; } = string.Empty;
}