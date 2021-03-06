using Game.Challenge.API.Dto.Address;
using Game.Challenge.API.Dto.Game;

namespace Game.Challenge.API.Dto.User
{
    public class UserManageReadDto
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressManageReadDto Address { get; set; }
        public List<UserGameManageReadDto> UserGames { get; set; }
    }
}
