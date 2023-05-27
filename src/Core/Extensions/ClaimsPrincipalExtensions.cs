using System.Security.Claims;

namespace Core.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        return claimsPrincipal?.FindAll(claimType)?.Select(c => c.Value).ToList();
    }

    public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        return Convert.ToInt32(claimsPrincipal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());
    }

    public static string GetUserEmail(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims(ClaimTypes.Email)?.FirstOrDefault();
    }

    public static string GetUserName(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims(ClaimTypes.Name)?.FirstOrDefault();
    }

    public static List<string> GetUserClaims(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims(ClaimTypes.Role);
    }
}
