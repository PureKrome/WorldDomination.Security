using System.Security.Claims;

namespace WorldDomination.Security
{
    public static class ClaimsExtensions
    {
        /// <summary>
        /// The UserId claim, if one exists.
        /// </summary>
        /// <param name="claimsPrincipal">ClaimsPrincipal: the claims principal.</param>
        /// <returns>string: the UserId if the claims principal has the claim, else null.</returns>
        public static string WithUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.HasClaim(x => x.Type == ClaimTypes.Uri)
                       ? claimsPrincipal.FindFirst(x => x.Type == ClaimTypes.Uri).Value
                       : null;
        }

        /// <summary>
        /// The Display Name claim, if one exists.
        /// </summary>
        /// <param name="claimsPrincipal">ClaimsPrincipal: the claims principal.</param>
        /// <returns>string: the Display Name if the claims principal has the claim, else null.</returns>
        public static string WithDisplayName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.HasClaim(x => x.Type == ClaimTypes.Name)
                       ? claimsPrincipal.FindFirst(x => x.Type == ClaimTypes.Name).Value
                       : null;
        }

        /// <summary>
        /// The Avatar/Profile picture Uri claim, if one exists.
        /// </summary>
        /// <param name="claimsPrincipal">ClaimsPrincipal: the claims principal.</param>
        /// <returns>string: the Avatar/Profile picture uri if the claims principal has the claim, else null.</returns>
        public static string WithPictureUri(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.HasClaim(x => x.Type == CustomClaimsTypes.PictureUri)
                       ? claimsPrincipal.FindFirst(x => x.Type == CustomClaimsTypes.PictureUri).Value
                       : null;
        }
    }
}