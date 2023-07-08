using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Monefy.Infraestructure.DataModels
{
	[Table("Income")]
	public class Income
	{
		[Key]
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
