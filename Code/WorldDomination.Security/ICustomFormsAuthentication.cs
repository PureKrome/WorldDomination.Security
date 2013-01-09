namespace WorldDomination.Security
{
    public interface ICustomFormsAuthentication
    {
        /// <summary>
        /// Sign the user in with Claims.
        /// </summary>
        /// <param name="userData">UserData: the user data.</param>
        /// <param name="tokenLifetimeInMinutes">int: cookie token lifetime.</param>
        void SignIn(IUserData userData, int tokenLifetimeInMinutes = 60*24);

        /// <summary>
        /// Sign out and remove all claims.
        /// </summary>
        void SignOut();
    }
}