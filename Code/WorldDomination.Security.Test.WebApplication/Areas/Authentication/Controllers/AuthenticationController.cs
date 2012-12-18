using System.Web.Mvc;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using WorldDomination.Security.Mvc;
using WorldDomination.Security.Test.WebApplication.Areas.Authentication.Models;

namespace WorldDomination.Security.Test.WebApplication.Areas.Authentication.Controllers
{
    [RouteArea("Authentication")]
    public class AuthenticationController : CustomPrincipalBaseController
    {
        private readonly ICustomFormsAuthentication _customFormsAuthentication;
        public AuthenticationController()
        {
            // Not bothering with IoC for this very simple example.
            _customFormsAuthentication = new CustomFormsAuthentication();
        }

        [GET("Index")] // Authentication/Index
        [GET("")] // Index
        [GET("", IsAbsoluteUrl = true)] // 
        public ActionResult Index()
        {
            var viewModel = new IndexViewModel
                            {
                                Authentication = new AuthenticationViewModel(User),
                                Title = "<3 Hi there <3"
                            };
            return View(viewModel);
        }

        [GET("SignIn")]
        public RedirectToRouteResult SignIn()
        {
            var userData = new UserData
                           {
                               DisplayName = "Leah.Culver",
                               PictureUri = "http://i.imgur.com/hVuuJ.png",
                               UserId = "users/69"
                           };
            _customFormsAuthentication.SignIn(userData, false, Response);

            return RedirectToAction("Index");
        }

        [GET("SignOut")]
        public RedirectToRouteResult SignOut()
        {
            _customFormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }
    }
}