using PetShop.Services.Entities;
using PetShop.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Tools.ProductDatabaseMigrator.Data
{
    class Target
    {
        private readonly PetShopContext _context;

        public Target(PetShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public void SaveProducts(IEnumerable<Product> source)
        {
            _context.Products.AddRange(source.Select(x => new Product
            {
                CategoryId = x.CategoryId,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                ProductId = x.ProductId
            }));

            _context.SaveChanges();
        }
    }
}
