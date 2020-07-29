using PetShop.Services.Entities;
using PetShop.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Tools.ProductDatabaseMigrator.Data
{
    class Source
    {
        private readonly PetShopContext _context;

        public Source(PetShopContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
