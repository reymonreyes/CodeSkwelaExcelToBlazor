using WeeklyTimesheet.Core.Entities;
using WeeklyTimesheet.Core.Repositories;
using WeeklyTimesheet.Shared;

namespace WeeklyTimesheet.UseCases
{
    public class CreateTimesheet
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly ITimesheetsRepository _timesheetsRepository;
        
        public CreateTimesheet(IEmployeesRepository employeesRepository, ITimesheetsRepository timesheetsRepository)
        {
            _employeesRepository = employeesRepository;
            _timesheetsRepository = timesheetsRepository;
        }
        public ActionResult<int> Save(int employeeId, DateTime startDate)
        {
            var result = new ActionResult<int>();
            //validations
            //employee must exist
            //startDate must not be any of the existing timesheets
            //maybe startDate must be greater than the previous one?
            var employee = _employeesRepository.Get(employeeId);
            if (employee == null) result.Errors.Add("Employee not found");

            var existingTimesheet = _timesheetsRepository.GetByEmployeeAndStartDate(employeeId, startDate);
            if (existingTimesheet != null) result.Errors.Add("Start Date already exist");            

            if(result.Errors.Count == 0)
            {
                var newTimesheet = new Timesheet { EmployeeId = employeeId, StartDate = startDate.ToUniversalTime() };
                var endDate = startDate.AddDays(14);
                var logToAdd = startDate;

                while (logToAdd < endDate)
                {
                    newTimesheet.Logs.Add(new TimesheetLog { DayOfWeek = logToAdd });
                    logToAdd = logToAdd.AddDays(1);
                }

                result.Result = _timesheetsRepository.Create(newTimesheet);
            }

            return result;
        }
    }
}
