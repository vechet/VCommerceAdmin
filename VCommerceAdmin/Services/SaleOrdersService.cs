using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Repository;
using VCommerceAdmin.Repository.Interface;
using VCommerceAdmin.Services.Interface;

namespace VCommerceAdmin.Services
{
    public class SaleOrdersService : ISaleOrdersService
    {
        private readonly ISaleOrdersRepository _saleOrdersRepository;
        public SaleOrdersService(ISaleOrdersRepository saleOrdersRepository)
        {
            _saleOrdersRepository = saleOrdersRepository;
        }
        public async Task<GetSaleOrdersResponse> GetSaleOrders(GetSaleOrdersRequest req)
        {
            return await _saleOrdersRepository.GetSaleOrders(req);
        }
    }
}
