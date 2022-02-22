using Game.Challenge.API.Dto.Address;

namespace Game.Challenge.API.Dto.User
{
    public class UserEditDto
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressEditDto Address { get; set; }
    }
}
