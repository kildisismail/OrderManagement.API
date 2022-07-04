using AutoMapper;
using Nest;
using OrderManagement.API.DTOs;
using OrderManagement.API.DTOs.Response;
using OrderManagement.API.DTOs.Resquest;
using OrderManagement.API.Entities;
using OrderManagement.API.Repository.Interfaces;
using OrderManagement.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.API.Services.Implementation
{
    public class ProductService : IProductService
    {
        private const string productIndexName = "product_index";
        private readonly IProductRepository _productRepository;
        private readonly IProductIndexService _indexClientService;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,
                              IProductIndexService indexClientService,
                              IMapper mapper)
        {
            _productRepository = productRepository;
            _indexClientService = indexClientService;
            _mapper = mapper;
        }

        public async Task CreateProductWithIndexing(CreateProductRequest product)
        {
            var entity = _mapper.Map<Product>(product);
            await _productRepository.Add(entity);

            _indexClientService.Index(entity, productIndexName);
        }

        public async Task DeleteProductWithIndexing(int id)
        {
            var entity = await _productRepository.GetById(id);
            await _productRepository.Delete(id);
            // indexleme
        }

        public async Task<GetProductResponse> GetById(int id)
        {
            var entity = await _productRepository.GetById(id);
            return _mapper.Map<GetProductResponse>(entity);
        }

        public async Task<IEnumerable<GetProductResponse>> Search(string searchText)
        {
            var result = _indexClientService.Search(searchText);
            return _mapper.Map<IEnumerable<GetProductResponse>>(result);
            
        }

        public async Task UpdateProductWithIndexing(UpdateProductRequest request)
        {
            var entity = _mapper.Map<Product>(request);
            await _productRepository.Update(entity);
            _indexClientService.UpdateIndex(entity);
        }
    }
}
