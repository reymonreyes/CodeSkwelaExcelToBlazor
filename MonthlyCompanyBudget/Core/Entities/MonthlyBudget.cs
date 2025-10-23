namespace MonthlyCompanyBudget.Core.Entities
{
    public class MonthlyBudget
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<MonthlyBudgetItem> Items { get; set; }
    }

    public class MonthlyBudgetItem
    {
        public int Id { get; set; }
        public int MonthlyBudgetId { get; set; }
        public int BudgetItemTypeId { get; set; }
        public decimal EstimatedValue { get; set; }
        public decimal ActualValue { get; set; }
    }
}
