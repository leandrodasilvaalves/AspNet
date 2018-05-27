using System.Collections.Generic;

namespace CrudMvcMongoDb.Models.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository
    {
         IEnumerable<Product> GetAll();

         Product GetById(string id);

         void Insert(Product product);

         void Update(Product product);

         void Delete(string id);
    }
}