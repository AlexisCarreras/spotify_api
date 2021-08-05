using System.Collections.Generic;
using Spotify.Core.Models;
using Spotify.Core.Response;

namespace Spotify.Infrastructure.Mapper
{
    public static class ImageMapper
    {
        public static Image[] ImageMapping(ImageModel[] Origen)
        {
            List<Image> imagen = new List<Image>(Origen.Length);

            for (int i = 0; i < Origen.Length; i++)
            {
                Image img = new Image();
                img.height = Origen[i].height;
                img.width = Origen[i].width;
                img.url = Origen[i].url;
                imagen.Add(img);
            }
            return imagen.ToArray();
        }
    }
}