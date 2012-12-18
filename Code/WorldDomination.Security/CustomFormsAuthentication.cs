using System;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Security;

namespace WorldDomination.Security
{
    public class CustomFormsAuthentication : ICustomFormsAuthentication
    {
        const int DefaultTokenLifetimeInHours = 24;

        #region ICustomFormsAuthentication Members

        public void SignIn(IUserData userData)
        {
            // Create the identity & then principal.
            var identity = new ClaimsIdentity(userData.ToClaims(), "Forms");
            var principal = new ClaimsPrincipal(identity);

            // Claims transform.
            principal = FederatedAuthentication.FederationConfiguration.IdentityConfiguration.ClaimsAuthenticationManager.Authenticate(String.Empty, principal);

            // Issue the cookie.
            var sam = FederatedAuthentication.SessionAuthenticationModule;
            if (sam == null)
            {
                throw new Exception("SessionAuthenticationModule is not configured and it needs to be.");
            }

            var token = new SessionSecurityToken(principal, TimeSpan.FromHours(DefaultTokenLifetimeInHours));
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

        //public static void AuthenticateRequestDecryptCustomFormsAuthenticationTicket<T>(HttpContext httpContext)
        //    where T : class, IUserData, new()
        //{
        //    FormsAuthenticationTicket authenticationTicket = null;

        //    // Try and retrieve the cookie.
        //    var httpCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

        //    if (httpCookie != null)
        //    {
        //        // We have a cookie so try and decrypt it and retrieve the authenticationTicket.
        //        authenticationTicket = FormsAuthentication.Decrypt(httpCookie.Value);
        //    }

        //    // Create some empty UserData or use the decrypted data.
        //    var userData = new T();

        //    if (authenticationTicket != null)
        //    {
        //        userData.DeSerialize(authenticationTicket.UserData);
        //    }

        //    // Finally, set up the Principal and Identity.
        //    var principal = new CustomPrincipal(new CustomIdentity(userData), null);

        //    // Remember this Principal.
        //    httpContext.User = principal;
        //    Thread.CurrentPrincipal = principal;
        //}
    }
}