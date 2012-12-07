using System;

namespace WorldDomination.Security
{
    public class UserData : IUserData
    {
        private const char Delimeter = ',';

        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public string Serialize()
        {
            return string.Format("{1}{0}{2}{0}{3}", Delimeter,
                string.IsNullOrEmpty(UserId) ? "-" : UserId,
                string.IsNullOrEmpty(DisplayName) ? "-" : DisplayName,
                string.IsNullOrEmpty(PictureUri) ? "-" : PictureUri);
        }

        public UserData()
        {
        }

        // This should deserialize some serialized user-data which would have been in a Cookie.
        public UserData(string data)
        {
            if (string.IsNullOrWhiteSpace("data"))
            {
                throw new ArgumentNullException("data");
            }

            // Split the text into segments.
            string[] segments = data.Split(new[] { Delimeter }, StringSplitOptions.RemoveEmptyEntries);
            if (segments.Length != 3)
            {
                throw new InvalidOperationException("Incorrect number of serialized items in the provided data.");
            }

            UserId = segments[0];
            DisplayName = segments[1];
            PictureUri = segments[2];
        }

        public string PictureUri { get; set; }

        public override string ToString()
        {
            return Serialize();
        }
    }
}