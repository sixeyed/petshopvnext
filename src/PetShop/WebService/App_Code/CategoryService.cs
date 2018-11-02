using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Contracts;
using bll = PetShop.BLL;

[ServiceBehavior(Namespace = "http://com.vnext.petshop/CategoryService")]
public class CategoryService : ICategoryService
{
    public Category[] GetCategories()
    {
        var svc = new bll.Category();
        var categories = svc.GetCategories().Select(x =>
        {
            return new Category
            {
                CategoryId = x.Id,
                Description = x.Description,
                Name = x.Name
            };
        });

        return categories.ToArray();
    }

    public Category GetCategoryById(string categoryId)
    {
        var svc = new bll.Category();
        var categoryInfo = svc.GetCategory(categoryId);

        var category = new Category
        {
            CategoryId = categoryInfo.Id,
            Description = categoryInfo.Description,
            Name = categoryInfo.Name
        };

        return category;
    }
}
