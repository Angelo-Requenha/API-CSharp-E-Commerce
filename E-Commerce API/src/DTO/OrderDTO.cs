using E_Commerce_API.src.Models;

namespace E_Commerce_API.src.DTO
{
    public class OrderDTO
    {
        public List<int> ProductsId { get; set; } = new();
        public int UserId { get; set; }
    }
}
