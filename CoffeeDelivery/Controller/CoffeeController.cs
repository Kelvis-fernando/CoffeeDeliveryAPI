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
            return Ok();
            // return CreatedAtAction(nameof(GetCoffeeById), new { Id = coffee.Id }, coffee);
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
    }
}
