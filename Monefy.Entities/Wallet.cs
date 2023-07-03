
namespace Monefy.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public User? User { get; set; }
        public Currency? Currency { get; set; }
        public float TotalIncome { get; set; }
        public float TotalExpent { get; set; }
        public float TotalBalance { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
