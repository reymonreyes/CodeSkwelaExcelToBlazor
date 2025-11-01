using MonthlyCompanyBudget.Core.Enums;

namespace MonthlyCompanyBudget.Core.Entities
{
    public class BudgetItemType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BudgetItemTypeCategory Category { get; set; }
    }
}
