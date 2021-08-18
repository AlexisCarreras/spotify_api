using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Spotify.Core.Interfaces;

namespace Spotify.Api.Controllers
{
	[Route("api/[Controller]/")]
	[ApiController]
	public class ArtistController : ControllerBase
	{
		private readonly IArtistBusiness _artistBusiness;
		public ArtistController(IArtistBusiness artistBusiness)
		{
			_artistBusiness = artistBusiness;
		}

		[HttpGet("{id}")]
		public IActionResult GetArtist(string id, int offset)
		{
			var sw = Stopwatch.StartNew();
			var response = _artistBusiness.artist(id, offset);
			Console.WriteLine($"total: {sw.Elapsed.Seconds}s");
			return Ok(response);
		}

		[HttpGet("{id}/albums")]
		public IActionResult GetRequest(string id, int offset, int limit)
		{
			var request = new Request()
			{
				id = id,
				offset = offset,
				limit = limit
			};
			return Ok(request);
		}

	//[HttpGet("{id}/toptracks")]
	//public IActionResult GetTopTracks(string id)
	//{
	//	var response = _artistBusiness.TopTracks(id);
	//	return Ok(response);
	//}

	//[HttpGet("{id}/albums")]
	//public IActionResult GetAlbumsArtist(string id)
	//{
	//	var response = _artistBusiness.AlbumArtist(id);
	//	return Ok(response);
	//}
}
	public class Request
	{
		public string id { get; set; }
		public int offset { get; set; }
		public int limit { get; set; }
	}

}