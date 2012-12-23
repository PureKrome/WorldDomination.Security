namespace WorldDomination.Security
{
    public interface ICustomFormsAuthentication
    {
        void SignIn(IUserData userData, int tokenLifetimeInMinutes = 60*24);
        void SignOut();
    }
}