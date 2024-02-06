using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;
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

        public async Task<BaseResponse> CreateSaleOrder(CreateSaleOrderRequest req)
        {
            return await _saleOrdersRepository.CreateSaleOrder(req);
        }

        public async Task<GetDetailSaleOrderResponse> GetDetailSaleOrder(GetDetailSaleOrderRequest req)
        {
            return await _saleOrdersRepository.GetDetailSaleOrder(req);
        }

        public async Task<GetSaleOrdersResponse> GetSaleOrders(GetSaleOrdersRequest req)
        {
            return await _saleOrdersRepository.GetSaleOrders(req);
        }

        public async Task<BaseResponse> UpdateSaleOrder(UpdateSaleOrderRequest req)
        {
            return await _saleOrdersRepository.UpdateSaleOrder(req);
        }
    }
}
