using System.Collections.Generic;

namespace Severino.Common.Repository
{
    public interface IListPagedRequest
    {
        PageRequest Page { get; set; }
    }

    public interface IListPagedResponse
    {
        PageResponse Page { get; set; }
    }

    public interface IListPagedResponse<T> : IListPagedResponse
    {
        ICollection<T> Data { get; set; }
    }
}