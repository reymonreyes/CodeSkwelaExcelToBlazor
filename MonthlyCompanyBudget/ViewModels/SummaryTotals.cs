using MonthlyCompanyBudget.Core.Entities;

namespace MonthlyCompanyBudget.ViewModels
{
    public class SummaryTotals
    {
        public SummaryTotals()
        {            
        }
        public SummaryTotals(List<MonthlyBudgetItem> monthlyBudgetItems)
        {
            IncomeEstimatedTotal = monthlyBudgetItems.Where(x => x.BudgetItemType.Category == Core.Enums.BudgetItemTypeCategory.Income).Sum(x => x.EstimatedValue);
            PersonnelExpensesEstimatedTotal = monthlyBudgetItems.Where(x => x.BudgetItemType.Category == Core.Enums.BudgetItemTypeCategory.PersonnelExpenses).Sum(x => x.EstimatedValue);
            OperatingExpensesEstimatedTotal = monthlyBudgetItems.Where(x => x.BudgetItemType.Category == Core.Enums.BudgetItemTypeCategory.OperatingExpenses).Sum(x => x.EstimatedValue);
            IncomeActualTotal = monthlyBudgetItems.Where(x => x.BudgetItemType.Category == Core.Enums.BudgetItemTypeCategory.Income).Sum(x => x.ActualValue);
            PersonnelExpensesActualTotal = monthlyBudgetItems.Where(x => x.BudgetItemType.Category == Core.Enums.BudgetItemTypeCategory.PersonnelExpenses).Sum(x => x.ActualValue);
            OperatingExpensesActualTotal = monthlyBudgetItems.Where(x => x.BudgetItemType.Category == Core.Enums.BudgetItemTypeCategory.OperatingExpenses).Sum(x => x.ActualValue);
        }
        public decimal IncomeEstimatedTotal { get; set; }
        public decimal PersonnelExpensesEstimatedTotal { get; set; }
        public decimal OperatingExpensesEstimatedTotal { get; set; }
        public decimal IncomeActualTotal { get; set; }
        public decimal PersonnelExpensesActualTotal { get; set; }
        public decimal OperatingExpensesActualTotal { get; set; }

        public decimal ExpensesEstimatedTotal
        {
            get
            {
                return PersonnelExpensesEstimatedTotal + OperatingExpensesEstimatedTotal;
            }
        }

        public decimal ExpensesActualTotal
        {
            get
            {
                return PersonnelExpensesActualTotal + OperatingExpensesActualTotal;
            }
        }

        public decimal IncomeDifference
        {
            get
            {
                return IncomeActualTotal - IncomeEstimatedTotal;
            }
        }

        public decimal ExpensesDifference
        {
            get
            {
                return ExpensesEstimatedTotal - ExpensesActualTotal;
            }
        }

        public decimal EstimatedBalance
        {
            get
            {
                return IncomeEstimatedTotal - ExpensesEstimatedTotal;
            }
        }

        public decimal ActualBalance
        {
            get
            {
                return IncomeActualTotal - ExpensesActualTotal;
            }
        }

        public decimal BalanceDifference
        {
            get
            {
                return ActualBalance - EstimatedBalance;
            }
        }
    }
}
