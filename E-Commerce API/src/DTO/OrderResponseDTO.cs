using E_Commerce_API.src.Models;

namespace E_Commerce_API.src.DTO
{
    public class OrderResponseDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}
