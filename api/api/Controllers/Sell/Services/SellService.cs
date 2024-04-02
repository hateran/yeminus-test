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
            return  await sellRepository.create(sell.Product, sell.Dispatcher, sell.Machine);
        }

        public async Task<List<TotalSellByProductResponseDto>> getTotalSellsByProduct()
        {
            return await sellRepository.getTotalSellsByProduct();
        }

        public async Task<HigherSellerResponseDto?> getHigherSeller()
        {
            return await sellRepository.getHigherSeller();
        }

        public async Task<List<AllSelledProductsResponseDto>> getAllSelledProducts()
        {
            return await sellRepository.getAllSelledProducts();
        }

        public async Task<List<TotalSellsByFloor>> getTotalSellsByFloor()
        {
            return await sellRepository.getTotalSellsByFloor();
        }
    }
}
