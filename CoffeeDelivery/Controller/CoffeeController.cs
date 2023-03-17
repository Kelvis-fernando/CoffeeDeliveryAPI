using CoffeeDelivery.Context;
using CoffeeDelivery.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeDelivery.Controller
{
    public class CoffeeController : ControllerBase
    {
        private CoffeeDbContext _context;


        [HttpPost]
        public IActionResult CreateCoffee([FromBody] Coffee coffee) 
        {
            _context.Coffee.Add(coffee);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCoffeeById), new { Id = coffee.Id }, coffee);
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
