using System.ComponentModel.DataAnnotations;

namespace MinimartApp.Domain.Entities
{
    public class Inventory
    {
        [Key]
        public Guid InventoryId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
        // Navigation property
        public virtual Product Product { get; set; } = null!;
    }
}
