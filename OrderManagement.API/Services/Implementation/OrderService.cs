using AutoMapper;
using OrderManagement.API.DTOs.Response;
using OrderManagement.API.DTOs.Resquest;
using OrderManagement.API.Entities;
using OrderManagement.API.Repository.Interfaces;
using OrderManagement.API.Services.Interfaces;
using System.Threading.Tasks;

namespace OrderManagement.API.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository OrderRepository,
                            IMapper mapper)
        {
            _orderRepository = OrderRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateOrderRequest request)
        {
            var data = _mapper.Map<Order>(request);
            await _orderRepository.Add(_mapper.Map<Order>(request));
        }

        public async Task Delete(int id)
        {
            await _orderRepository.Delete(id);
        }

        public async Task<GetOrderResponse> GetById(int id)
        {
            var entity = await _orderRepository.GetById(id);
            return _mapper.Map<GetOrderResponse>(entity);
        }

        public async Task Update(UpdateOrderRequest request)
        {
             await _orderRepository.Update(_mapper.Map<Order>(request));
        }
    }
}
