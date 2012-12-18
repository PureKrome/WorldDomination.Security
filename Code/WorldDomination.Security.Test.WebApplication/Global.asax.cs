using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WorldDomination.Security.Test.WebApplication
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        //protected void Application_AuthenticateRequest()
        //{
        //    // Handle custom cookies. Nom-nom-noms.
        //    CustomFormsAuthentication.AuthenticateRequestDecryptCustomFormsAuthenticationTicket<UserData>(Context);
        //}
    }
}