using AuthCDApi.Data;
using AuthCDApi.Models;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit.Text;
using MimeKit;
using System.Security.Cryptography;
using MailKit.Net.Smtp;

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
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            if (_context.Users.Any(user => user.Email == request.Email))
            {
                return BadRequest("Este E-mail ja foi cadastrado");
            }

            CreatePasswordHash(request.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt);

            var user = new User
            {
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
            var emailToSend = new MimeMessage();

            if (user == null)
            {
                return BadRequest("Usuario nao encontrado!");
            }

            user.PasswordResetToken = CreateRandomToken();
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();

            emailToSend.From.Add(MailboxAddress.Parse("cleve.schamberger51@ethereal.email"));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = "Reset your password";
            emailToSend.Body = new TextPart(TextFormat.Html) { Text = $"<a target=\"_blank\" href=\"http://localhost:3000/reset-password/{user.PasswordResetToken}\">Alterar a sua senha</a>" };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("cleve.schamberger51@ethereal.email", "Q55wUCqngKaKYAAApV");
            smtp.Send(emailToSend);
            smtp.Disconnect(true);

            return Ok("Token para resetar a senha foi enviado!");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.PasswordResetToken == request.Token);

            if (user == null || user.ResetTokenExpires < DateTime.Now)
            {
                return BadRequest("Token enviado invalido!");
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;

            await _context.SaveChangesAsync();

            return Ok("Senha trocada com sucesso!");
        }

        [HttpPost("email")]
        public IActionResult SendEmail()
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("cleve.schamberger51@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("cleve.schamberger51@ethereal.email"));
            email.Subject = "Reset your password";
            email.Body = new TextPart(TextFormat.Html) { Text = $"<h1>Meu teste de body</h1>" };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("cleve.schamberger51@ethereal.email", "Q55wUCqngKaKYAAApV");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
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
