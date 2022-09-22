using System.Text.Json.Serialization;

namespace Test5.Models
{
    public class Category:EntityId
    {
        public string Name { get; set; }
        [JsonIgnore]
        public List<Product>? Products { get; set; }
    }
}
