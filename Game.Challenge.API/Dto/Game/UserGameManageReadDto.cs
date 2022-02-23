using Game.Challenge.Domain.Game;

namespace Game.Challenge.API.Dto.Game
{
    public class UserGameManageReadDto
    {
        public long UserGameId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastPlayed { get; set; }
        public GameState GameState { get; set; }

        public long GameId { get; set; }
        public GameReadDto Game { get; set; }
    }
}
