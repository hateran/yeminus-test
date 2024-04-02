using api.Controllers.Product.Dtos;
using api.Database.Entities.Product;

namespace api.Controllers.Product.Services
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<ProductEntity?> getById(int id)
        {
            ProductEntity? product = await productRepository.GetById(id);
            return product;
        }

        public async Task<List<ProductEntity>> ListAll()
        {
            List<ProductEntity> products = await productRepository.listAll();
            return products;
        }

        public async Task<ProductEntity?> create(CreateProductDto product)
        {
            ProductEntity? productEntity = await productRepository.create(product);
            return productEntity;
        }

        public async Task<ProductEntity?> update(int id, CreateProductDto body)
        {
            ProductEntity? product = await getById(id);
            if (product == null) { return product; }
            product.Name = body.Name;
            product.Price = body.Price;
            ProductEntity? productEntity = await productRepository.update(product);
            return productEntity;
        }

        public async Task<Boolean> delete(int id)
        {
            ProductEntity? product = await getById(id);
            if (product == null) { return false; }
            await productRepository.delete(product);
            return true;
        }
    }
}
