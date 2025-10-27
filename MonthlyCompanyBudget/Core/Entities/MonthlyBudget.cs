namespace MonthlyCompanyBudget.Core.Entities
{
    public class MonthlyBudget
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<MonthlyBudgetItem> Items { get; set; } = new List<MonthlyBudgetItem>();
    }

    public class MonthlyBudgetItem
    {
        public int Id { get; set; }
        public int MonthlyBudgetId { get; set; }
        public int BudgetItemTypeId { get; set; }
        public BudgetItemType BudgetItemType { get; set; }
        public decimal EstimatedValue { get; set; }
        public decimal ActualValue { get; set; }
        public decimal Difference
        {
            get
            {
                return ActualValue - EstimatedValue;
            }
        }

        public decimal Top5Amount 
        {
            get
            {
                return ActualValue + (decimal)(Math.Pow(10, -6) * Id);
            }
        }
    }
}
