//using System;
//using System.Collections.Generic;
//using System.Text;
//using Spotify.Application;
//using Spotify.Domain.Abstract;
//using Spotify.Domain.Enums;
//using Spotify.Domain.Models;
//using Spotify.Domain.Response;

//namespace Spotify.Application.Abstract
//{
//	public class SearchBusinessAlbum : SearchBusiness
//	{

//		public override List<Item> Search(string name, SearchEnum type)
//		{
//			var responseService = GetSearchService().Search(name, type.ToString());

//			var arrItem = ((AlbumSearch)responseService).albums.items;



//			List<Album> listAlbum = new List<Album>();

//			for (int i = 0; i < arrItem.Length; i++)
//			{
//				Album album = new Album()
//				{
//					name = arrItem[i].name,
//					id = arrItem[i].id,
//					type = arrItem[i].album_type,
//					totalTracks = arrItem[i].total_tracks,
//					albumArtist = arrItem[i].artists[0].name,
//					images = arrItem[i].images
//				};

//				listAlbum.Add(album);
//			}

//			return listAlbum;
//		}
//    }
//}
