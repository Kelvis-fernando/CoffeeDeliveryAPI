using AutoMapper;
using CoffeeDelivery.Context;
using CoffeeDelivery.Models;
using CoffeeDelivery.Models.DTO;

namespace CoffeeDelivery.Services
{
    public class CoffeeService
    {
        private CoffeeDbContext _context;
        private IMapper _mapper;

        public CoffeeService(CoffeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CreateCoffeeDto CreateCoffee(CreateCoffeeDto coffeeDto)
        {
            Coffee coffee = _mapper.Map<Coffee>(coffeeDto);
            _context.Coffee.Add(coffee);
            _context.SaveChanges();
            return _mapper.Map<CreateCoffeeDto>(coffee);
        }
    }
}
