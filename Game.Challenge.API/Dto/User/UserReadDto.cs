using Game.Challenge.API.Dto.Address;
using Game.Challenge.API.Dto.Game;

namespace Game.Challenge.API.Dto.User
{
    public class UserReadDto
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressReadDto Address { get; set; }
        public List<UserGameReadDto> UserGames { get; set; }
    }
}
