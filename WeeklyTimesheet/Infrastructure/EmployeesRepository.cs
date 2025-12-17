using Microsoft.EntityFrameworkCore;
using WeeklyTimesheet.Core.Entities;
using WeeklyTimesheet.Core.Repositories;

namespace WeeklyTimesheet.Infrastructure
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public void Create(Employee employee)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public void Delete(Employee employee)
        {
            throw new NotImplementedException();
        }

        public PagedResult<Employee> FindByName(string name, int page = 1, int size = 10)
        {
            page = page < 0 ? 0 : page - 1;
            size = size < 0 ? 10 : size;
            var result = new PagedResult<Employee>();
            var employees = new List<Employee>();
            var totalRecords = 0;

            using (var context = new ApplicationDbContext())
            {
                employees = context.Employees.Include(x => x.Manager).Where(x => EF.Functions.Like(x.Name, $"%{name.ToLower()}%")).Skip(page*size).Take(size).ToList();
                totalRecords = context.Employees.Where(x => EF.Functions.Like(x.Name, $"%{name.ToLower()}%")).Count();
                result.Data = employees;
                result.TotalRecords = totalRecords;
            }

            return result;
        }

        public Employee Get(int id)
        {
            Employee result = null;
            using (var context = new ApplicationDbContext())
            {
                result = context.Employees.Find(id);
            }

            return result;
        }

        public IEnumerable<Employee> GetAll(int page = 1, int size = 10)
        {
            page = page < 0 ? 0 : page - 1;
            size = size < 0 ? 10 : size;

            var result = new List<Employee>();

            using (var context = new ApplicationDbContext())
            {
                result = context.Employees.Skip(page).Take(size).ToList();
            }
            
            return result;
        }

        public void Update(Employee employee)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Employees.Update(employee);
                context.SaveChanges();
            }
        }        
    }
}
