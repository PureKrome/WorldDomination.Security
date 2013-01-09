using System.Security.Claims;
using System.Security.Principal;

namespace WorldDomination.Security
{
    public static class Helpers
    {
        /// <summary>
        /// Quickly generate a fake Claims Principal.
        /// </summary>
        /// <remarks>This is mainly for unit tests.</remarks>
        /// <param name="userData">Optional: some user data. Otherwise, some default fake data is created.</param>
        /// <returns>ClaimsPrincipal with either the provided UserData or some default UserData.</returns>
        public static IPrincipal FakeClaimsPrincipal(UserData userData = null)
        {
            if (userData == null)
            {
                userData = new UserData
                           {
                               DisplayName = "Leah.Culver",
                               PictureUri = "http://i.imgur.com/hVuuJ.png",
                               UserId = "users/1"
                           };
            }

            var identity = new ClaimsIdentity(userData.ToClaims(), "Forms");
            return new ClaimsPrincipal(identity);
        }
    }
}