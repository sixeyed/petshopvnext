using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace PetShop.Model {

    /// <summary>
    /// Business entity used to model a product
    /// </summary>
    [Table(Name = "Product")]
    public class ProductInfo {

        private EntityRef<CategoryInfo> _category;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductInfo() { }

        /// <summary>
        /// Constructor with specified initial values
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <param name="name">Product Name</param>
        /// <param name="description">Product Description</param>
        /// <param name="image">Product image</param>
        /// <param name="categoryId">Category Id</param>
        public ProductInfo(string id, string name, string description, string image, string categoryId) {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this._category = new EntityRef<CategoryInfo>();
            this._category.Entity.Id = categoryId;
        }

        // Properties
        [Column(Name = "ProductId", IsPrimaryKey = true, DbType = "varchar(10)")]
        public string Id { get; set; }

        [Column(Name = "Name", DbType = "varchar(80)")]
        public string Name { get; set; }

        [Column(Name = "Descn", DbType = "varchar(255)")]
        public string Description { get; set; }

        [Column(Name = "Image", DbType = "varchar(80)")]
        public string Image { get; set; }

        [Column(Name = "CategoryId", DbType = "varchar(10)")]
        public string CategoryId { get; set; }

        [Association(IsForeignKey = true, ThisKey = "CategoryId", Storage = "_category")]
        public CategoryInfo Category
        {
            get 
            {
                return this._category.Entity;
            }
            set 
            { 
                this._category.Entity = value;
                value.Products.Add(this);
            }
        }
    }
}