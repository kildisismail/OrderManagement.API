using System.Collections.Generic;

namespace OrderManagement.API.DTOs.Resquest
{
    public class UpdateOrderRequest
    {
        public int Id { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public int CustomerId { get; set; }
    }
}
