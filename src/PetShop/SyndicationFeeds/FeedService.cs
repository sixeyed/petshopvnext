using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;
using PetShop.SyndicationFeeds.Properties;
using PetShop.Model;
using PetShop.Model.DataContext;

namespace PetShop.SyndicationFeeds
{
    public class FeedService : IFeedService
    {
        /// <summary>
        /// Get Product List
        /// </summary>
        /// <param name="category">Category Id</param>
        /// <returns></returns>
        public SyndicationFeedFormatter GetProducts(string category)
        {
            Uri uri = GetRootUri();
            SyndicationFeed feed = new SyndicationFeed(
                Resource.FeedTitle,
                Resource.FeedContent,
                uri
                );

            MSPetShop4DataContext db = new MSPetShop4DataContext();
            
            IEnumerable<SyndicationItem> items = from p in db.Products
                         where p.Category.Id == category
                         orderby p.Id descending
                         select CreateSyndicationItem(p, uri, category);

            feed.Items = items.Take(10);
            return new Rss20FeedFormatter(feed);
        }

        private SyndicationItem CreateSyndicationItem(ProductInfo p, Uri rootUri, string category)
        {
            UriBuilder uriBuilder = new UriBuilder(rootUri);
            uriBuilder.Path += "Items.aspx";
            uriBuilder.Query = String.Format("productId={0}&categoryId={1}", p.Id, category);
            var item = new SyndicationItem(p.Name, p.Description, uriBuilder.Uri);

            return item;
        }

        /// <summary>
        /// Get Root Uri
        /// </summary>
        /// <returns></returns>
        private Uri GetRootUri()
        {
            Uri uri = OperationContext.Current.Channel.LocalAddress.Uri;
            UriBuilder builder = new UriBuilder(uri);

            StringBuilder pathBuilder = new StringBuilder(builder.Path);
            int indexOfSlash = builder.Path.LastIndexOf('/');
            pathBuilder.Remove(indexOfSlash + 1, builder.Path.Length - indexOfSlash - 1);
            
            builder.Path = pathBuilder.ToString();
            return builder.Uri;
        }
    }
}
