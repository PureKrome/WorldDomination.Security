namespace WorldDomination.Security
{
    public interface IUserData
    {
        string UserId { get; set; }
        string DisplayName { get; set; }
        string PictureUri { get; set; }

        string Serialize();
    }
}