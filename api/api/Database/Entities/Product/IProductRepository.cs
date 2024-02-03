using api.Controllers.Product.Dtos;

namespace api.Database.Entities.Product
{
    public interface IProductRepository
    {
        public Task<ProductEntity?> GetById(int code);
        public Task<List<ProductEntity>> listAll();
        public Task<ProductEntity?> create(CreateProductDto product);
        public Task<ProductEntity?> update(ProductEntity product);
        public Task delete(ProductEntity product);
    }
}
