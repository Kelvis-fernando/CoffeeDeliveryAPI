using System.ComponentModel.DataAnnotations;

namespace UserCoffeeDeliveryAPI.Models.Dto
{
    public class CreateUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string TypeOfUser { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
