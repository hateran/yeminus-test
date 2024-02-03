using api.Controllers.Sell.Dtos;
using api.Database.Entities.Sell;

namespace api.Controllers.Sell.Services
{
    public class SellService
    {
        private readonly ISellRepository sellRepository;
        public SellService(ISellRepository sellRepository)
        {
            this.sellRepository = sellRepository;
        }

        public async Task<SellEntity?> create(CreateSellDto sell)
        {
            SellEntity? sellEntity = await sellRepository.create(sell.Product, sell.Dispatcher, sell.Machine);
            return sellEntity;
        }
    }
}
