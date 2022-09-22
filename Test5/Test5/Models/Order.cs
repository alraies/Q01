using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test5.Models
{
    public class Order : EntityId
    {

        public int CustomerId { get; set; }

        public DateTime? OrderDate { get; set; }
       
        public int? OrderNo { get; set; }

        public decimal TotalAmount { get; set; }
        public Customer? Customer { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
