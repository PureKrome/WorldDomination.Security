using System.Collections.Generic;
using System.Security.Claims;

namespace WorldDomination.Security
{
    public class UserData : IUserData
    {
        private const char Delimeter = ',';

        #region IUserData Members

        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public string PictureUri { get; set; }

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