using MetamodulTradeApp.Core.Constants;

namespace System.Security.Claims
{
    public static class ClaimTypeExtension
    {
        public static string? Id(this ClaimsPrincipal user)
        {
            return user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static bool IsAdmin(this ClaimsPrincipal user) 
        {
            return user.IsInRole(AdminConstants.AdminRole);
        }
    }
}
