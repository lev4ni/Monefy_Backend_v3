

namespace Monefy.Application.DTOs
{
    public class WalletDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpent { get; set; }
        public decimal TotalBalance { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
