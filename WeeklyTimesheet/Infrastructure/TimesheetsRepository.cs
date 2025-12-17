using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WeeklyTimesheet.Core.Entities;
using WeeklyTimesheet.Core.Repositories;

namespace WeeklyTimesheet.Infrastructure
{
    public class TimesheetsRepository : ITimesheetsRepository
    {        
        public int Create(Timesheet timesheet)
        {
            var saveResult = 0;

            if(timesheet == null) throw new ArgumentNullException(nameof(timesheet));

            using (var context = new ApplicationDbContext())
            {
                context.Add(timesheet);
                saveResult = context.SaveChanges();
            }

            return timesheet.Id;
        }

        public Timesheet GetByEmployeeAndStartDate(int employeeId, DateTime startDate)
        {
            Timesheet result = null;

            using (var context = new ApplicationDbContext())
            {
                var employee = context.Employees.FirstOrDefault(x => x.Id == employeeId);
                if (employee == null)
                    return result;

                result = context.Timesheets.FirstOrDefault(x => x.EmployeeId == employeeId && x.StartDate == startDate);
                if(result == null)
                {
                    var timelog = context.Timesheets.Where(x => x.EmployeeId == employeeId).SelectMany(x => x.Logs).FirstOrDefault(x => x.DayOfWeek == startDate);
                     if(timelog != null)
                    {
                        result = context.Timesheets.FirstOrDefault(x => x.Id == timelog.TimesheetId);
                    }
                }
            }

            return result;
        }

        public PagedResult<Timesheet> GetAll(int page = 1, int size = 10)
        {
            page = page < 0 ? 0 : page - 1;
            size = size < 0 ? 10 : size;
            var result = new PagedResult<Timesheet>();
            var timesheets = new List<Timesheet>();
            var totalRecords = 0;

            using (var context = new ApplicationDbContext())
            {
                timesheets = context.Timesheets.Include(x => x.Employee).Skip(page * size).Take(size).ToList();
                totalRecords = context.Timesheets.Count();
                result.Data = timesheets;
                result.TotalRecords = totalRecords;
            }

            return result;
        }

        public PagedResult<Timesheet> GetByEmployeeId(int employeeId, int page = 1, int size = 10)
        {
            page = page < 0 ? 0 : page - 1;
            size = size < 0 ? 10 : size;
            var result = new PagedResult<Timesheet>();
            var timesheets = new List<Timesheet>();
            var totalRecords = 0;

            using (var context = new ApplicationDbContext())
            {
                timesheets = context.Timesheets.Include(x => x.Employee).Where(x => x.EmployeeId == employeeId).Skip(page * size).Take(size).ToList();
                totalRecords = context.Timesheets.Where(x => x.EmployeeId == employeeId).Count();
                result.Data = timesheets;
                result.TotalRecords = totalRecords;
            }

            return result;
        }

        public PagedResult<Timesheet> GetByStartDate(DateTime startDateUtc, int page = 1, int size = 10)
        {
            page = page < 0 ? 0 : page - 1;
            size = size < 0 ? 10 : size;
            var timesheets = new List<Timesheet>();
            var totalRecords = 0;
            var result = new PagedResult<Timesheet>();
            result.Data = timesheets;
            result.TotalRecords = totalRecords;

            using (var context = new ApplicationDbContext())
            {
                timesheets = context.Timesheets.Include(x => x.Employee).Where(x => x.StartDate == startDateUtc).Skip(page * size).Take(size).ToList();
                totalRecords = context.Timesheets.Where(x => x.StartDate == startDateUtc).Count();
                result.Data = timesheets;
                result.TotalRecords = totalRecords;
            }

            return result;
        }

        PagedResult<Timesheet> ITimesheetsRepository.GetAllByEmployeeIdAndStartDate(int? employeeId, DateTime? startDateUtc, int page, int size)
        {
            page = page < 0 ? 0 : page - 1;
            size = size < 0 ? 10 : size;
            var timesheets = new List<Timesheet>();
            var totalRecords = 0;
            var result = new PagedResult<Timesheet>();
            result.Data = timesheets;
            result.TotalRecords = totalRecords;

            using (var context = new ApplicationDbContext())
            {
                var query = context.Timesheets.Include(x => x.Employee).ThenInclude(x => x.Manager).AsQueryable();//.Where(x => x.EmployeeId == employeeId && x.StartDate == startDateUtc).Skip(page * size).Take(size).ToList();
                
                if(employeeId.HasValue)
                    query = query.Where(x => x.EmployeeId == employeeId.Value);
                if(startDateUtc.HasValue)
                    query = query.Where(x => x.StartDate == startDateUtc.Value);
                
                timesheets = query.Skip(page*size).Take(size).ToList();
                totalRecords = query.Count();//context.Timesheets.Where(x => x.EmployeeId == employeeId && x.StartDate == startDateUtc).Count();
                result.Data = timesheets;
                result.TotalRecords = totalRecords;
            }

            return result;
        }
    }
}
