using OrderManagement.API.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.API.Entities
{
    public class Order : BaseEntity
    {

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
