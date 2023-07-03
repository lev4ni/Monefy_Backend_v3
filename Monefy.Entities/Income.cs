

namespace Monefy.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public Category? Category { get; set; }
        public float Amount { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreation { get; set; }
        public Wallet? Wallet { get; set; }
    }
}
