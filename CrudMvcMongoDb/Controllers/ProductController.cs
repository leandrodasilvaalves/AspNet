using Microsoft.AspNetCore.Mvc;
using CrudMvcMongoDb.DataLayer.Abstracts;
using System.Threading.Tasks;
using System;
using CrudMvcMongoDb.Models;
using System.Collections.Generic;

namespace CrudMvcMongoDb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
                _productService = productService;            
        }

        [HttpGet]
        [Route("api/product")]
        public Task<IEnumerable<Product>> Get()
        {
            return _productService.GetAllProductsAsync();
        }
  
        [HttpGet]
        [Route("api/product/getByName")]
        public async Task<IActionResult> GetByCategory(string name)
        {
            try
            {
                var product = await _productService.GetProductAsync(name);
                if (product == null)
                {
                    return Json("No product found!");
                }
                return Json(product);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
  
            }
  
        }
  
        [HttpPost]
        [Route("api/product")]
        public async Task<IActionResult> Post(Product model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Name))
                    return BadRequest("Please enter product name");                
                else if (model.Price <= 0)
                    return BadRequest("Please enter price");
  
                await _productService.AddProductAsync(model);
                return Ok("Your product has been added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
  
        [HttpPut]
        [Route("api/product/updatePrice")]
        public async Task<IActionResult> UpdatePrice(Product model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                return BadRequest("Product name missing");
            var result = await _productService.UpdatePriceAsync(model);
            if (result)
            {
                return Ok("Your product's price has been updated successfully");
            }
            return BadRequest("No product found to update");
  
        }
  
        [HttpDelete]
        [Route("api/product")]
        public async Task<IActionResult> Delete(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return BadRequest("Product name missing");
                await _productService.RemoveProductAsync(name);
                return Ok("Your product has been deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("api/product/deleteAll")]
        public IActionResult DeleteAll()
        {
            try
            {
                _productService.RemoveAllProductsAsync();
                return Ok("Your all products has been deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }




    }
}