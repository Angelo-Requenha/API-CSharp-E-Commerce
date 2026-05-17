using E_Commerce_API.src.DTO;
using E_Commerce_API.src.Models;
using E_Commerce_API.src.Repositories;

namespace E_Commerce_API.src.Service
{
    public class OrderService
    {
        private readonly Repository<Order> _repository;
        public readonly ProductService _productService;

        public OrderService(Repository<Order> repository, ProductService productService)
        {
            _repository = repository;
            _productService = productService;
        }

        public async Task<List<Order>> GetAllOrders() 
        {
            return await _repository.GetAll();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Order> CreatedOrder(List<int> productsId, int userId)
        {
            List<Product> products = new List<Product>();

            for (int i=0; i<productsId.Count; i++)
            {
                products.Add(await _productService.GetProductById(productsId[i]));
            }
            Order order = new Order
            {
                UserId = userId,
                Products = products
            };
            await _repository.Create(order);
            return order;
        }

        public async Task<bool> DeleteOrderById(int id)
        {
            Order order = await _repository.GetById(id);

            if (order == null)
            {
                return false;
            }

            await _repository.Delete(order);
            return true;
        }
    }
}
