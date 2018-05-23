using System;
using CrudMvcMongoDb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CrudMvcMongoDb.DataLayer
{
    public class MongoRepository
    {
        private readonly IMongoDatabase _database;
        
        public MongoRepository(IOptions<Settings> settings)
        {
            try
            {
                var client = new MongoClient(settings.Value.ConnectionString);
                if (client != null)
                    _database = client.GetDatabase(settings.Value.DataBase);
            }
            catch(Exception ex)
            {
                throw new Exception("Can not access to MongoDb server.", ex);
            }
        }

        public IMongoCollection<Product> products =>      
            _database.GetCollection<Product>("Products");
    }
}