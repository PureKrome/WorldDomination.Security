using System;
using System.Security.Claims;
using System.Security.Principal;

namespace WorldDomination.Security.Test.WebApplication.Areas.Authentication.Models
{
    public class AuthenticationViewModel
    {
        public AuthenticationViewModel(IPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException("principal");
            }
            var claimsPrincipal = principal as ClaimsPrincipal;
            if (claimsPrincipal == null)
            {
                throw new ArgumentException("A principal argument was provided, but it needs to be a 'ClaimsPrincipal'.");
            }

            IsAuthenticated = claimsPrincipal.Identity.IsAuthenticated;

            if (claimsPrincipal.HasClaim(x => x.Type == ClaimTypes.Uri))
            {
                Id = claimsPrincipal.FindFirst(x => x.Type == ClaimTypes.Uri).Value;
            }

            if (claimsPrincipal.HasClaim(x => x.Type == ClaimTypes.Name))
            {
                Name = claimsPrincipal.FindFirst(x => x.Type == ClaimTypes.Name).Value;
            }

            if (claimsPrincipal.HasClaim(x => x.Type == CustomClaimsTypes.PictureUri))
            {
                PictureUri = claimsPrincipal.FindFirst(x => x.Type == CustomClaimsTypes.PictureUri).Value;
            }
        }

        public bool IsAuthenticated { get; private set; }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string PictureUri { get; private set; }
    }
}