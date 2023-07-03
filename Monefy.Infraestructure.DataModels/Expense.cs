using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Monefy.Entities;

namespace Monefy.Infraestructure.DataModels
{
    [Table("Expense")]
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        [ForeignKey("Wallet")] public int Id_Wallet { get; set; }
        public Wallet? Wallet { get; set; }
        public float Amount { get; set; }
        public float TotalAmount { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Category")] public int Id_Category { get; set; }
        public Category? Category { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
