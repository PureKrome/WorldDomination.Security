namespace WorldDomination.Security
{
    public interface ICustomFormsAuthentication
    {
        void SignIn(IUserData userData);
        void SignOut();
    }
}