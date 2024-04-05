namespace System.Security.Claims
{
    public static class ClaimTypeExtension
    {
        public static string? Id(this ClaimsPrincipal user)
        {
            return user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
