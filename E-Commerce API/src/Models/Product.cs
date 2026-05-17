using System.Text.Json.Serialization;

namespace E_Commerce_API.src.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public decimal Price { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
