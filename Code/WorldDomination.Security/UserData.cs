using System.Collections.Generic;
using System.Security.Claims;

namespace WorldDomination.Security
{
    public class UserData : IUserData
    {
        private const char Delimeter = ',';

        #region IUserData Members

        /// <summary>
        /// Unique User Id.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// User's public Display Name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A uri to a user's avatar/profile pic.
        /// </summary>
        public string PictureUri { get; set; }

        /// <summary>
        /// Convert to the UserData into a list of Claims.
        /// </summary>
        /// <returns>List of claims.</returns>
        public IEnumerable<Claim> ToClaims()
        {
            return new List<Claim>
                   {
                       new Claim(ClaimTypes.Uri, UserId),
                       new Claim(ClaimTypes.NameIdentifier, DisplayName),
                       new Claim(ClaimTypes.Name, DisplayName),
                       new Claim(CustomClaimsTypes.PictureUri, PictureUri)
                   };
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{1}{0}{2}{0}{3}", Delimeter,
                                 string.IsNullOrEmpty(UserId) ? "-" : UserId,
                                 string.IsNullOrEmpty(DisplayName) ? "-" : DisplayName,
                                 string.IsNullOrEmpty(PictureUri) ? "-" : PictureUri);
        }
    }
}