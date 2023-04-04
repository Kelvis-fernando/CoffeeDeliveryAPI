using CoffeeDelivery.Models.DTO.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace CoffeeDelivery.Controller
{
    [Route("/v1/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public IActionResult RegisterUser(CreateUserDto createUserDto)
        {
            return Ok();
        }
    }
}
