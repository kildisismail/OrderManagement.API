using AutoMapper;
using OrderManagement.API.DTOs.Response;
using OrderManagement.API.DTOs.Resquest;
using OrderManagement.API.Entities;
using OrderManagement.API.Repository.Interfaces;
using OrderManagement.API.Services.Interfaces;
using System.Threading.Tasks;

namespace OrderManagement.API.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateCustomerRequest request)
        {
             await _customerRepository.Add(_mapper.Map<Customer>(request));
        }

        public async Task Delete(int id)
        {
            await _customerRepository.Delete(id);
        }

        public async Task<GetCustomerResponse> GetById(int id)
        {
            var response = await _customerRepository.GetById(id);
            return _mapper.Map<GetCustomerResponse>(response);
        }

        public async Task Update(UpdateCustomerRequest request)
        {
            await _customerRepository.Update(_mapper.Map<Customer>(request));
        }
    }
}
