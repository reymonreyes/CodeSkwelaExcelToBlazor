using static MudBlazor.Colors;

namespace WeeklyTimesheet.ViewModels
{
    public class Timesheet
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public DateTime WeekStart { get; set; }
        public int TotalHours { get; set; }
        public IList<TimesheetLog> Logs { get; set; }
        public int TotalWorkHours
        {
            get
            {
                var regularHours = (int)Logs.Select(x => x.WorkHours?.TotalMinutes).Sum();
                return regularHours;
            }
        }
        public string TotalWorkHoursFormatted
        {
            get
            {
                return GetHourMinuteFormat(TotalWorkHours);
            }
        }
        public int TotalRegularHours
        {
            get
            {
                var regularHours = (int)Logs.Select(x => x.RegularHours?.TotalMinutes).Sum();
                return regularHours;
            }
        }
        public string TotalRegularHoursFormatted
        {
            get
            {
                return GetHourMinuteFormat(TotalRegularHours);
            }
        }
        public int TotalOvertimeHours
        {
            get
            {
                var totalMinutes = Logs.Select(x => x.OvertimeMinutes).Sum();
                return totalMinutes;
            }
        }
        public string TotalOvertimeHoursFormatted
        {
            get
            {
                return GetHourMinuteFormat(TotalOvertimeHours);
            }
        }
        public int TotalSickHours
        {
            get
            {
                var totalMinutes = Logs.Select(x => x.SickMinutes).Sum();
                return totalMinutes;
            }
        }
        public string TotalSickHoursFormatted
        {
            get
            {
                return GetHourMinuteFormat(TotalSickHours);
            }
        }
        public int TotalHolidayHours
        {
            get
            {
                var totalMinutes = Logs.Select(x => x.HolidayMinutes).Sum();
                return totalMinutes;
            }
        }
        public string TotalHolidayHoursFormatted
        {
            get
            {
                return GetHourMinuteFormat(TotalHolidayHours);
            }
        }
        public int TotalVacationHours
        {
            get
            {
                var totalMinutes = Logs.Select(x => x.VacationMinutes).Sum();
                return totalMinutes;
            }
        }
        public string TotalVacationHoursFormatted
        {
            get
            {
                return GetHourMinuteFormat(TotalVacationHours);
            }
        }
        public decimal RegularRate { get; set; }
        public decimal OvertimeRate { get { return 1.5M * RegularRate; } }
        public decimal SickLeaveRate { get; set; }
        public decimal HolidayLeaveRate { get; set; }
        public decimal VacationLeaveRate { get; set; }
        public decimal TotalRegularPay
        {
            get
            {
                return RegularRate * ((decimal)TotalWorkHours / 60);
            }
        }
        public decimal TotalOvertimePay
        {
            get
            {
                return OvertimeRate * ((decimal)TotalOvertimeHours / 60);
            }
        }
        public decimal TotalSickLeavePay
        {
            get
            {
                return SickLeaveRate * ((decimal)TotalSickHours / 60);
            }
        }
        public decimal TotalHolidayPay
        {
            get
            {
                return HolidayLeaveRate * ((decimal)TotalHolidayHours / 60);
            }
        }
        public decimal TotalVacationPay
        {
            get
            {
                return VacationLeaveRate * ((decimal)TotalVacationHours / 60);
            }
        }

        public decimal GrandTotalPay
        {
            get
            {
                return TotalRegularPay + TotalOvertimePay + TotalSickLeavePay + TotalHolidayPay + TotalVacationPay;
            }
        }

        private string? GetHourMinuteFormat(int totalMinutes)
        {
            int hour = 0, minutes = 0;
            if (totalMinutes >= 59)
                hour = totalMinutes / 60;

            minutes = totalMinutes % 60;

            return $"{hour}:{minutes.ToString("D2")}";
        }
    }

    public class TimesheetLog
    {
        private int _overtimeMinutes;
        private int _sickMinutes;
        private int _holidayMinutes;
        private int _vacationMinutes;

        public int Id { get; set; }
        public int TimesheetId { get; set; }
        public DateTime DayOfWeek { get; set; }
        public TimeSpan? TimeIn { get; set; }
        public TimeSpan? TimeOut { get; set; }
        public int BreakMinutes { get; set; }
        public TimeSpan? WorkHours{
            get
            {
                if(RegularHours.HasValue)
                    return RegularHours - new TimeSpan(0, BreakMinutes, 0);

                return null;
            }
        }

        public TimeSpan? RegularHours
        {
            get 
            {
                return TimeOut - TimeIn;                
            }
        }

        public string? OvertimeMinutesFormatted
        {
            get
            {
                return GetHourMinuteFormat(OvertimeMinutes);
            }

            set
            {                
                OvertimeMinutes = GetTotalLeaveMinutes(value);
            }
        }

        public int OvertimeMinutes { get; set; }
        public string? SickMinutesFormatted
        {
            get
            {
                return GetHourMinuteFormat(SickMinutes);
            }

            set
            {
                SickMinutes = GetTotalLeaveMinutes(value);
            }
        }
        public int SickMinutes { get; set; }
        public string? HolidayMinutesFormatted
        {
            get
            {
                return GetHourMinuteFormat(HolidayMinutes);
            }

            set
            {
                HolidayMinutes = GetTotalLeaveMinutes(value);
            }
        }
        public int HolidayMinutes { get; set; }
        public string? VacationMinutesFormatted
        {
            get
            {
                return GetHourMinuteFormat(VacationMinutes);
            }

            set
            {
                VacationMinutes = GetTotalLeaveMinutes(value);
            }
        }
        public int VacationMinutes { get; set; }

        private string? GetHourMinuteFormat(int totalMinutes)
        {
            int hour = 0, minutes = 0;
            if (totalMinutes >= 59)
                hour = totalMinutes / 60;

            minutes = totalMinutes % 60;

            if(hour > 0 || minutes > 0) return $"{hour}:{minutes.ToString("D2")}";

            return "";
        }

        private int GetTotalLeaveMinutes(string? formattedValue)
        {
            if (string.IsNullOrWhiteSpace(formattedValue))
                return 0;

            int hours = 0, minutes = 0;
            var valueSplit = formattedValue.Split(':');
            if (valueSplit.Length < 2) return 0;
            if (!int.TryParse(valueSplit[0], out hours) || !int.TryParse(valueSplit[1], out minutes)) return 0;

            return (hours * 60) + minutes;
        }
    }
}
