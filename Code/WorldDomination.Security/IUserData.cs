using System.Collections.Generic;
using System.Security.Claims;

namespace WorldDomination.Security
{
    public interface IUserData
    {
        string UserId { get; set; }
        string DisplayName { get; set; }
        string PictureUri { get; set; }

        IEnumerable<Claim> ToClaims();
    }
}