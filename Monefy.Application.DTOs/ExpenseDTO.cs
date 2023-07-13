
namespace Monefy.Application.DTOs
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
        public int CategoryId { get;set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int WalletId { get; set; }
    }
}
