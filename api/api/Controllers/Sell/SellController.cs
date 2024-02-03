using api.Controllers.Sell.Dtos;
using api.Controllers.Sell.Services;
using api.Database.Entities.Product;
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
