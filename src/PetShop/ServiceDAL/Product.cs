using Newtonsoft.Json;
using PetShop.IDAL;
using PetShop.Model;
using RestSharp;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace PetShop.ServiceDAL
{
    public class Product : IProduct
    {
        public ProductInfo GetProduct(string productId)
        {
            var request = new RestRequest("products/{productId}");
            request.AddParameter("productId", productId, ParameterType.UrlSegment);
            var client = GetProductServiceClient();
            var response = client.Execute(request);
            var json = response.Content;
            var product = JsonConvert.DeserializeObject<Model.Product>(json);
            return Map(product);
        }

        public IList<ProductInfo> GetProductsByCategory(string category)
        {
            var request = new RestRequest("products/category/{category}");
            request.AddParameter("category", category, ParameterType.UrlSegment);
            var client = GetProductServiceClient();
            var response = client.Execute(request);
            var json = response.Content;
            var products = JsonConvert.DeserializeObject<Model.Product[]>(json);
            return new List<ProductInfo>(products.Select(x => Map(x)));
        }

        public IList<ProductInfo> GetProductsBySearch(string[] keywords)
        {
            var request = new RestRequest("products");
            var client = GetProductServiceClient();
            var response = client.Execute(request);
            var json = response.Content;
            var products = JsonConvert.DeserializeObject<Model.Product[]>(json);
            var matches = new List<Model.Product>();
            foreach (var keyword in keywords)
            {
                //TODO - this doesn't match on category
                matches.AddRange(products.Where(x => x.Name.ToLower().Contains(keyword.ToLower())));
            }
            return new List<ProductInfo>(matches.Select(x => Map(x)));
        }

        private ProductInfo Map(Model.Product product)
        {
            return new ProductInfo
            {
                CategoryId = product.CategoryId,
                Description = product.Description,
                Id = product.ProductId,
                Image = product.ImageUrl,
                Name = product.Name
            };
        }

        private RestClient GetProductServiceClient()
        {
            var productServiceUrl = ConfigurationManager.AppSettings["Services.ProductServiceUrl"];
            return new RestClient(productServiceUrl);
        }
    }
}
