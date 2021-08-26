namespace Featurify.Core.Helper
{
    public class SpotifyConfigurationOptions
    {
        public const string SpotifyConfiguration = nameof(SpotifyConfiguration);
        public string Endpoint { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
