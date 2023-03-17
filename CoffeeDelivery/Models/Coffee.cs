namespace CoffeeDelivery.Models
{
    public class Coffee
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Classification { get; set;}
        public string Itensity { get; set; }
        public string Notes { get; set; }
        public string Origin { get; set; }
        public string TypeToast { get; set; }
    }
}
