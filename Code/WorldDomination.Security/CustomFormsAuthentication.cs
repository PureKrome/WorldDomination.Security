using System;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Security.Claims;

namespace WorldDomination.Security
{
    public class CustomFormsAuthentication : ICustomFormsAuthentication
    {
        #region ICustomFormsAuthentication Members

        /// <summary>
        /// Sign the user in with Claims.
        /// </summary>
        /// <param name="userData">UserData: the user data.</param>
        /// <param name="tokenLifetimeInMinutes">int: cookie token lifetime.</param>
        public void SignIn(IUserData userData, int tokenLifetimeInMinutes = 60*24)
        {
            // Create the identity & then principal.
            var identity = new ClaimsIdentity(userData.ToClaims(), "Forms");
            var principal = new ClaimsPrincipal(identity);

            // Claims transform.
            principal =
                FederatedAuthentication.FederationConfiguration.IdentityConfiguration.ClaimsAuthenticationManager
                                       .Authenticate(String.Empty, principal);

            // Issue the cookie.
            var sam = FederatedAuthentication.SessionAuthenticationModule;
            if (sam == null)
            {
                throw new Exception("SessionAuthenticationModule is not configured and it needs to be.");
            }

            var token = new SessionSecurityToken(principal, TimeSpan.FromHours(tokenLifetimeInMinutes));
            sam.WriteSessionTokenToCookie(token);
        }

        /// <summary>
        /// Sign out and remove all claims.
        /// </summary>
        public void SignOut()
        {
            // Clear the cookie.
            var sam = FederatedAuthentication.SessionAuthenticationModule;
            if (sam == null)
            {
                throw new Exception("SessionAuthenticationModule is not configured and it needs to be.");
            }

            sam.SignOut();
        }

        #endregion
    }
}