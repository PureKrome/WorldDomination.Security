using System.Collections.Generic;
using System.Security.Claims;

namespace WorldDomination.Security
{
    public interface IUserData
    {
        /// <summary>
        /// Unique User Id.
        /// </summary>
        string UserId { get; set; }

        /// <summary>
        /// User's public Display Name.
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        /// A uri to a user's avatar/profile pic.
        /// </summary>
        string PictureUri { get; set; }

        /// <summary>
        /// Convert to the UserData into a list of Claims.
        /// </summary>
        /// <returns>List of claims.</returns>
        IEnumerable<Claim> ToClaims();
    }
}