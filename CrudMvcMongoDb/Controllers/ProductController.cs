using System.Collections.Generic;
using System.Threading.Tasks;
using CrudMvcMongoDb.Models;
using CrudMvcMongoDb.Models.Interfaces;
using CrudMvcMongoDb.Models.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CrudMvcMongoDb.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> Get() =>        
             _productRepository.GetAll();

        [HttpGet("{id}", Name = "Get")]        
        public Product Get(string id) =>
            _productRepository.GetById(id);

        [HttpPost]
        public void Post([FromBody]Product product) =>
            _productRepository.Insert(product);

        [HttpPut]
        public void Put([FromBody]Product product) =>
            _productRepository.Update(product);

        [HttpDelete]
        public void Delete([FromBody]Product product) =>
            _productRepository.Delete(product.Id);

       
    }
}