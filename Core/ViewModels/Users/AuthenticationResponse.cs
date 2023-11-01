namespace Core.ViewModels.Users
{
    public class AuthenticationResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public List<string> Roles { get; set; }

    }
}
