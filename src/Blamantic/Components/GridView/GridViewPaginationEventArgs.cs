using System;

namespace BlamanticUI
{
    public class GridViewPaginationEventArgs:EventArgs
    {
        public GridViewPaginationEventArgs(int currentPage,int pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public int CurrentPage { get; }
        public int PageSize { get; }
    }
}
