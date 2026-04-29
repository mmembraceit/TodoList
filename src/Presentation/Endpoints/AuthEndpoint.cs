using Application.Features.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts;

namespace Presentation.Controllers;

[AllowAnonymous]
public sealed class AuthController(IAuthUseCase authUseCase) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<AuthenticationResult>> Register(RegisterRequest request, CancellationToken cancellationToken)
    {
        var result = await authUseCase.RegisterAsync(
            new RegisterUserCommand(
                request.Email,
                request.Password,
                request.FirstName,
                request.LastName,
                request.DateOfBirth,
                request.PhoneCountryCode,
                request.PhoneNumber),
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResult>> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await authUseCase.LoginAsync(new LoginUserCommand(request.Email, request.Password), cancellationToken);

        return Ok(result);
    }
}