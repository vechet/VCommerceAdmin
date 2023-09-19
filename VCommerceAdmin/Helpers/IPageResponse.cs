namespace VCommerceAdmin.Helpers
{
    //https://codewithmukesh.com/blog/pagination-in-aspnet-core-webapi/#google_vignette
    public interface IPageResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }

    public class PageResponse
    {
        public PageResponse(int pageNumber, int pageSize, int totalRecords)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            TotalPages = Convert.ToInt32(Math.Ceiling((double)totalRecords / (double)pageSize)) ;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }

    //public class PaginationFilter
    //{
    //    public int PageNumber { get; set; } = 1;
    //    public int PageSize { get; set; } = 10;
    //    public PaginationFilter()
    //    {
    //        this.PageNumber = 1;
    //        this.PageSize = 10;
    //    }
    //    public PaginationFilter(int pageNumber, int pageSize)
    //    {
    //        this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
    //        this.PageSize = pageSize > 10 ? 10 : pageSize;
    //    }
    //}
}
