using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monefy.Infraestructure.DataModels
{
    [Table("Wallet")]
    public class Wallet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; } = new User();
        public decimal? TotalExpense { get; set; }
        public decimal? TotalIncome { get; set; }
        public decimal? TotalBalance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
