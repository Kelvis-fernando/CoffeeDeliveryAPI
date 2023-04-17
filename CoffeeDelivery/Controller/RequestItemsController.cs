using AutoMapper;
using CoffeeDelivery.Context;
using CoffeeDelivery.Models;
using CoffeeDelivery.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeDelivery.Controller
{
    [Route("/v1/[controller]")]
    [ApiController]
    public class RequestItemsController : ControllerBase
    {
        private RequestItemDbContext _context;
        private IMapper _mapper;
        public RequestItemsController(RequestItemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("save-request")]
        public IActionResult SaveRequest([FromBody] List<CreateCoffeeDto> coffeeDtos)
        {
            List<Coffee> coffees = _mapper.Map<List<Coffee>>(coffeeDtos);
            _context.RequestItems.AddRange(coffees);

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("get-request")]
        public IEnumerable<Coffee> GetRequest()
        {
            return _context.RequestItems;
        }

    }
}
