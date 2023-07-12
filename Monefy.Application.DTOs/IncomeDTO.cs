
namespace Monefy.Application.DTOs
{
    public class IncomeDTO
    {
        public int Id { get; set; }
        public CategoryDTO? Category { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int WalletId { get; set; }
    }

}
