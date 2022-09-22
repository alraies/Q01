using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Test5.Models
{
    public class Customer : EntityId
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        [JsonIgnore]
        [NotMapped]
        public List<Order>? Orders { get; set; }
    }
}
