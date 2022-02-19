using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Challenge.Domain.Game
{
    public class Game
    {
        [Key]
        public long GameId { get; set; }
        public string Name { get; set; }
        public string ThumbnailImage { get; set; }

        public List<UserGame> UserGames { get; set; }
    }
}
