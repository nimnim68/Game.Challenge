using AutoMapper;
using Game.Challenge.API.Dto.Address;
using Game.Challenge.API.Dto.Game;
using Game.Challenge.API.Dto.User;
using Game.Challenge.Domain.Address;
using Game.Challenge.Domain.Game;
using Game.Challenge.Domain.User;

namespace Game.Challenge.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<Address, AddressReadDto>();
            CreateMap<UserGame, UserGameReadDto>();
            CreateMap<Domain.Game.Game, GameReadDto>();

            CreateMap<UserCreateDto, User>();
            CreateMap<AddressCreateDto, Address>();

            CreateMap<User, UserManageReadDto>();
            CreateMap<Address, AddressManageReadDto>();
            CreateMap<UserGame, UserGameManageReadDto>();
            CreateMap<Domain.Game.Game, GameManageReadDto>();

        }
    }
}
