using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace PetShop.Model.DataContext
{
    [Database(Name="MSPetShop4")]
    public class MSPetShop4DataContext : System.Data.Linq.DataContext
    {
        public MSPetShop4DataContext()
            : base(ConfigurationManager.ConnectionStrings["SQLConnString1"].ConnectionString)
        { 
        }

        public Table<ProductInfo> Products
        {
            get { return this.GetTable<ProductInfo>(); }
        }

        public Table<CategoryInfo> Categories
        {
            get { return this.GetTable<CategoryInfo>(); }
        }
    }
}
