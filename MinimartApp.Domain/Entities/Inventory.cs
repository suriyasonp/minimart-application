using System.ComponentModel.DataAnnotations;

namespace MinimartApp.Domain.Entities
{
    public class Inventory
    {
        [Key]
        public Guid InventoryId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTimeOffset? UpdatedAt { get; set; }

        // Navigation property
        public virtual Product Product { get; set; } = null!;
    }
}
