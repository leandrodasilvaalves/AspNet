using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Linq;
using MongoDB.Driver;
using CrudMvcMongoDb.Models.Interfaces.Repositories;

namespace CrudMvcMongoDb.Models.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private DataDomain _dataDomain;
        public ProductRepository(IOptions<Settings> settings) : base(settings)
        {
            _dataDomain = base.GetDataDomain();
            if (_dataDomain == null)
                _dataDomain = new DataDomain();
        }

        public Product GetById(string id) => 
            _dataDomain.Products.FirstOrDefault(x => x.Id == id);

        public void Delete(string id)
        {
            var product = GetById(id);
            _dataDomain.Products.Remove(product);
            base.UpdateDataDomain(_dataDomain);
        }

        public IEnumerable<Product> GetAll() =>
            _dataDomain.Products;        

        public void Insert(Product product)
        {
            if(GetById(product.Id)==null)
            {
                _dataDomain.Products.Add(product);
                base.InsertDataDomain(_dataDomain);
            }
        }

        public void Update(Product product)
        {
            var prod = GetById(product.Id);            
            _dataDomain.Products.Remove(prod);
            _dataDomain.Products.Add(product);            
            base.UpdateDataDomain(_dataDomain);
        }
    }
}