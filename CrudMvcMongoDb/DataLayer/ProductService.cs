using System.Collections.Generic;
using System.Threading.Tasks;
using CrudMvcMongoDb.DataLayer.Abstracts;
using CrudMvcMongoDb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CrudMvcMongoDb.DataLayer
{
    public class ProductService : IProductService   
    {
        private readonly MongoRepository _repository = null;

        public ProductService(IOptions<Settings> settings)
        {
            _repository = new MongoRepository(settings);
        }
        
        public async Task AddProductAsync(Product model)
        {
            await _repository.products.InsertOneAsync(model);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _repository.products.Find(x => true).ToListAsync();
        }

        public async Task<Product> GetProductAsync(string name)
        {
            var filter = Builders<Product>.Filter.Eq("Name", name);
            return await _repository.products.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> RemoveAllProductsAsync()
        {
            return await _repository.products.DeleteManyAsync(new BsonDocument());
        }

        public async Task<DeleteResult> RemoveProductAsync(string name)
        {
             var filter = Builders<Product>.Filter.Eq("Name", name);
            return await _repository.products.DeleteOneAsync(filter);
        }

        public async Task<bool> UpdatePriceAsync(Product model)
        {
             var filter = Builders<Product>.Filter.Eq("Name", model.Name);
            var product = _repository.products.Find(filter).FirstOrDefaultAsync();
            if (product.Result == null)
                return false;
            var update = Builders<Product>.Update
                                          .Set(x => x.Price, model.Price);
  
            await _repository.products.UpdateOneAsync(filter, update);
            return true;
        }
    }
}