using System.Web;

namespace WorldDomination.Security
{
    public interface ICustomFormsAuthentication
    {
        void SignIn(IUserData userData, bool isPersistent, HttpResponseBase httpResponseBase);
        void SignOut();
    }
}