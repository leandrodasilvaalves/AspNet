using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Entities
{
    public abstract class EntityBase
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
