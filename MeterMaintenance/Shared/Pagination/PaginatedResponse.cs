using System.Collections.Generic;
using System.Linq;

namespace Shared.Pagination
{
    public class PaginatedResponse<T>
    {
        public int CurrentPage { get; set; }   // PageNumber
        public int TotalPages { get; set; }       // TotalPages 
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }

        public PaginatedResponse(PagedList<T> pagedList)
        {
            CurrentPage = pagedList.CurrentPage;
            TotalPages = pagedList.TotalPages;
            PageSize = pagedList.PageSize;
            TotalCount = pagedList.TotalCount;
            Items = pagedList.ToList();
        }




    }


    public class PaginatedResponseNew<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNo { get; set; }
        public int RowsCount { get; set; }

        public PaginatedResponseNew(IEnumerable<T> items, int totalCount, int pageNo, int rowsCount)
        {
            Items = items;
            TotalCount = totalCount;
            PageNo = pageNo;
            RowsCount = rowsCount;
        }
    }

}
