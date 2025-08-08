using AspireWebApp.Application.Common.Interfaces;
using System.Security.Claims;

namespace AspireWebApp.WebApi.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public string? UserId => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}