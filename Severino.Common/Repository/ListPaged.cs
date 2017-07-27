using System;
using System.Collections.Generic;

namespace Severino.Common.Repository
{
    public class ListPaged<T> : IListPagedResponse<T>
    {
        public virtual ICollection<T> Data { get; set; }
        public virtual PageResponse Page { get; set; }
    }
}