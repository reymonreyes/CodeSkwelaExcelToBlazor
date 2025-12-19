namespace WeeklyTimesheet.Shared
{
    public class ActionResult<T>  where T : struct
    {
        public T Result { get; set; }
        public IList<string> Errors { get; set; } = new List<string>();
    }
}
