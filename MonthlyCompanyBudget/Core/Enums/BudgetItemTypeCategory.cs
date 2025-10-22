using System.ComponentModel;

namespace MonthlyCompanyBudget.Core.Enums
{
    public enum BudgetItemTypeCategory
    {
        [Description("Income")]
        Income = 1,
        [Description("Personnel Expense")]
        PersonnelExpenses = 2,
        [Description("Operating Expenses")]
        OperatingExpenses = 3
    }
}
