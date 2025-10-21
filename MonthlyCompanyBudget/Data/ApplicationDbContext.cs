using Microsoft.EntityFrameworkCore;
using MonthlyCompanyBudget.Core.Entities;

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
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        }
    }
}
