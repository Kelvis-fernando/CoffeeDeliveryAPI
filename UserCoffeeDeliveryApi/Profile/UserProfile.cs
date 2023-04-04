using AutoMapper;
using CoffeeDelivery.Models;
using CoffeeDelivery.Models.DTO.Auth;

namespace CoffeeDelivery.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}
