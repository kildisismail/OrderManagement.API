using OrderManagement.API.Entities;
using System.Collections.Generic;

namespace OrderManagement.API.DTOs.Resquest
{
    public class CreateOrderRequest
    {
        public List<OrderItemDto> OrderItems { get; set; }
        public int CustomerId { get; set; }
    }
}
