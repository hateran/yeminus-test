using api.Controllers.Sell.Dtos;

namespace api.Database.Entities.Sell
{
    public interface ISellRepository
    {
        public Task<SellEntity?> GetById(int productId, int dispatcherId, int machineId, Boolean getRelations = false);
        public Task<List<SellEntity>> listAll();
        public Task<SellEntity?> create(int productId, int dispatcherId, int machineId);
        public Task<SellEntity?> update(SellEntity sell);
        public Task delete(SellEntity sell);
        public Task<List<TotalSellByProductResponseDto>> getTotalSellsByProduct();
        public Task<HigherSellerResponseDto?> getHigherSeller();
        public Task<List<AllSelledProductsResponseDto>> getAllSelledProducts();
        public Task<List<TotalSellsByFloor>> getTotalSellsByFloor();
    }
}
