using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Contracts
{
    [DataContract(Namespace = "http://com.vnext.petshop/ProductService")]
    public class Product
    {
        [DataMember]
        public string ProductId { get; set; }

        [DataMember]
        public string CategoryId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }
    }
}
