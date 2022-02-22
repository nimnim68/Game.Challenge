using Game.Challenge.API.Dto.Address;
using Game.Challenge.Domain.Address;

namespace Game.Challenge.API.Dto.User
{
    public class UserCreateDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressCreateDto Address { get; set; }
    }
}
