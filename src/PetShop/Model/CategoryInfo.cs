using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace PetShop.Model {

    /// <summary>
    /// Business entity used to model a product
    /// </summary>
    [Table(Name = "Category")]
    public class CategoryInfo {

        private EntitySet<ProductInfo> _products;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CategoryInfo() { }

        /// <summary>
        /// Constructor with specified initial values
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <param name="name">Category Name</param>
        /// <param name="description">Category Description</param>
        public CategoryInfo(string id, string name, string description) {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            _products = new EntitySet<ProductInfo>();
        }

        // Properties
        [Column(Name = "CategoryId", IsPrimaryKey = true, DbType = "varchar(10)")]
        public string Id { get; set; }

        [Column(Name = "Name", DbType = "varchar(80)")]
        public string Name { get; set; }

        [Column(Name = "Descn", DbType = "varchar(255)")]
        public string Description { get; set; }

        [Association(OtherKey = "CategoryId", Storage = "_products")]
        public EntitySet<ProductInfo> Products
        {
            get
            { 
                return _products; 
            }
            set 
            {
                this._products.Assign(value); 
            }
        }
    }
}