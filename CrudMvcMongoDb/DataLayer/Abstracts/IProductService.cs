using System.Collections.Generic;
using System.Threading.Tasks;
using CrudMvcMongoDb.Models;
using MongoDB.Driver;

namespace CrudMvcMongoDb.DataLayer.Abstracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(string name);
        Task AddProductAsync(Product model);
        Task<bool> UpdatePriceAsync(Product model);
        Task<DeleteResult> RemoveProductAsync(string name);
        Task<DeleteResult> RemoveAllProductsAsync();
    }
}