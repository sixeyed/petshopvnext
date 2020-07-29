using System;

namespace PetShop.Services.Model
{
    public class Product
    {
        public string ProductId { get; set; }

        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
