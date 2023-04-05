using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserCoffeeDeliveryAPI.Context;
using UserCoffeeDeliveryAPI.Modal;
using UserCoffeeDeliveryAPI.Models.Dto;

namespace UserCoffeeDeliveryAPI.Controller
{
    [ApiController]
    [Route("/v1/[controller]")]

    public class UserController : ControllerBase
    {
        private UserDbContext _context;
        private IMapper _mapper;

        public UserController(UserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserDto model)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(user => user.Username == model.Username);

            if (existingUser != null)
            {
                return BadRequest("Username already exists.");
            }

            var user = _mapper.Map<User>(model);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteUser(int id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
