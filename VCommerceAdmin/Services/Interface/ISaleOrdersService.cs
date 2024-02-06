using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.Services.Interface
{
    public interface ISaleOrdersService
    {
        Task<GetSaleOrdersResponse> GetSaleOrders(GetSaleOrdersRequest req);
        Task<GetDetailSaleOrderResponse> GetDetailSaleOrder(GetDetailSaleOrderRequest req);

        Task<BaseResponse> CreateSaleOrder(CreateSaleOrderRequest req);

        Task<BaseResponse> UpdateSaleOrder(UpdateSaleOrderRequest req);
    }
}
