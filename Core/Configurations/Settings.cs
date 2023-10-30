namespace Core.Configurations
{
    public class AppSettings
    {
    }

    public class AuthSettings
    {
        public string TokenSecret { get; set; } = string.Empty;
        public string RefreshedTokenSecret { get; set; } = string.Empty;
        public double TokenExpirationMunites { get; set; }
        public double RefreshedTokenExpirationMunites { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }

}
