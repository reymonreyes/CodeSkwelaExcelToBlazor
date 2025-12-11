using WeeklyTimesheet.Core.Entities;

namespace WeeklyTimesheet.Core.Repositories
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> GetAll(int page = 1, int size = 10);
        Employee Get(int id);
        PagedResult<Employee> FindByName(string name, int page = 1, int size = 10);
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
