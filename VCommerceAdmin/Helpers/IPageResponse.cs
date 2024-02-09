namespace VCommerceAdmin.Helpers
{
    //https://codewithmukesh.com/blog/pagination-in-aspnet-core-webapi/#google_vignette
    public interface IPageResponse
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }

    public class PageResponse
    {
        public PageResponse(int Page, int pageSize, int totalRecords)
        {
            Page = Page;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            TotalPages = Convert.ToInt32(Math.Ceiling((double)totalRecords / (double)pageSize)) ;
        }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }

    //public class PaginationFilter
    //{
    //    public int Page { get; set; } = 1;
    //    public int PageSize { get; set; } = 10;
    //    public PaginationFilter()
    //    {
    //        this.Page = 1;
    //        this.PageSize = 10;
    //    }
    //    public PaginationFilter(int Page, int pageSize)
    //    {
    //        this.Page = Page < 1 ? 1 : Page;
    //        this.PageSize = pageSize > 10 ? 10 : pageSize;
    //    }
    //}
}
