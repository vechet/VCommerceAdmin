using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels
{
    public class GetSaleOrdersResponse : BaseResponse, IPageResponse
    {
        public List<SaleOrdersResponse> SaleOrders { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public GetSaleOrdersResponse(List<SaleOrdersResponse> saleOrders, PageResponse pageResponse, int code, string msg) 
        {
            SaleOrders = saleOrders;
            PageNumber = pageResponse.PageNumber;
            PageSize = pageResponse.PageSize;
            TotalPages = pageResponse.TotalPages;
            TotalRecords = pageResponse.TotalRecords;
            Code = code;
            Message = msg;
        }

        public GetSaleOrdersResponse(List<SaleOrdersResponse> saleOrders, int code, string msg)
        {
            SaleOrders = saleOrders;
            Code = code;
            Message = msg;
        }
    }

    public class SaleOrdersResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        public List<SaleOrderDetailResponse> SaleDetails { get; set; } = null!;
    }

    public class SaleOrderDetailResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}