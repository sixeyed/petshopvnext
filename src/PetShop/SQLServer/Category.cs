using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using PetShop.DBUtility;
using PetShop.Model;
using PetShop.IDAL;
using PetShop.Model.DataContext;

namespace PetShop.SQLServerDAL {

    public class Category : ICategory {
        /// <summary>
        /// Method to get all categories
		/// </summary>	    	 
        public IList<CategoryInfo> GetCategories() {

            MSPetShop4DataContext db = new MSPetShop4DataContext();
            IEnumerable<CategoryInfo> categories = from c in db.Categories
                                                   select c;

            return categories.ToList<CategoryInfo>();
        }

        /// <summary>
        /// Get an individual category based on a provided id
        /// </summary>
        /// <param name="categoryId">Category id</param>
        /// <returns>Details about the Category</returns>
        public CategoryInfo GetCategory(string categoryId) {
            
            MSPetShop4DataContext db = new MSPetShop4DataContext();
            var category = db.Categories.Single(c => c.Id == categoryId);

            return category;
        }
    }
}
