using api.Controllers.Sell.Dtos;
using api.Controllers.Sell.Services;
using api.Database.Entities.Sell;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Sell
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellController : Controller
    {
        private readonly SellService sellService;

        public SellController(SellService sellService)
        {
            this.sellService = sellService;
        }

        [HttpGet("total-sells")]
        [ProducesResponseType(typeof(List<TotalSellByProductResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTotalSellsByProduct()
        {
            List<TotalSellByProductResponseDto> data = await sellService.getTotalSellsByProduct();
            return Ok(data);
        }

        [HttpGet("higher-seller")]
        [ProducesResponseType(typeof(HigherSellerResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHigherSeller()
        {
            HigherSellerResponseDto? data = await sellService.getHigherSeller();
            return Ok(data);
        }

        [HttpGet("all-selled-products")]
        [ProducesResponseType(typeof(List<AllSelledProductsResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSelledProducts()
        {
            List<AllSelledProductsResponseDto> data = await sellService.getAllSelledProducts();
            return Ok(data);
        }

        [HttpGet("total-sells-by-floor")]
        [ProducesResponseType(typeof(List<TotalSellsByFloor>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTotalSellsByFloor()
        {
            List<TotalSellsByFloor> data = await sellService.getTotalSellsByFloor();
            return Ok(data);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SellEntity), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(SellEntity), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateSellDto sell)
        {
            SellEntity? result = await sellService.create(sell);
            return result == null ? BadRequest() : Ok(result);
        }
    }
}
