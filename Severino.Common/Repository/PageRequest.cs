namespace Severino.Common.Repository
{
    public class PageRequest
    {
        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 1;
        public string SortProperty{ get; set; }
        public SortDirection? SortDirection { get; set; }
    }
}