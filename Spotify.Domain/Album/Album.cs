﻿using Spotify.Domain.Album.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Album
{
    public class Album
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Backdrop { get; set; }
        public Band Band { get;set; }
        public virtual IList<Music> Musics {get; set; }

        public DateTime ReleaseDate { get; set; }
        
    }
}
