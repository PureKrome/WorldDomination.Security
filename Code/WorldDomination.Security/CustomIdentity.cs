using System;
using System.Security.Principal;

namespace WorldDomination.Security
{
    public class CustomIdentity : GenericIdentity, ICustomIdentity
    {
        public CustomIdentity(IUserData userData)
            : base(userData == null ||
                   string.IsNullOrEmpty(userData.DisplayName)
                       ? string.Empty
                       : userData.DisplayName,
                   "Custom-Forms")
        {
            if (userData == null)
            {
                throw new ArgumentNullException("userData");
            }

            UserId = userData.UserId;
            PictureUri = userData.PictureUri;
        }

        #region Implementation of CustomIdentity

        public string UserId { get; private set; }
        public string PictureUri { get; private set; }

        #endregion
    }
}