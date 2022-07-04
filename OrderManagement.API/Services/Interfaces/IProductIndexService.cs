using OrderManagement.API.Entities;
using System.Collections.Generic;

namespace OrderManagement.API.Services.Interfaces
{
    public interface IProductIndexService
    {
        void Index(Product doc, string indexName);
        bool DeleteIndex(int id);
        void UpdateIndex(Product entity);
        public IEnumerable<Product> Search(string text);
    }
}
