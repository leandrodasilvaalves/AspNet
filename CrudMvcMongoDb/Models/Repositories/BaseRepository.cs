using System;
using System.Collections.Generic;
using CrudMvcMongoDb.Models.Interfaces;
using CrudMvcMongoDb.Models.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CrudMvcMongoDb.Models.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IMongoDatabase _database;
                
        public BaseRepository(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.DataBase);
        }
        public DataDomain GetDataDomain() =>
            DataDomainCollection.Find(x => true).FirstOrDefault();

        public void InsertDataDomain(DataDomain dataDomain) 
        {   
            if(GetDataDomain() == null)
                DataDomainCollection.InsertOne(dataDomain);
            else
                UpdateDataDomain(dataDomain);
        }

        public void UpdateDataDomain(DataDomain dataDomain) =>
            DataDomainCollection.ReplaceOne(x => x.Id == dataDomain.Id, dataDomain);

        private IMongoCollection<DataDomain> DataDomainCollection =>      
            _database.GetCollection<DataDomain>("DataDomain");
    }
}