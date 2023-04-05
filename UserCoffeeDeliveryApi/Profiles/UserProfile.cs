using AutoMapper;
using UserCoffeeDeliveryAPI.Modal;
using UserCoffeeDeliveryAPI.Models.Dto;

namespace UserCoffeeDeliveryAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<CreateUserDto, User>();
        }
    }
}
