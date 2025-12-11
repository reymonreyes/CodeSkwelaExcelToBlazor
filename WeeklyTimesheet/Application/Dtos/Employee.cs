namespace WeeklyTimesheet.Application.Dtos
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Manager { get; set; }
    }
}
