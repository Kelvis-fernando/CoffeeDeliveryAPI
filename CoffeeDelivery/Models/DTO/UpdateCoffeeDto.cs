using System.ComponentModel.DataAnnotations;

namespace CoffeeDelivery.Models.DTO
{
    public class UpdateCoffeeDto
    {
        [Required(ErrorMessage = "O campo nome e obrigatorio!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo marca e obrigatorio!")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "O campo preco e obrigatorio!")]
        public double Price { get; set; }
        [Required(ErrorMessage = "O campo descricao e obrigatorio!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo imagem e obrigatorio!")]
        public string Image { get; set; }
        [Required(ErrorMessage = "O campo classificacao e obrigatorio!")]
        public string Classification { get; set; }
        [Required(ErrorMessage = "O campo itensidade e obrigatorio!")]
        public string Itensity { get; set; }
        [Required(ErrorMessage = "O campo notas e obrigatorio!")]
        public string Notes { get; set; }
        [Required(ErrorMessage = "O campo origem e obrigatorio!")]
        public string Origin { get; set; }
        [Required(ErrorMessage = "O campo tipo de torragem e obrigatorio!")]
        public string TypeToast { get; set; }
        [Required(ErrorMessage = "O campo tipo de quantidade e obrigatorio!")]
        public int Quantity { get; set; }
    }
}
