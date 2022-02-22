using Game.Challenge.API.Dto.Game;

namespace Game.Challenge.API.Dto.User
{
    public class UserAdminEditDto
    {
        public long UserId { get; set; }
        public List<UserGameAdminEditDto> UserGames { get; set; }
    }
}
