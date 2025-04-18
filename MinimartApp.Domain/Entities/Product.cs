using System.ComponentModel.DataAnnotations;

namespace MinimartApp.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
    }
}
