using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model
{
    public class PersonMongoDal : MongoDal<Person>, IPersonMongoDal
    {
        private string collectionName = "Person";

        public PersonMongoDal(IOptions<DatabaseConfiguration> configuration) : base(configuration)
        { }

        public void UpdateMany(ICollection<Person> objetos)
        {
            foreach (var obj in objetos)
            {
                var dictionary = new Dictionary<string, object>
                {
                    { nameof(obj.VIP), obj.VIP },
                    { nameof(obj.Name), obj.Name },
                    { nameof(obj.DataAlteracao), DateTime.Now }
                };

                string json = JsonConvert.SerializeObject(dictionary);
                var bson = new BsonDocument() { { "$set", BsonDocument.Parse(json) } };
                var filtro = Builders<Person>.Filter.Eq("Id", obj.Id);
                _database.GetCollection<Person>(collectionName).UpdateOne(filtro, bson);
            }
        }
    }
}