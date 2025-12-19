namespace WeeklyTimesheet.Core.Entities
{
    public class Timesheet
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public IList<TimesheetLog> Logs { get; set; } = new List<TimesheetLog>();
        public decimal RegularRate { get; set; }
        public decimal OvertimeRate { get; set; }
        public decimal SickLeaveRate { get; set; }
        public decimal HolidayLeaveRate { get; set; }
        public decimal VacationLeaveRate { get; set; }
    }

    public class TimesheetLog
    {
        public int Id { get; set; }
        public int TimesheetId { get; set; }
        public DateTime DayOfWeek { get; set; }
        public DateTime? TimeIn { get; set; }
        public int BreakMinutes { get; set; }
        public DateTime? TimeOut { get; set; }
        public int TotalWorkHours
        {
            get
            {
                if(TimeIn == null || TimeOut == null) return 0;

                return RegularHours - BreakMinutes;                
            }
        }
        public int RegularHours
        {
            get
            {
                if (TimeIn == null || TimeOut == null) return 0;

                var timeDiff = TimeOut.Value - TimeIn.Value;
                return (int)timeDiff.TotalMinutes;
            }
        }
        public int OvertimeMinutes { get; set; }
        public int SickMinutes { get; set; }
        public int HolidayMinutes { get; set; }
        public int VacationMinutes { get; set; }        
    }
}
