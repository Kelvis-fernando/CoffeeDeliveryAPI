using AutoMapper;
using CoffeeDelivery.Models;
using CoffeeDelivery.Models.DTO;

namespace CoffeeDelivery.Profiles
{
    public class CoffeeProfile : Profile
    {
        public CoffeeProfile()
        {
            CreateMap<CreateCoffeeDto, Coffee>();
            CreateMap<UpdateCoffeeDto, Coffee>();
        }
    }
}
