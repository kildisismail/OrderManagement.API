using AutoMapper;
using OrderManagement.API.DTOs;
using OrderManagement.API.DTOs.Response;
using OrderManagement.API.Entities;

namespace OrderManagement.API.Infrastructure.Mapper
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            //product
            CreateMap<Product, GetProductResponse>();
            CreateMap<Product, ProductDto>();

            //order
            CreateMap<Order, GetOrderResponse>();

            //orderItem 
            CreateMap<OrderItem, OrderItemDto>();

            //customer
            CreateMap<Customer, GetCustomerResponse>();
            CreateMap<Customer, CustomerDto>();

        }

    }
}
