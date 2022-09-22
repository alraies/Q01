using System.Text.Json.Serialization;

namespace Test5.Models
{
    public class OrderDetail : EntityId
    {
        public int OrderId { get; set; }
      

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Qty { get; set; }
    }
}
