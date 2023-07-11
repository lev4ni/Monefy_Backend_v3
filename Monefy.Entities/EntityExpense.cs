
using System.ComponentModel.DataAnnotations;

namespace Monefy.Entities
{
    public class EntityExpense
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public EntityCategory? Category { get; set; }
        [Range(0, 99999.99)]
        public float Amount { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }
        public DateTime DateCreation { get; set; }
        public EntityWallet? Wallet { get; set; }
    }
}
