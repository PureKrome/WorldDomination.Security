using System.Web;

namespace WorldDomination.Security
{
    public interface ICustomFormsAuthentication
    {
        void SignIn(IUserData userData, HttpResponseBase httpResponseBase);
        void SignOut();
    }
}