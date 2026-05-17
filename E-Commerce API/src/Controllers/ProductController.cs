using Microsoft.AspNetCore.Mvc;
using E_Commerce_API.src.Service;
using E_Commerce_API.src.Models;
using E_Commerce_API.src.DTO;

namespace E_Commerce_API.src.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController: ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService) { 
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Created([FromBody] Product product)
        {
            var createdProduct = _productService.CreatedProduct(product);
            return Created("", createdProduct);
        }
    }
}
