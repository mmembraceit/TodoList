namespace Presentation.Endpoints.Requests;

public sealed record RegisterRequest(
    string Email,
    string Password,
    string FirstName,
    string LastName,
    DateTimeOffset DateOfBirth,
    string? PhoneCountryCode,
    string? PhoneNumber);

public sealed record LoginRequest(string Email, string Password);