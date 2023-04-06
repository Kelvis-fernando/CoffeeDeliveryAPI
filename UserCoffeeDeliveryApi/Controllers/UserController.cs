using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserCoffeeDeliveryAPI.Context;
using UserCoffeeDeliveryAPI.Modal;
using UserCoffeeDeliveryAPI.Models.Dto;
using UserCoffeeDeliveryAPI.Services;

namespace UserCoffeeDeliveryAPI.Controller
{
    [ApiController]
    [Route("/v1/[controller]")]

    public class RegisterController : ControllerBase
    {
        private RegisterService _registerService;

        public RegisterController(RegisterService registerService)
        {
          _registerService= registerService;
        }

        [HttpPost]
        public IActionResult RegisterUser(CreateUserDto createDto)
        {
            Result result = _registerService.RegisterUser(createDto);
            if (result.IsFailed) return StatusCode(500);
            return Ok();
        }
    }
}
