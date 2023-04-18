using System.ComponentModel.DataAnnotations;

namespace CoffeeDelivery.Models
{
    public class OrderItem
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
        [Required(ErrorMessage = "O campo Id e obrigatorio!")]
        public List<int> Prices { get; internal set; }
        [Required(ErrorMessage = "O campo Prices e obrigatorio!")]
        public List<int> Products { get; internal set; }
        [Required(ErrorMessage = "O campo Products e obrigatorio!")]
        public List<int> QtdAddedToCart { get; internal set; }
    }
}
