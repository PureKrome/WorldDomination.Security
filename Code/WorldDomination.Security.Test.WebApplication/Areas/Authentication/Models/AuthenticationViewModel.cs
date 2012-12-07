using System;

namespace WorldDomination.Security.Test.WebApplication.Areas.Authentication.Models
{
    public class AuthenticationViewModel
    {
        public AuthenticationViewModel(CustomPrincipal customPrincipal)
        {
            if (customPrincipal == null)
            {
                throw new ArgumentNullException("customPrincipal");
            }

            IsAuthenticated = customPrincipal.Identity.IsAuthenticated;
            Id = customPrincipal.Identity.UserId;
            Name = customPrincipal.Identity.Name;
            PictureUri = customPrincipal.Identity.PictureUri;
        }

        public bool IsAuthenticated { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string PictureUri { get; set; }
    }
}