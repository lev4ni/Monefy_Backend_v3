
namespace Monefy.Entities
{
    public class EntityExpense
    {
        public int Id { get; set; }
       // public EntityCategory? Category { get; set; }
        public float Amount { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreation { get; set; }
        //public EntityWallet? Wallet { get; set; }
    }
}
