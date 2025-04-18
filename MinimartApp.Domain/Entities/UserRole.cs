using System.ComponentModel.DataAnnotations;

namespace MinimartApp.Domain.Entities
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public RoleType RoleId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //Navigation properties
        public virtual User User { get; set; } = null!;
    }
}
