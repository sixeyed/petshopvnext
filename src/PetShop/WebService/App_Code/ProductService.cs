using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Contracts;
using bll = PetShop.BLL;

[ServiceBehavior(Namespace = "http://com.vnext.petshop/ProductService")]
public class ProductService : IProductService
{
    public Product GetProductById(string productId)
    {
        var svc = new bll.Product();
        var productInfo = svc.GetProduct(productId);

        return new Product
        {
            ProductId = productInfo.Id,
            CategoryId = productInfo.CategoryId,
            Description = productInfo.Description,
            ImageUrl = productInfo.Image,
            Name = productInfo.Name
        };
    }

    public Product[] GetProducts()
    {        
        var categorySvc = new bll.Category();
        var categories = categorySvc.GetCategories().Select(x => x.Id);
        var products = new List<Product>();
        var productSvc = new bll.Product();

        foreach (var category in categories)
        {
            var productInfos = productSvc.GetProductsByCategory(category);
            products.AddRange(productInfos.Select(x =>
            {
                return new Product
                {
                    ProductId = x.Id,
                    CategoryId = x.CategoryId,
                    Description = x.Description,
                    ImageUrl = x.Image,
                    Name = x.Name
                };
            }));
        }    

        return products.ToArray();
    }
}
