using Monefy.Entities;
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
        [ForeignKey("Wallet")] public int Id_Wallet { get; set; }
        public Wallet? Wallet { get; set; }
        public float Amount { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Category")] public int Id_Category { get; set; }
        public Category? Category { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

    }
}
