using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace CrudMvcMongoDb.Models
{
    [BsonIgnoreExtraElements]
    public class DataDomain : MongoDBModel
    {
        public ICollection<Product> Products { get; set; }

        public override string CollectionName=> "DataDomain"; 

        public DataDomain()
        {
            Products = new List<Product>();
        }
    }
}