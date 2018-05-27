using System;
using MongoDB.Bson.Serialization.Attributes;

namespace CrudMvcMongoDb.Models
{
    [BsonIgnoreExtraElements]
    public abstract class MongoDBModel 
    {
        private Guid _id;
        public string Id
        {
            get
            {
                if (_id == Guid.Empty)
                    _id = Guid.NewGuid();
                return _id.ToString();
            }
            set
            {
                _id = Guid.Parse(value);
            }
        }
        public virtual string CollectionName { get; }
        
    }
}