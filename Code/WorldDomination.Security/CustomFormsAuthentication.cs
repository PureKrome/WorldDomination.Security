using System;
using System.Threading;
using System.Web;
using System.Web.Security;

namespace WorldDomination.Security
{
    public class CustomFormsAuthentication : ICustomFormsAuthentication
    {
        #region ICustomFormsAuthentication Members

        public void SignIn(IUserData userData, HttpResponseBase httpResponseBase)
        {
            string encodedTicket = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(1,
                                                                                             userData.DisplayName,
                                                                                             DateTime.UtcNow,
                                                                                             DateTime.UtcNow.Add(FormsAuthentication.Timeout),
                                                                                             true,
                                                                                             userData.ToString()));
            var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encodedTicket);
            httpResponseBase.Cookies.Add(httpCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        #endregion

        public static void AuthenticateRequestDecryptCustomFormsAuthenticationTicket<T>(HttpContext httpContext)
            where T : IUserData
        {
            string formsCookieName = FormsAuthentication.FormsCookieName;
            var httpCookie = httpContext.Request.Cookies[string.IsNullOrWhiteSpace(formsCookieName)
                                                             ? Guid.NewGuid().ToString()
                                                             : formsCookieName];

            var authenticationTicket = FormsAuthentication.Decrypt(httpCookie.Value);

            var userData = new UserData(authenticationTicket.UserData);

            var principal = new CustomPrincipal(new CustomIdentity(userData), null);
            httpContext.User = principal;
            Thread.CurrentPrincipal = principal;
        }
    }
}