

using Monefy.Infraestructure.DataModels;

namespace Monefy.Application.DTOs
{
    public class IncomeDTO
    {
        public int Id { get; set; }
        public Category? Category { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreation { get; set; }
        public int WalletId { get; set; }
    }

}
