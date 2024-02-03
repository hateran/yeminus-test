using api.Controllers.Product.Dtos;
using api.Controllers.Product.Services;
using api.Database.Entities.Product;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Product
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        private readonly IMapper mapper;

        public ProductController(ProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAll()
        {
            List<ProductEntity> products = await productService.ListAll();
            List<ProductResponseDto> response = mapper.Map<List<ProductResponseDto>>(products);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProductEntity? result = await productService.getById(id);
            if(result == null) { return NotFound(); }
            ProductResponseDto response = mapper.Map<ProductResponseDto>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            Boolean? result = await productService.delete(id);
            if (result == false) { return NotFound(); }
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateProductDto product)
        {
            ProductEntity? result = await productService.create(product);
            if (result == null) return BadRequest();
            ProductResponseDto response = mapper.Map<ProductResponseDto>(result);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, CreateProductDto product)
        {
            ProductEntity? result = await productService.update(id,product);
            if (result == null) return NotFound();
            ProductResponseDto response = mapper.Map<ProductResponseDto>(result);
            return Ok(response);
        }
    }
}
