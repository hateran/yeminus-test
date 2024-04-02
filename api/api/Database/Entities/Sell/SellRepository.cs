using api.Database.Entities.Product;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using api.Database.Entities.Dispatcher;
using api.Database.Entities.RegisterMachine;
using api.Controllers.Sell.Dtos;

namespace api.Database.Entities.Sell
{
    public class SellRepository : ISellRepository
    {
        private readonly DataContext dbRepository;
        private readonly IDispatcherRepository dispatcherRepository;
        private readonly IProductRepository productRepository;
        private readonly IRegisterMachineRepository registerMachineRepository;

        public SellRepository(DataContext _DbRepository, IDispatcherRepository dispatcherRepository, IProductRepository productRepository, IRegisterMachineRepository registerMachineRepository)
        {
            dbRepository = _DbRepository;
            this.dispatcherRepository = dispatcherRepository;
            this.productRepository = productRepository;
            this.registerMachineRepository = registerMachineRepository;
        }

        public async Task<SellEntity?> GetById(int productId, int dispatcherId, int machineId, Boolean getRelations = false)
        {
            SellEntity? sell = await dbRepository.Sell.FirstOrDefaultAsync(x => x.Product == productId && x.Dispatcher == dispatcherId && x.Machine == machineId);

            if (sell != null && getRelations)
            {
                ProductEntity? product = await productRepository.GetById(productId);
                DispatcherEntity? dispatcher = await dispatcherRepository.GetById(dispatcherId);
                RegisterMachineEntity? registerMachine = await registerMachineRepository.GetById(machineId);

                if (product != null) sell.productRelation = product;
                if (dispatcher != null) sell.dispatcherRelation = dispatcher;
                if (registerMachine != null) sell.registerMachineRelation = registerMachine;
            }

            return sell;
        }

        public async Task<List<SellEntity>> listAll()
        {
            return await dbRepository.Sell.ToListAsync();
        }

        public async Task<SellEntity?> create(int productId, int dispatcherId, int machineId)
        {
            ProductEntity? productEntity = await productRepository.GetById(productId);
            DispatcherEntity? dispatcherEntity = await dispatcherRepository.GetById(dispatcherId);
            RegisterMachineEntity? registerMachineEntity = await registerMachineRepository.GetById(machineId);

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

        public async Task<List<TotalSellByProductResponseDto>> getTotalSellsByProduct()
        {
            return await dbRepository.Database.SqlQueryRaw<TotalSellByProductResponseDto>("SELECT count(1) as total, P.\"Code\", max(P.\"Name\") as Name FROM \"Sell\" S inner join \"Product\" P on P.\"Code\" = S.\"Product\" group by P.\"Code\" order by \"Code\"").ToListAsync();
        }

        public async Task<HigherSellerResponseDto?> getHigherSeller()
        {
            return await dbRepository.Database.SqlQueryRaw<HigherSellerResponseDto>("SELECT D.\"Code\", D.\"NomApels\" FROM (SELECT COUNT(S.\"Dispatcher\") as \"totalSell\", S.\"Dispatcher\" FROM \"Sell\" S GROUP BY S.\"Dispatcher\" ORDER BY \"totalSell\" DESC LIMIT 1) subquery INNER JOIN \"Dispatcher\" D ON D.\"Code\" = subquery.\"Dispatcher\"").FirstOrDefaultAsync();
        }

        public async Task<List<AllSelledProductsResponseDto>> getAllSelledProducts()
        {
            return await dbRepository.Database.SqlQueryRaw<AllSelledProductsResponseDto>("SELECT S.\"Dispatcher\", S.\"Machine\", S.\"Product\", P.\"Name\", P.\"Price\"\r\nFROM \"Sell\" S INNER JOIN \"Product\" P on P.\"Code\" = S.\"Product\"").ToListAsync();
        }

        public async Task<List<TotalSellsByFloor>> getTotalSellsByFloor()
        {
            return await dbRepository.Database.SqlQueryRaw<TotalSellsByFloor>("SELECT max(RM.\"Floor\") as \"Floor\", SUM(P.\"Price\") as \"totalValue\"\r\nFROM \"Sell\" S INNER JOIN \"Product\" P on P.\"Code\" = S.\"Product\" INNER JOIN \"RegisterMachine\" RM on RM.\"Code\" = S.\"Machine\" GROUP BY S.\"Machine\"").ToListAsync();
        }
    }
}
