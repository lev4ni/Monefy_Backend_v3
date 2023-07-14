
namespace Monefy.Entities
{
    public class EntityCategoryWithExpenses
    {
        public EntityCategory Category { get; set; }
        public IEnumerable<EntityExpense> Expenses { get; set; }
        public decimal TotalAmount { get; set; } 
    }
}
