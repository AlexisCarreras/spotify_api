namespace Featurify.Core.Response
{
	public class AlbumTrack
	{
		public string name { get; set; }
		public string id { get; set; }
		public string type { get; set; }
		public string trackLength { get; set; }
		public string previewUrl { get; set; }
		public bool favorite { get; set; }
		public int track_number { get; set; }
	}
}