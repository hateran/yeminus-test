using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using api.Controllers.Product.Dtos;

namespace api.Database.Entities.Product
{
    public class ProductRepository: IProductRepository
    {
        private readonly DataContext dbRepository;
        public ProductRepository(DataContext _DbRepository)
        {
            dbRepository = _DbRepository;
        }

        public async Task<ProductEntity?> GetById(int code)
        {
            return await dbRepository.Product.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<List<ProductEntity>> listAll()
        {
            return await dbRepository.Product.ToListAsync();
        }

        public async Task<ProductEntity?> create(CreateProductDto product)
        {
            ProductEntity entity = new ProductEntity()
            {
                Name = product.Name,
                Price = product.Price,
            };

            EntityEntry<ProductEntity> response = await dbRepository.Product.AddAsync(entity);
            await dbRepository.SaveChangesAsync();

            return await GetById(response.Entity.Code ?? throw new Exception("Error al guardar"));
        }

        public async Task<ProductEntity?> update(ProductEntity product)
        {
            EntityEntry<ProductEntity> response = dbRepository.Product.Update(product);
            await dbRepository.SaveChangesAsync();

            return await GetById(response.Entity.Code ?? throw new Exception("Error al actualizar"));
        }

        public async Task delete(ProductEntity product)
        {
            EntityEntry<ProductEntity> response = dbRepository.Product.Remove(product);
            await dbRepository.SaveChangesAsync();
        }
    }
}
