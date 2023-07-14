
namespace Monefy.Application.DTOs
{
    public class ExpensesCategoryDTO
    {
        public int Id { get; set; }
        public CategoryDTO Category { get; set; } = new CategoryDTO();
        public decimal TotalAmount { get; set; }
        public IEnumerable<ExpenseDTO> Expenses { get; set; } 

    }
}
