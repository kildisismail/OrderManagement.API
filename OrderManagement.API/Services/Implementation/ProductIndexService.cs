using Microsoft.Extensions.Configuration;
using Nest;
using OrderManagement.API.Entities;
using OrderManagement.API.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace OrderManagement.API.Services.Implementation
{
    public class ProductIndexService: IProductIndexService
    {
        private readonly ElasticClient _elasticClient;
        private readonly IConfiguration _configuration;

        public ProductIndexService(IConfiguration configuration)
        {
            _configuration = configuration;
            string elasticUri = configuration.GetSection("ElasticConfig:ConnectionUri").Value ?? "http://localhost:9200/";
            _elasticClient = new ElasticClient(new ConnectionSettings(new Uri(elasticUri))
                        .DefaultIndex("product_index"));
        }


        public void Index(Product doc ,string indexName)
        {
           var data = _elasticClient.Index(doc, idx => idx.Index(indexName));
        }

        public bool DeleteIndex(int id)
        {
            var result = _elasticClient.Delete<Product>(id.ToString(), idx => idx.Index("product_index"));
            if (!result.IsValid)
            {
                throw new Exception(result.OriginalException.Message);
            }
            return result.ApiCall.Success;
        }

        public void UpdateIndex(Product entity)
        {
            var result = _elasticClient.Update(
                    new DocumentPath<Product>(entity), u =>
                        u.Doc(entity).Index("product_index"));
            if (!result.IsValid)
            {
                throw new Exception(result.OriginalException.Message);
            }
        }
        // burası çalışmıyor bakmak gerek ürün adına göre aggregate yapmak lazım
        public IEnumerable<Product> Search(string text)
        {
             var result = _elasticClient.Search<Product>(descriptor => descriptor
                 .Query(q => q
                     .QueryString(queryDescriptor => queryDescriptor
                         .Query(text)
                         .Fields(fs => fs
                             .Fields(f1 => f1.Description)
                         )
                     )
                 )
             );

            return (IEnumerable<Product>)result;
        }
    }
}
