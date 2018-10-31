using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace PetShop.Model {
    /// <summary>
    /// Business entity used to model an item.
    /// </summary>
    [Serializable]
    [Table(Name="Item")]
    public class ItemInfo {

        public ItemInfo() { }

        /// <summary>
        /// Constructor with specified initial values
        /// </summary>
        /// <param name="id">Item Id</param>
        /// <param name="name">Item Name</param>
        /// <param name="quantity">Quantity in stock</param>
        /// <param name="price">Price</param>
        /// <param name="productName">Parent product name</param>
        /// <param name="image">Item image</param>
        /// <param name="categoryId">Category Id</param>
        /// <param name="productId">Product Id</param>
        public ItemInfo(string id, string name, int quantity, decimal price, string productName, string image, string categoryId, string productId) {
            this.Id = id;
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
            this.ProductName = productName;
            this.Image = image;
            this.CategoryId = categoryId;
            this.ProductId = productId;
        }

        // Properties
        public string Id { get; set; }

        public string Name { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string CategoryId { get; set; }

        public string ProductId { get; set; }
    }
}
