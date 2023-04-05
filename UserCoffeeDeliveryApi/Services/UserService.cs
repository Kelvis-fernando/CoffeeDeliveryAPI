using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserCoffeeDeliveryAPI.Context;
using UserCoffeeDeliveryAPI.Modal;
using UserCoffeeDeliveryAPI.Models.Dto;

namespace UserCoffeeDeliveryAPI.Services
{
    public class UserService
    {
        private UserDbContext _context;
        private IMapper _mapper;

        public UserService(UserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CreateUserDto CreateCoffee(CreateUserDto coffeeDto)
        {
            User user = _mapper.Map<User>(coffeeDto);
            _context.Users.Add(user);
            _context.SaveChanges();
            return _mapper.Map<CreateUserDto>(user);
        }
    }
}
