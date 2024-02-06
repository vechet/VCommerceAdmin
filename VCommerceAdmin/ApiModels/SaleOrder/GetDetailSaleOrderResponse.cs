using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels
{
    public class GetDetailSaleOrderResponse : BaseResponse
    {
        public DetailSaleOrderResponse SaleOrder { get; set; }
        public GetDetailSaleOrderResponse(DetailSaleOrderResponse saleOrder, int code, string msg)
        {
            SaleOrder = saleOrder;
            Code = code;
            Message = msg;
        }
    }

    public class DetailSaleOrderResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
    }
}