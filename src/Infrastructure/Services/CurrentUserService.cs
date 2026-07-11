using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;


namespace Infrastructure.Services;

public class CurrentUserService : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(
        IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int UserId
    {
        get
        {
            var claim = _httpContextAccessor
                .HttpContext?
                .User
                .FindFirst(JwtRegisteredClaimNames.Sub);

            return claim == null ? 0 : int.Parse(claim.Value);
        }
    }

    public string Username
    {
        get
        {
            var claim = _httpContextAccessor
                .HttpContext?
                .User
                .FindFirst(JwtRegisteredClaimNames.UniqueName);

            return claim?.Value ?? "";
        }
    }

    public string Rol
    {
        get
        {
            var claim = _httpContextAccessor
                .HttpContext?
                .User
                .FindFirst(ClaimTypes.Role);

            return claim?.Value ?? "";
        }
    }

    public string Ip
    {
        get
        {
            return _httpContextAccessor
                .HttpContext?
                .Connection
                .RemoteIpAddress?
                .ToString()
                ?? "";
        }
    }

    public string UserAgent
    {
        get
        {
            return _httpContextAccessor
                .HttpContext?
                .Request
                .Headers["User-Agent"]
                .ToString()
                ?? "";
        }
    }
}