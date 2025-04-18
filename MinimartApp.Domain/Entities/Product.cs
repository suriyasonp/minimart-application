using System.ComponentModel.DataAnnotations;

namespace MinimartApp.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; } = 0.0m;
        public string Category { get; set; } = null!;
    }
}
