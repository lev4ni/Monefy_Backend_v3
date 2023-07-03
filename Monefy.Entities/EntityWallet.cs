
namespace Monefy.Entities
{
    public class EntityWallet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //public EntityUser? User { get; set; }
       //public EntityCurrency? Currency { get; set; }
        public float TotalIncome { get; set; }
        public float TotalExpent { get; set; }
        public float TotalBalance { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
