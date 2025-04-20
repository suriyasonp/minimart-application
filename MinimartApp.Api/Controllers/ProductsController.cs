using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimartApp.Application.DTOs;
using MinimartApp.Application.Interfaces;
using MinimartApp.Application.Services;
using MinimartApp.Domain.Entities;

namespace MinimartApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(ILogger<ProductsController> logger, ProductService productService) : ControllerBase
    {
        [HttpGet(Name = "GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            var products = await productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id:guid}", Name = "GetProductById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto productCreateDto)
        {
            var response = await productService.AddProductAsync(productCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }
    }
}
