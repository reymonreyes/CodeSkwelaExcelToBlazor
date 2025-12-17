namespace WeeklyTimesheet.Core.Entities
{
    public class Timesheet
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public IList<TimesheetLog> Logs { get; set; } = new List<TimesheetLog>();
    }

    public class TimesheetLog
    {
        public int Id { get; set; }
        public int TimesheetId { get; set; }
        public DateTime DayOfWeek { get; set; }
        public DateTime TimeIn { get; set; }
        public int BreakMinutes { get; set; }
        public DateTime TimeOut { get; set; }
        public int Total
        {
            get
            {
                var timeDiff = TimeOut - TimeIn;
                return (int)timeDiff.TotalMinutes - BreakMinutes;
            }
        }
        public int OvertimeMinutes { get; set; }
        public int SickMinutes { get; set; }
        public int HolidayMinutes { get; set; }
        public int VacationMinutes { get; set; }
    }
}
