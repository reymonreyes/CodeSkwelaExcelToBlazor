namespace WeeklyTimesheet.ViewModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee? Manager { get; set; }
    }
}
