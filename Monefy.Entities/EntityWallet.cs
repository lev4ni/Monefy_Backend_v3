
using System.ComponentModel.DataAnnotations;

namespace Monefy.Entities
{
    public class EntityWallet
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        public string? Name { get; set; }
        public EntityUser User { get; set; } = new EntityUser();
        public EntityCurrency Currency { get; set; } = new EntityCurrency();
        [Range(0, 99999.99)]  public decimal TotalIncome { get; set; }
        [Range(0, 99999.99)]  public decimal TotalExpense { get; set; }
        [Range(0, 99999.99)]  public decimal TotalBalance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
