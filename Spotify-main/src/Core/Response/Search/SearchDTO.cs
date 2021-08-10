namespace Spotify.Core.Response
{
	public class SearchDTO
	{
		public string id { get; set; }
		public string imagen_url { get; set; }
		public string name_track { get; set; }
		public string name_album { get; set; }
		public string name_artist { get; set; }
		public string track_lenght { get; set; }
		public bool favorite { get; set; }
		public string previewUrl { get; set; }
		public string type { get; set; }
	}
}