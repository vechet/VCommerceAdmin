using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.Repository.Interface
{
    public interface ISaleOrdersRepository
    {
        Task<GetSaleOrdersResponse> GetSaleOrders(GetSaleOrdersRequest req);
        Task<GetDetailSaleOrderResponse> GetDetailSaleOrder(GetDetailSaleOrderRequest req);

        Task<BaseResponse> CreateSaleOrder(CreateSaleOrderRequest req);

        Task<BaseResponse> UpdateSaleOrder(UpdateSaleOrderRequest req);
    }
}