using System.Security.Claims;

namespace WorldDomination.Security
{
    public static class ClaimsExtensions
    {
        public static string WithUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.HasClaim(x => x.Type == ClaimTypes.Uri)
                       ? claimsPrincipal.FindFirst(x => x.Type == ClaimTypes.Uri).Value
                       : null;
        }

        public static string WithDisplayName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.HasClaim(x => x.Type == ClaimTypes.Name)
                       ? claimsPrincipal.FindFirst(x => x.Type == ClaimTypes.Name).Value
                       : null;
        }

        public static string WithPictureUri(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.HasClaim(x => x.Type == CustomClaimsTypes.PictureUri)
                       ? claimsPrincipal.FindFirst(x => x.Type == CustomClaimsTypes.PictureUri).Value
                       : null;
        }
    }
}