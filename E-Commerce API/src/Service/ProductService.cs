using E_Commerce_API.src.Models;
using E_Commerce_API.src.Repositories;

namespace E_Commerce_API.src.Service
{
    public class ProductService
    {
        private readonly Repository<Product> _repository;

        public ProductService(Repository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _repository.GetAll();
        }

        public async Task<Product> GetProductById(int id)
        {
            Product product = await _repository.GetById(id);
            return product;
        }

        public async Task<Product> CreatedProduct(Product product)
        {
            await _repository.Create(product);
            return product;
        }

        public async Task<bool> DeleteUserById(int id)
        {
            Product product = new Product();
            product = await GetProductById(id);

            if (product == null)
            {
                return false;
            }

            await _repository.Delete(product);
            return true;
        }
    }
}
