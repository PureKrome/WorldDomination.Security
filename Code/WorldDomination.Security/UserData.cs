using System;
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
                       new Claim(ClaimTypes.NameIdentifier, DisplayName),
                       new Claim(ClaimTypes.Name, DisplayName),
                       new Claim(ClaimTypes.Uri, PictureUri)
                   };
        }

        #endregion

        public string Serialize()
        {
            return string.Format("{1}{0}{2}{0}{3}", Delimeter,
                                 string.IsNullOrEmpty(UserId) ? "-" : UserId,
                                 string.IsNullOrEmpty(DisplayName) ? "-" : DisplayName,
                                 string.IsNullOrEmpty(PictureUri) ? "-" : PictureUri);
        }

        public void DeSerialize(string data)
        {
            if (string.IsNullOrWhiteSpace("data"))
            {
                throw new ArgumentNullException("data");
            }

            // Split the text into segments.
            string[] segments = data.Split(new[] {Delimeter}, StringSplitOptions.RemoveEmptyEntries);
            if (segments.Length != 3)
            {
                throw new InvalidOperationException("Incorrect number of serialized items in the provided data.");
            }

            UserId = segments[0];
            DisplayName = segments[1];
            PictureUri = segments[2];
        }

        public override string ToString()
        {
            return Serialize();
        }
    }
}