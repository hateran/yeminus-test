using api.Database.Entities.Product;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using api.Database.Entities.Dispatcher;
using api.Database.Entities.RegisterMachine;

namespace api.Database.Entities.Sell
{
    public class SellRepository : ISellRepository
    {
        private readonly DataContext dbRepository;

        public SellRepository(DataContext _DbRepository)
        {
            dbRepository = _DbRepository;
        }

        public async Task<SellEntity?> GetById(int productId, int dispatcherId, int machineId, Boolean getRelations = false)
        {
            SellEntity? sell = await dbRepository.Sell.FirstOrDefaultAsync(x => x.Product == productId && x.Dispatcher == dispatcherId && x.Machine == machineId);

            if (sell != null && getRelations)
            {
                ProductEntity product = await dbRepository.Product.FirstOrDefaultAsync(x => x.Code == productId);
                DispatcherEntity dispatcher = await dbRepository.Dispatcher.FirstOrDefaultAsync(X => X.Code == dispatcherId);
                RegisterMachineEntity registerMachine = await dbRepository.RegisterMachine.FirstOrDefaultAsync(x => x.Code == machineId);

                sell.productRelation = product;
                sell.dispatcherRelation = dispatcher;
                sell.registerMachineRelation = registerMachine;
            }

            return sell;
        }

        public async Task<List<SellEntity>> listAll()
        {
            return await dbRepository.Sell.ToListAsync();
        }

        public async Task<SellEntity?> create(int productId, int dispatcherId, int machineId)
        {
            ProductEntity? productEntity = await dbRepository.Product.FirstOrDefaultAsync(x => x.Code == productId);
            DispatcherEntity? dispatcherEntity = await dbRepository.Dispatcher.FirstOrDefaultAsync(X => X.Code == dispatcherId);
            RegisterMachineEntity? registerMachineEntity = await dbRepository.RegisterMachine.FirstOrDefaultAsync(x => x.Code == machineId);

            if (productEntity == null || dispatcherEntity == null || registerMachineEntity == null)
                throw new Exception("Producto, cajero o maquina no encontrada");

            SellEntity? searchSell = await dbRepository.Sell.FirstOrDefaultAsync(x => x.Product == productId && x.Dispatcher == dispatcherId && x.Machine == machineId);

            if (searchSell != null)
                throw new Exception("Esta venta ya existe");

            SellEntity entity = new SellEntity()
            {
                Product = productId,
                Dispatcher = dispatcherId,
                Machine = machineId,
            };

            EntityEntry<SellEntity> response = await dbRepository.Sell.AddAsync(entity);
            await dbRepository.SaveChangesAsync();

            return await GetById(response.Entity.Product, response.Entity.Dispatcher, response.Entity.Machine);
        }

        public async Task<SellEntity?> update(SellEntity sell)
        {
            EntityEntry<SellEntity> response = dbRepository.Sell.Update(sell);
            await dbRepository.SaveChangesAsync();

            return await GetById(response.Entity.Product, response.Entity.Dispatcher, response.Entity.Machine);
        }

        public async Task delete(SellEntity sell)
        {
            EntityEntry<SellEntity> response = dbRepository.Sell.Remove(sell);
            await dbRepository.SaveChangesAsync();
        }

        public async Task getTotalSellsByProduct()
        {
            //List<SellEntity> sells = [];
        }
    }
}
