using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Contracts;

[ServiceContract(Namespace = "http://com.vnext.petshop/CategoryService")]
public interface ICategoryService
{
    [OperationContract]
    Category[] GetCategories();

    [OperationContract]
    Category GetCategoryById(string categoryId);
}
