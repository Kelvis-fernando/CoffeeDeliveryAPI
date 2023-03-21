using CoffeeDelivery.Context;
using CoffeeDelivery.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeDelivery.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private CoffeeDbContext _context;
        public CoffeeController(CoffeeDbContext context) => _context = context;

        [HttpPost]
        public IActionResult CreateCoffee([FromBody] Coffee coffee)
        {
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
        public IActionResult UpdateCoffee([FromBody] Coffee updateMovie, int id )
        {
            Coffee coffee = _context.Coffee.FirstOrDefault(coffee => coffee.Id == id);
            if (coffee == null)
            {
                return NotFound();
            }

            coffee.Name= updateMovie.Name;
            coffee.Brand = updateMovie.Brand;
            coffee.Price = updateMovie.Price;
            coffee.Description = updateMovie.Description;
            coffee.Classification = updateMovie.Classification;
            coffee.Itensity = updateMovie.Itensity;
            coffee.Notes = updateMovie.Notes;
            coffee.Origin = updateMovie.Origin;
            coffee.TypeToast = updateMovie.TypeToast;
            coffee.Quantity = updateMovie.Quantity;

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
