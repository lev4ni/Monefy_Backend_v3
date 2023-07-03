
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monefy.Infraestructure.DataModels
{
    [Table("Currency")]
    public class CurrencyDataModel
    {
        [Key]
        public int Id_Currency { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string? CurrencyName { get; set; }
        public bool IsCrypto { get; set; }
    }
}