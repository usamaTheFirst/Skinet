using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase

    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok( await _repo.GetProductsAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            
            return Ok( _repo.GetProductByIdAsync(id).GetAwaiter().GetResult());
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<Product>> GetProductBrands()
        {

            return Ok(_repo.GetProductBrandsAsync().GetAwaiter().GetResult());
        }
        [HttpGet("Types")]
        public async Task<ActionResult<Product>> GetProductTypes()
        {

            return Ok(_repo.GetProductTypesAsync().GetAwaiter().GetResult());
        }

    }
}
