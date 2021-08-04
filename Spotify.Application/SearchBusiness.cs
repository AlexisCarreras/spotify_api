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
		private ISpotifyService _searchService { get; set; }
		public SearchBusiness(ISpotifyService searchService)
		{
			_searchService = searchService;
		}

		public List<SearchDTO> SearchArtist(string name, SearchEnum type)
		{
			var responseService = _searchService.Search(name, type.ToString());
			var arrItem = ((ArtistSearch)responseService).artists.items;
			List<SearchDTO> listArtista = new List<SearchDTO>();

			for (int i = 0; i < arrItem.Length; i++)
			{
				SearchDTO artist = new SearchDTO()
				{
					id = arrItem[i].id,
					imagen_url = arrItem[i].images[0].url,
					name_artist = arrItem[i].name,
					type = arrItem[i].type,
				};
				listArtista.Add(artist);
			}
			return listArtista;
		}

		public List<SearchDTO> SearchAlbum(string name, SearchEnum type)
		{
			var responseService = _searchService.Search(name, type.ToString());
			var arrItem = ((AlbumSearch)responseService).albums.items;
			List<SearchDTO> listAlbum = new List<SearchDTO>();

			for (int i = 0; i < arrItem.Length; i++)
			{
				SearchDTO album = new SearchDTO()
				{
					id = arrItem[i].id,
					imagen_url = arrItem[i].images[0].url,
					name_artist = arrItem[i].artists[0].name,
					name_album = arrItem[i].name,
					type = arrItem[i].type,
				};
				listAlbum.Add(album);
			}
			return listAlbum;
		}

		public List<SearchDTO> SearchTrack(string name, SearchEnum type)
		{
			var responseService = _searchService.Search(name, type.ToString());
			var arrItem = ((TrackSearch)responseService).tracks.items;
			List<SearchDTO> listTrack = new List<SearchDTO>();

			for (int i = 0; i < arrItem.Length; i++)
			{
				var trackFeatures = _searchService.TrackFeatures(arrItem[i].id);
				SearchDTO track = new SearchDTO()
				{
					id = arrItem[i].id,
					imagen_url = arrItem[i].album.images[0].url,
					name_artist = arrItem[i].artists[0].name,
					name_track = arrItem[i].name,
					track_lenght = arrItem[i].duration_ms,
					favorite = false,
					previewUrl = arrItem[i].preview_url,
					type = arrItem[i].type,
					//name = arrItem[i].name,
					//id = arrItem[i].id,
					//trackLength = arrItem[i].duration_ms,
					//albumName = arrItem[i].album.name,
					//artistName = arrItem[i].artists[0].name,
					//previewUrl = arrItem[i].preview_url,
					//favorite = false,
					//type = arrItem[i].type,
					//images = ImageMapper.ImageMapping(arrItem[i].album.images),
				};
				//track.TrackMapping(trackFeatures);
				listTrack.Add(track);
			}
			return listTrack;
		}
	}
}