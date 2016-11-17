using System.Collections.Generic;

namespace Data
{
    public class QueryResult<T>
    {
        public QueryResult(IEnumerable<T> queriedItems, int totalItemCount, int pageSize)
        {
            PageSize = pageSize;
            TotalItemCount = totalItemCount;
            QueriedItems = queriedItems ?? new List<T>();
        }

        public int TotalPageCount {
            get { return ResultsPagingUtility.CalculatePageCount(TotalItemCount, PageSize);  }
        }

        public int TotalItemCount { get; private set; }

        public IEnumerable<T> QueriedItems { get; set; }

        public int PageSize { get; private set; }
    }
}
