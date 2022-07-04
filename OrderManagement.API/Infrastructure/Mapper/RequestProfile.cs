using AutoMapper;
using OrderManagement.API.DTOs;
using OrderManagement.API.DTOs.Resquest;
using OrderManagement.API.Entities;

namespace OrderManagement.API.Infrastructure.Mapper
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            // product
            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<ProductDto, Product>();

            //order
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<UpdateOrderRequest, Order>();

            //OrderItem
            CreateMap<OrderItemDto, OrderItem>();

            //customer
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<UpdateCustomerRequest, Customer>();
            CreateMap<CustomerDto, Customer>();

            

        }
    }
}
