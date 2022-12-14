namespace BreadApp.Infrastructure.Auth
{
    public class BreadAppJwtSettings
    {
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public string Secret { get; init; }
        public int ExpiryMinutes { get; init; }
    }

}
