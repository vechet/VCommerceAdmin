using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.Repository.Interface
{
    public interface ISaleOrdersRepository
    {
        Task<GetSaleOrdersResponse> GetSaleOrders(GetSaleOrdersRequest req);
    }
}