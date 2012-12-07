using System.Web.Mvc;
using AttributeRouting;
using AttributeRouting.Web.Mvc;

namespace WorldDomination.Security.Test.WebApplication.Areas.Authentication.Controllers
{
    [RouteArea("Authentication")]
    public class AuthenticationController : Controller
    {
        [GET("Index")] // Authentication/Index
        [GET("")] // Index
        [GET("", IsAbsoluteUrl = true)] // 
        public ActionResult Index()
        {
            return View();
        }
    }
}