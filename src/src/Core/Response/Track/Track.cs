namespace Featurify.Core.Response
{
    public class Track
    {
        public string name { get; set; }
        public string id { get; set; }
		public string image { get; set; }
		public string type { get; set; }
        public string trackLength { get; set; }
        public string albumName { get; set; }
        public string artistName { get; set; }
        public string previewUrl { get; set; }
		public bool favorite { get; set; }
    }
}
