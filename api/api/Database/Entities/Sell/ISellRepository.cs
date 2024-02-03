namespace api.Database.Entities.Sell
{
    public interface ISellRepository
    {
        public Task<SellEntity?> GetById(int productId, int dispatcherId, int machineId, Boolean getRelations = false);
        public Task<List<SellEntity>> listAll();
        public Task<SellEntity?> create(int productId, int dispatcherId, int machineId);
        public Task<SellEntity?> update(SellEntity sell);
        public Task delete(SellEntity sell);
    }
}
