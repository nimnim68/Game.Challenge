using Game.Challenge.Domain.Game;

namespace Game.Challenge.API.Dto.Game
{
    public class UserGameAdminEditDto
    {
        public long UserGameId { get; set; }
        public GameState GameState { get; set; }
    }
}
