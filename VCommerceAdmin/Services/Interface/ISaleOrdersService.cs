using VCommerceAdmin.ApiModels;

namespace VCommerceAdmin.Services.Interface
{
    public interface ISaleOrdersService
    {
        Task<GetSaleOrdersResponse> GetSaleOrders(GetSaleOrdersRequest req);
    }
}
