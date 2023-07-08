
using Monefy.Infraestructure.DataModels;

namespace Monefy.Application.DTOs
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
       // public int CategoryId { get; set; }
        public Category? Category { get;set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime CreationAt { get; set; }
        public int WalletId { get; set; }
    }
}
