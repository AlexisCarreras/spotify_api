using System.Collections.Generic;
using Spotify.Application.Mapper;
using Spotify.Domain.Abstract;
using Spotify.Domain.Enums;
using Spotify.Domain.Interfaces;
using Spotify.Domain.Mapper;
using Spotify.Domain.Models.Search;
using Spotify.Domain.Response;
using Spotify.Service;

namespace Spotify.Application
{
	public class SearchBusiness : ISearchBusiness
	{
		private Service.SpotifyService _searchService { get; set; }
		public SearchBusiness()
		{
			_searchService = new Service.SpotifyService();
		}

		public Service.SpotifyService GetSearchService()
		{
			return _searchService;
		}

		public List<Artist> SearchArtist(string name, SearchEnum type)
		{
			var responseService = _searchService.Search(name, type.ToString());

			var arrItem = ((ArtistSearch)responseService).artists.items;

			List<Artist> listArtista = new List<Artist>();

			for (int i = 0; i < arrItem.Length; i++)
			{

				var alb = new ArtistBusiness();

				Artist artist = new Artist()
				{
					name = arrItem[i].name,
					id = arrItem[i].id,
					type = arrItem[i].type,
					genres = arrItem[i].genres,
					popularity = arrItem[i].popularity,
					images = ImageMapper.ImageMapping(arrItem[i].images)
				};
				listArtista.Add(artist);
			}
			return listArtista;
		}

		public List<Album> SearchAlbum(string name, SearchEnum type)
		{
			var responseService = _searchService.Search(name, type.ToString());

			var arrItem = ((AlbumSearch)responseService).albums.items;

			List<Album> listAlbum = new List<Album>();

			for (int i = 0; i < arrItem.Length; i++)
			{
				var tr = new AlbumBusiness();
				Album album = new Album()
				{
					name = arrItem[i].name,
					id = arrItem[i].id,
					type = arrItem[i].album_type,
					totalTracks = arrItem[i].total_tracks,
					albumArtist = arrItem[i].artists[0].name,
					images = ImageMapper.ImageMapping(arrItem[i].images)
				};

				listAlbum.Add(album);
			}

			return listAlbum;
		}

		public List<Track> SearchTrack(string name, SearchEnum type)
		{
			var responseService = _searchService.Search(name, type.ToString());

			var arrItem = ((TrackSearch)responseService).tracks.items;

			List<Track> listTrack = new List<Track>();

			for (int i = 0; i < arrItem.Length; i++)
			{
				var trackFeatures = _searchService.TrackFeatures(arrItem[i].id);

				Track track = new Track()
				{

					name = arrItem[i].name,
					id = arrItem[i].id,
					trackLength = arrItem[i].duration_ms,
					albumName = arrItem[i].album.name,
					artistName = arrItem[i].artists[0].name,
					previewUrl = arrItem[i].preview_url,
					favorite = false,
					type = arrItem[i].type,
					images = ImageMapper.ImageMapping(arrItem[i].album.images),
				};
				track.TrackMapping(trackFeatures);
				listTrack.Add(track);
			}

			return listTrack;
		}

	}
}