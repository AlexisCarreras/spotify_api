namespace Featurify.Core.Models.Auth
{
    public class AuthenticationOptions
    {
        public const string Authentication = nameof(Authentication);
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public int DurationInMinutes { get; set; }
    }

}
