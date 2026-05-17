namespace E_Commerce_API.src.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new();
        public required int UserId { get; set; }
        public User User { get; set; } = null;
    }
}
