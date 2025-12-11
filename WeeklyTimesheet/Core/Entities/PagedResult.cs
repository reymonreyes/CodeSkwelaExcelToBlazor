namespace WeeklyTimesheet.Core.Entities
{
    public class PagedResult<T> where T : class
    {
        public PagedResult()
        {
        }
        public PagedResult(IEnumerable<T> data, int page, int size, int totalRecords)
        {
            Data = data;
            Page = page;
            Size = size;
            TotalRecords = totalRecords;
        }
        public IEnumerable<T> Data { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalRecords { get; set; }
    }
}
