namespace Application.Abstractions.Services;

public interface ICurrentUserContext
{
    Guid? UserId { get; }
}