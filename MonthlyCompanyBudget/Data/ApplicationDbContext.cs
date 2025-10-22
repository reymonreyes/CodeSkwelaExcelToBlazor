using Microsoft.EntityFrameworkCore;
using MonthlyCompanyBudget.Core.Entities;
using MonthlyCompanyBudget.Core.Enums;

namespace MonthlyCompanyBudget.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string _dbPath;
        public DbSet<BudgetItemType> BudgetItemTypes { get; set; }

        public ApplicationDbContext()
        {
            _dbPath = Path.Join(Environment.CurrentDirectory, "Data\\application.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}")
            .UseSeeding((context, _) =>
            {
                if (!context.Set<BudgetItemType>().Any())
                {
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Net sales", Category = BudgetItemTypeCategory.Income });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Interest income", Category = BudgetItemTypeCategory.Income });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Asset sales(gain/ loss)", Category = BudgetItemTypeCategory.Income });

                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Wages", Category = BudgetItemTypeCategory.PersonnelExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Employee benefits", Category = BudgetItemTypeCategory.PersonnelExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Commission", Category = BudgetItemTypeCategory.PersonnelExpenses });

                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Advertising", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Bad debts", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Cash discounts", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Delivery costs", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Depreciation", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Dues and subscriptions", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Insurance", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Interest", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Legal and auditing", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Maintenance and repairs", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Office supplies", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Postage", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Rent or mortgage", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Sales expenses", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Shipping and storage", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Supplies", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Taxes", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Telephone", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Utilities", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Other", Category = BudgetItemTypeCategory.OperatingExpenses });

                    context.SaveChanges();
                }
            }).UseAsyncSeeding(async(context, _, cancellationToken) =>
            {
                if (!context.Set<BudgetItemType>().AnyAsync().Result)
                {
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Net sales", Category = BudgetItemTypeCategory.Income });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Interest income", Category = BudgetItemTypeCategory.Income });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Asset sales(gain/ loss)", Category = BudgetItemTypeCategory.Income });

                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Wages", Category = BudgetItemTypeCategory.PersonnelExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Employee benefits", Category = BudgetItemTypeCategory.PersonnelExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Commission", Category = BudgetItemTypeCategory.PersonnelExpenses });

                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Advertising", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Bad debts", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Cash discounts", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Delivery costs", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Depreciation", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Dues and subscriptions", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Insurance", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Interest", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Legal and auditing", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Maintenance and repairs", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Office supplies", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Postage", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Rent or mortgage", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Sales expenses", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Shipping and storage", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Supplies", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Taxes", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Telephone", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Utilities", Category = BudgetItemTypeCategory.OperatingExpenses });
                    context.Set<BudgetItemType>().Add(new BudgetItemType { Name = "Other", Category = BudgetItemTypeCategory.OperatingExpenses });

                    await context.SaveChangesAsync(cancellationToken);
                }
            });
        }
    }
}
