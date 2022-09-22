namespace Test5.Models
{
    public class Product:EntityId
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
