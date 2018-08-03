using Microsoft.Extensions.Options;
using Model.Entities;
using Model.Enums;
using Model.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Model.DataBase
{
    public class MongoDal<T> : IMongoDal<T> where T : EntityBase
    {
        protected readonly IMongoDatabase _database;
        protected string _connectionString;
        protected string _bancoDeDados;

        public MongoDal(IOptions<DatabaseConfiguration> configuration)
        {
            _connectionString = configuration.Value.ConnectionString;
            _bancoDeDados = configuration.Value.DatabaseName;

            var mongoClient = new MongoClient(_connectionString);
            if (mongoClient != null)
                _database = mongoClient.GetDatabase(_bancoDeDados);
        }

        public void InsertData(string collectionName, ICollection<T> collectionData) =>
            _database.GetCollection<T>(collectionName).InsertMany(collectionData);

        public void UpdateOne(string collectionName, T document)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            var bson = new BsonDocument() { { "$set", BsonDocument.Parse(JsonConvert.SerializeObject(document, serializerSettings)) } };
            _database.GetCollection<T>(collectionName).UpdateOne(Builders<T>.Filter.Eq("Id", document.Id), bson);
        }

        public void UpdateOne(string collectionName, Dictionary<string, object> dictionary, string id)
        {
            dictionary.Add("DataAlteracao", DateTime.Now);
            string json = JsonConvert.SerializeObject(dictionary, Formatting.None);
            var bson = new BsonDocument() { { "$set", BsonDocument.Parse(json) } };
            _database.GetCollection<T>(collectionName).UpdateOne(Builders<T>.Filter.Eq("Id", id), bson);
        }

        public ICollection<T> ListData(string collectionData, Expression<Func<T, object>> order, TypeOrder typeOrder = TypeOrder.Ascending)
        {
            if(typeOrder == TypeOrder.Ascending)
                return _database.GetCollection<T>(collectionData).Find(x => true).SortBy(order).ToList();
            else
                return _database.GetCollection<T>(collectionData).Find(x => true).SortByDescending(order).ToList();
        }

        public void ClearDataBase(string collectionName) =>
            _database.DropCollection(collectionName);
    }

}
