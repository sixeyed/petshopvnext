using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace PetShop.SyndicationFeeds
{
    [ServiceContract]
    public interface IFeedService
    {
        [OperationContract]
        [WebGet]
        [ServiceKnownType(typeof(Rss20FeedFormatter))]
        SyndicationFeedFormatter GetProducts(string category);
    }
}
