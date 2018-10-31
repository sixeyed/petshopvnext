using System;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Text;
using System.Collections.Generic;
using PetShop.Model;
using PetShop.IDAL;
using PetShop.DBUtility;
using PetShop.Model.DataContext;

namespace PetShop.SQLServerDAL {

    public class Product : IProduct {

        //Static constants
        private const string SQL_SELECT_PRODUCTS_BY_SEARCH1 = "SELECT ProductId, Name, Descn, Product.Image, Product.CategoryId FROM Product WHERE ((";
        private const string SQL_SELECT_PRODUCTS_BY_SEARCH2 = "LOWER(Name) LIKE '%' + {0} + '%' OR LOWER(CategoryId) LIKE '%' + {0} + '%'";
        private const string SQL_SELECT_PRODUCTS_BY_SEARCH3 = ") OR (";
        private const string SQL_SELECT_PRODUCTS_BY_SEARCH4 = "))";
        private const string PARM_CATEGORY = "@Category";
        private const string PARM_KEYWORD = "@Keyword";
        private const string PARM_PRODUCTID = "@ProductId";

        /// <summary>
        /// Query for products by category
        /// </summary>
        /// <param name="category">category name</param>  
        /// <returns>A Generic List of ProductInfo</returns>
        public IList<ProductInfo> GetProductsByCategory(string category) {
            MSPetShop4DataContext db = new MSPetShop4DataContext();

            IEnumerable<ProductInfo> products = from p in db.Products
                                                where p.Category.Id == category
                                                select p;
            return products.ToList<ProductInfo>();
        }

        /// <summary>
        /// Query for products by keywords. 
        /// The results will include any product where the keyword appears in the category name or product name
        /// </summary>
        /// <param name="keywords">string array of keywords</param>
        /// <returns>A Generic List of ProductInfo</returns>
        public IList<ProductInfo> GetProductsBySearch(string[] keywords) {

            IList<ProductInfo> productsBySearch = new List<ProductInfo>();

            int numKeywords = keywords.Length;

            //Create a new query string
            StringBuilder sql = new StringBuilder(SQL_SELECT_PRODUCTS_BY_SEARCH1);

            //Add each keyword to the query
            for (int i = 0; i < numKeywords; i++) {
                sql.Append(string.Format(SQL_SELECT_PRODUCTS_BY_SEARCH2, PARM_KEYWORD + i));
                sql.Append(i + 1 < numKeywords ? SQL_SELECT_PRODUCTS_BY_SEARCH3 : SQL_SELECT_PRODUCTS_BY_SEARCH4);
            }

            string sqlProductsBySearch = sql.ToString();
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlProductsBySearch);

            // If the parameters are null build a new set
            if (parms == null)
            {
                parms = new SqlParameter[numKeywords];

                for (int i = 0; i < numKeywords; i++)
                    parms[i] = new SqlParameter(PARM_KEYWORD + i, SqlDbType.VarChar, 80);

                SqlHelper.CacheParameters(sqlProductsBySearch, parms);
            }

            // Bind the new parameters
            for (int i = 0; i < numKeywords; i++)
                parms[i].Value = keywords[i];

            //Finally execute the query
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sqlProductsBySearch, parms)) {
                while (rdr.Read()) {
                    ProductInfo product = new ProductInfo(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
                    productsBySearch.Add(product);
                }
            }

            return productsBySearch;
        }

        /// <summary>
        /// Query for a product
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>ProductInfo object for requested product</returns>
        public ProductInfo GetProduct(string productId) {
            MSPetShop4DataContext db = new MSPetShop4DataContext();

            var product = db.Products.Single(p => p.Id == productId);

            return product;
        }
    }
}
