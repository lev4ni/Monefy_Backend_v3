
using System.ComponentModel.DataAnnotations;

namespace Monefy.Entities
{
    public class EntityCurrency
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(20)]
        public string? CurrencyName { get; set; }
        public bool IsCrypto { get; set; }
    }
}
