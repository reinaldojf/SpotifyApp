using Spotify.Domain.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.User
{
    public class UserFavoriteMusic
    {
        public Guid Id { get; set; }

        public virtual Music Music { get; set; }
        
        public virtual User User { get; set; }

    }
}
