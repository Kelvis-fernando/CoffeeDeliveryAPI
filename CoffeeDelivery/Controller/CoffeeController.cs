using AutoMapper;
using CoffeeDelivery.Context;
using CoffeeDelivery.Models;
using CoffeeDelivery.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace CoffeeDelivery.Controller
{
    [ApiController]
    [Route("/v1/[controller]")]
    public class CoffeeController : ControllerBase
    {
        private CoffeeDbContext _context;
        private IMapper _mapper;
        public CoffeeController(CoffeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateCoffee([FromBody] CreateCoffeeDto coffeeDto)
        {
            Coffee coffee = _mapper.Map<Coffee>(coffeeDto);

            _context.Coffee.Add(coffee);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCoffeeById), new { Id = coffee.Id }, coffee);
        }

        [HttpGet]
        public IEnumerable<Coffee> GetCoffee()
        {
            return _context.Coffee;
        }

        [HttpGet("{id}")]
        public IActionResult GetCoffeeById(int id)
        {
            Coffee coffee = _context.Coffee.FirstOrDefault(coffee => coffee.Id == id);
            if (coffee != null)
            {
                return Ok(coffee);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCoffee([FromBody] UpdateCoffeeDto updateCoffeeDto, int id)
        {
            Coffee coffee = _context.Coffee.FirstOrDefault(coffee => coffee.Id == id);

            if (coffee == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCoffeeDto, coffee);

            coffee.Name = updateCoffeeDto.Name;
            coffee.Brand = updateCoffeeDto.Brand;
            coffee.Price = updateCoffeeDto.Price;
            coffee.Description = updateCoffeeDto.Description;
            coffee.Classification = updateCoffeeDto.Classification;
            coffee.Itensity = updateCoffeeDto.Itensity;
            coffee.Notes = updateCoffeeDto.Notes;
            coffee.Image = updateCoffeeDto.Image;
            coffee.Origin = updateCoffeeDto.Origin;
            coffee.TypeToast = updateCoffeeDto.TypeToast;
            coffee.Quantity = updateCoffeeDto.Quantity;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCoffeeById(int id)
        {
            Coffee coffee = _context.Coffee.FirstOrDefault(coffee => coffee.Id == id);
            if (coffee == null)
            {
                return NotFound();
            }

            _context.Coffee.Remove(coffee);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
