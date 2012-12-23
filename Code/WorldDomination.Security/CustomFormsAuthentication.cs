using System;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Security.Claims;

namespace WorldDomination.Security
{
    public class CustomFormsAuthentication : ICustomFormsAuthentication
    {
        #region ICustomFormsAuthentication Members

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