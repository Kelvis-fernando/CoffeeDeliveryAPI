using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserCoffeeDeliveryAPI.Context;
using UserCoffeeDeliveryAPI.Modal;
using UserCoffeeDeliveryAPI.Models.Dto;

namespace UserCoffeeDeliveryAPI.Services
{
    public class RegisterService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        public RegisterService(UserManager<IdentityUser<int>> userManager, IMapper mapper)
        {
            _userManager= userManager;
            _mapper = mapper;
        }
        public Result RegisterUser(CreateUserDto createDto)
        {
            User user = _mapper.Map<User>(createDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(userIdentity, createDto.Password);
            if (resultIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar o usuario!");
        }
    }
}
