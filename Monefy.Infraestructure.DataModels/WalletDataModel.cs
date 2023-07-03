using Monefy.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monefy.Infraestructure.DataModels
{
    [Table("Wallet")]
    public class WalletDataModel
    {
        [Key]
        public int Id_Wallet { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        [ForeignKey("Users")] public int Id_User { get; set; }
        public User? User { get; set; }
        public float? TotalExpense { get; set; }
        public float? TotalInCome { get; set;}
        public float? TotalBalance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
