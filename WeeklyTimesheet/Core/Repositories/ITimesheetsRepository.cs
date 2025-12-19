using WeeklyTimesheet.Core.Entities;

namespace WeeklyTimesheet.Core.Repositories
{
    public interface ITimesheetsRepository
    {
        int Create(Timesheet timesheet);
        Timesheet Get(int id);
        PagedResult<Timesheet> GetAll(int page = 1, int size = 10);
        PagedResult<Timesheet> GetAllByEmployeeIdAndStartDate(int? employeeId, DateTime? startDateUtc, int page = 1, int size = 10);
        Timesheet GetByEmployeeAndStartDate(int employeeId, DateTime startDate);
        void Update(Timesheet timesheet);
    }
}
