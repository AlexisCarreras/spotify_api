﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Featurify.Core.Response.Favorite
{
    public class FavoriteTrackDTO
    {
        public string UsuarioId { get; set; }
        public int TrackId { get; set; }
        public bool Enable { get; set; }
    }
}