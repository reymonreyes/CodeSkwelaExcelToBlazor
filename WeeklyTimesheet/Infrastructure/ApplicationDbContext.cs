using Microsoft.EntityFrameworkCore;
using WeeklyTimesheet.Core.Entities;

namespace WeeklyTimesheet.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        private string DbPath;
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<TimesheetLog> TimesheetLogs { get; set; }
        public ApplicationDbContext()
        {
            var folder = Environment.CurrentDirectory;
            DbPath = System.IO.Path.Join(folder, "Data\\application.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}")
                .UseSeeding((context, _) =>
                {
                    var appContext = (ApplicationDbContext) context;

                    //only seed when there's no data yet
                    if (!appContext.Employees.Any())
                    {
                        var manager = new Employee { Name = "John Doe" };
                        var manager2 = new Employee { Name = "Alpha Bravo" };
                        context.Set<Employee>().Add(manager);
                        context.Set<Employee>().Add(manager2);
                        context.Set<Employee>().Add(new Employee { Id = 3, Name = "Bravo Charlie", Manager = manager });
                        context.Set<Employee>().Add(new Employee { Id = 4, Name = "Charlie Delta", Manager = manager2 });
                        context.Set<Employee>().Add(new Employee { Id = 5, Name = "Delta Echo", Manager = manager });
                        context.Set<Employee>().Add(new Employee { Id = 6, Name = "Echo Foxtrot", Manager = manager });
                        context.Set<Employee>().Add(new Employee { Id = 7, Name = "Foxtrot Golf", Manager = manager2 });
                        context.Set<Employee>().Add(new Employee { Id = 8, Name = "Golf Hotel", Manager = manager });
                        context.Set<Employee>().Add(new Employee { Id = 9, Name = "Hotel India", Manager = manager2 });
                        context.Set<Employee>().Add(new Employee { Id = 10, Name = "India Julliett", Manager = manager });
                        context.Set<Employee>().Add(new Employee { Id = 11, Name = "Julliett Kilo", Manager = manager });
                        context.Set<Employee>().Add(new Employee { Id = 12, Name = "Kilo Lima", Manager = manager2 });
                        context.Set<Employee>().Add(new Employee { Id = 13, Name = "Lima Mike", Manager = manager2 });
                        context.Set<Employee>().Add(new Employee { Id = 14, Name = "Mike November", Manager = manager });
                        context.Set<Employee>().Add(new Employee { Id = 15, Name = "November Oscar", Manager = manager });
                        context.SaveChanges();
                    }
                });
        }
    }
}
