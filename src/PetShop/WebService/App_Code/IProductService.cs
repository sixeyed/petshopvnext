using System.ServiceModel;
using Contracts;

[ServiceContract(Namespace="http://com.vnext.petshop/ProductService")]
public interface IProductService
{
    [OperationContract]
    Product[] GetProducts();

    [OperationContract]
    Product GetProductById(string productId);
}

