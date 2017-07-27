namespace Severino.Common.Repository
{
    public class PageResponse
    {
        public long RecordCount { get; set; }
        public int PageCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortProperty { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}