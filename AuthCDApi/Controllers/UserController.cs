using AuthCDApi.Data;
using AuthCDApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == request.Email);

            if (user == null)
            {
                return BadRequest("Usuario nao encontrado!");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("A senha esta incorreta!");
            }

            if (user.VerifiedAt == null)
            {
                return BadRequest("Usuario nao verificado!");
            }

            return Ok($"Bem vindo novamente, {user.Name}!");
        }

        [HttpPost("verify/{token}")]
        public async Task<IActionResult> Verify(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.VerificationToken == token);

            if (user == null)
            {
                return BadRequest("Token invalido!");
            }

            user.VerifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            return Ok("Usuario verificado!");
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);

            if (user == null)
            {
                return BadRequest("Usuario nao encontrado!");
            }

            user.PasswordResetToken = CreateRandomToken();
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();

            return Ok("Token para resetar a senha foi enviado!");
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

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
