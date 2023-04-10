using AuthCDApi.Data;
using AuthCDApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace AuthCDApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterRequest request)
        {
            if (_context.Users.Any(user => user.Email == request.Email))
            {
                return BadRequest("Este E-mail ja foi cadastrado");
            }

            CreatePasswordHash(request.Password,
                out byte[] passwordHash, 
                out byte[] passwordSalt);

            var user = new User { 
                Name = request.Name,
                Email = request.Email,
                TypeOfUser = request.TypeOfUser,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt, 
                VerificationToken = CreateRandomToken() 
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
