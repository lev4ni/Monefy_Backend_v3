using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Monefy.Entities;

namespace Monefy.Infraestructure.DataModels
{
    [Table("Expense")]
    public class Expense
    {
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		public Guid Guid { get; set; } = Guid.NewGuid();

		[ForeignKey("Wallet")]
		public int WalletId { get; set; }
		public Wallet Wallet { get; set; } = new Wallet();
		public decimal Amount { get; set; }
		public string? Description { get; set; }
		[ForeignKey("Category")]
		public int CategoryId { get; set; }
		public Category Category { get; set; } = new Category();
		public DateTime? CreatedAt { get; set; } = DateTime.Now;
	}
}
