using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Challenge.Domain.Game
{
    public class UserGame
    {
        [Key]
        public long UserGameId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastPlayed { get; set; }
        public GameState GameState { get; set; }

        public long UserId { get; set; }
        public User.User User { get; set; }

        public long GameId { get; set; }
        public Game Game { get; set; }


    }
}
