using System.Security.Principal;

namespace WorldDomination.Security
{
    public class CustomPrincipal : GenericPrincipal
    {
        public CustomPrincipal(ICustomIdentity identity, string[] roles)
            : base(identity, roles)
        {
            Identity = identity;
        }

        public new virtual ICustomIdentity Identity { get; private set; }
    }
}