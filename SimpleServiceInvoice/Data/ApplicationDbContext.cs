using Microsoft.EntityFrameworkCore;
using SimpleServiceInvoice.Models;

namespace SimpleServiceInvoice.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string DbPath;
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext()
        {
            var folder = Environment.CurrentDirectory;
            DbPath = System.IO.Path.Join(folder, "Data\\application.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
