using System.Collections.Generic;
using Spotify.Domain.Abstract;
using Spotify.Domain.Enums;
using Spotify.Domain.Models;
using Spotify.Domain.Response;
using Spotify.Service;

namespace Spotify.Application
{
	public class SearchBusiness //: ISearchBusiness
	{
		private SearchService _searchService { get; set; }
		public SearchBusiness()
		{
			_searchService = new SearchService();
		}

		public SearchService GetSearchService()
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
				Artist artist = new Artist()
				{
					name = arrItem[i].name,
					id = arrItem[i].id,
					type = arrItem[i].type,
					genres = arrItem[i].genres,
					popularity = arrItem[i].popularity,
					images = arrItem[i].images
				};

				listArtista.Add(artist);
			}

			return listArtista;
		}

		private List<Album> SearchAlbum(string name, SearchEnum type)
		{
			var responseService = _searchService.Search(name, type.ToString());

			var arrItem = ((AlbumSearch)responseService).albums.items;

			List<Album> listAlbum = new List<Album>();

			for (int i = 0; i < arrItem.Length; i++)
			{
				Album album = new Album()
				{
					name = arrItem[i].name,
					id = arrItem[i].id,
					type = arrItem[i].album_type,
					totalTracks = arrItem[i].total_tracks,
					albumArtist = arrItem[i].artists[0].name,
					images = arrItem[i].images
				};

				listAlbum.Add(album);
			}

			return listAlbum;
		}

	}
}