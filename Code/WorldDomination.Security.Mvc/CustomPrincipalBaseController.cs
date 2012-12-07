using System.Web.Mvc;

namespace WorldDomination.Security.Mvc
{
    public abstract class CustomPrincipalBaseController : Controller
    {
        /// <summary>
        /// Override the custom User property with our own -custom- Principal/Identity implimentation.
        /// </summary>
        public new virtual CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }
}
