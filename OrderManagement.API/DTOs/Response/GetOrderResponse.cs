using System.Collections.Generic;

namespace OrderManagement.API.DTOs.Response
{
    public class GetOrderResponse
    {
        public CustomerDto Customer { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
