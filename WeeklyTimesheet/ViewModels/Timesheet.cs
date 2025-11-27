namespace WeeklyTimesheet.ViewModels
{
    public class Timesheet
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public DateTime WeekStart { get; set; }
        public int TotalHours { get; set; }
    }
}
