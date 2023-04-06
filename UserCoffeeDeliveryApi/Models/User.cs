using System.ComponentModel.DataAnnotations;

namespace UserCoffeeDeliveryAPI.Modal
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
        public string Email { get; set; }
        public string TypeOfUser{ get; set; }
        public string Username { get; internal set; }
    }
}
