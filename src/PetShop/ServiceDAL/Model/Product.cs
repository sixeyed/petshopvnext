using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.ServiceDAL.Model
{
    class Product
    {
        public string ProductId { get; set; }

        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
