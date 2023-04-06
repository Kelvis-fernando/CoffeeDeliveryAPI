using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserCoffeeDeliveryAPI.Modal;
using UserCoffeeDeliveryAPI.Models.Dto;

namespace UserCoffeeDeliveryAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, IdentityUser<int>>();
        }
    }
}
