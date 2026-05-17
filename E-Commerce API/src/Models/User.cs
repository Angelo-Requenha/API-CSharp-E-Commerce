namespace E_Commerce_API.src.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; } = new();
        public string Password {  get; set; }
    }
}
