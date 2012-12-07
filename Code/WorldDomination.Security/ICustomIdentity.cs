using System.Security.Principal;

namespace WorldDomination.Security
{
    public interface ICustomIdentity : IIdentity
    {
        string UserId { get; }
        string PictureUri { get; }
    }
}