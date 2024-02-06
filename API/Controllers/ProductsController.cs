using API.Controllers;
using API.DTOs;
using API.Errors;
using AutoMapper;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Controllers
{
  
    public class ProductsController : BaseApiController

    {
        private readonly IGenereicRepository<Product> _productRepository;
        private readonly IGenereicRepository<ProductType> _productTypeRepository;
        private readonly IGenereicRepository<ProductBrand> _productBrandRepository;
        private readonly IMapper _mapper;


        public ProductsController(IGenereicRepository<Product> productRepo, IGenereicRepository<ProductType> productTypeRepository, IGenereicRepository<ProductBrand> productBrandRepository, IMapper mapper)
        {
            this._productRepository = productRepo;
            this._productTypeRepository = productTypeRepository;
            this._productBrandRepository = productBrandRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> GetProducts()
        {
            var specs = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productRepository.ListAsync(specs);
            var ProductsToReturn = _mapper.Map<IReadOnlyList<ProductToReturnDTO>>(products);
            return Ok( ProductsToReturn );
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            var specs = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepository.GetEntityWithSpecification(specs);
            if (product is null)
            {

                return NotFound(new ApiResponse(404));
            }
            ProductToReturnDTO productToReturn = _mapper.Map<ProductToReturnDTO>(product);
            //ProductToReturnDTO productToReturn = new ProductToReturnDTO
            //{
            //    Id = product.Id,
            //    Description = product.Description,
            //    Name = product.Name,
            //    PictureUrl = product.PictureUrl,
            //    Price = product.Price,
            //    ProductBrand = product.ProductBrand.Name,
            //    ProductType = product.ProductType.Name
            //};

            return Ok(productToReturn );
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<Product>> GetProductBrands()
        {

            return Ok(_productBrandRepository.ListAllAsync().GetAwaiter().GetResult());
        }
        [HttpGet("Types")]
        public async Task<ActionResult<Product>> GetProductTypes()
        {

            return Ok(_productTypeRepository.ListAllAsync().GetAwaiter().GetResult());
        }

    }
}
