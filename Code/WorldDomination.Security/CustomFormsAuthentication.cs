using System;
using System.Threading;
using System.Web;
using System.Web.Security;

namespace WorldDomination.Security
{
    public class CustomFormsAuthentication : ICustomFormsAuthentication
    {
        #region ICustomFormsAuthentication Members

        public void SignIn(IUserData userData, bool isPersistent, HttpResponseBase httpResponseBase)
        {
            string encodedTicket =
                FormsAuthentication.Encrypt(new FormsAuthenticationTicket(1,
                                                                          userData.DisplayName,
                                                                          DateTime.UtcNow,
                                                                          DateTime.UtcNow.Add(FormsAuthentication.Timeout),
                                                                          isPersistent,
                                                                          userData.ToString()));
            var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encodedTicket)
                             {
                                 Secure = HttpContext.Current.Request.IsSecureConnection
                             };
            httpResponseBase.Cookies.Add(httpCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        #endregion

        public static void AuthenticateRequestDecryptCustomFormsAuthenticationTicket<T>(HttpContext httpContext)
            where T : class, IUserData, new()
        {
            FormsAuthenticationTicket authenticationTicket = null;

            // Try and retrieve the cookie.
            var httpCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (httpCookie != null)
            {
                // We have a cookie so try and decrypt it and retrieve the authenticationTicket.
                authenticationTicket = FormsAuthentication.Decrypt(httpCookie.Value);
            }

            // Create some empty UserData or use the decrypted data.
            var userData = new T();

            if (authenticationTicket != null)
            {
                userData.DeSerialize(authenticationTicket.UserData);
            }

            // Finally, set up the Principal and Identity.
            var principal = new CustomPrincipal(new CustomIdentity(userData), null);

            // Remember this Principal.
            httpContext.User = principal;
            Thread.CurrentPrincipal = principal;
        }
    }
}