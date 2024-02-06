using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Services.Interface;

namespace VCommerceAdmin.ApiController
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class SaleOrderApiController : ControllerBase
    {
        private readonly ISaleOrdersService _saleOrdersService;

        public SaleOrderApiController(ISaleOrdersService saleOrdersService)
        {
            _saleOrdersService = saleOrdersService;
        }

        [HttpPost("v1/sale-order/create-sale-order")]
        public async Task<ApiResponse<BaseResponse>> CreateSaleOrder([FromBody] CreateSaleOrderRequest req)
        {
            return new ApiResponse<BaseResponse>(await _saleOrdersService.CreateSaleOrder(req));
        }

        [HttpPost("v1/sale-order/get-sale-orders")]
        public async Task<ApiResponse<GetSaleOrdersResponse>> GetSaleOrders([FromBody] GetSaleOrdersRequest req)
        {
            return new ApiResponse<GetSaleOrdersResponse>(await _saleOrdersService.GetSaleOrders(req));
        }

        [HttpPost("v1/sale-order/update-sale-order")]
        public async Task<ApiResponse<BaseResponse>> UpdateSaleOrder([FromBody] UpdateSaleOrderRequest req)
        {
            return new ApiResponse<BaseResponse>(await _saleOrdersService.UpdateSaleOrder(req));
        }

        [HttpPost("v1/sale-order/get-detial-sale-order")]
        public async Task<ApiResponse<GetDetailSaleOrderResponse>> GetDetailSaleOrderBrand([FromBody] GetDetailSaleOrderRequest req)
        {
            return new ApiResponse<GetDetailSaleOrderResponse>(await _saleOrdersService.GetDetailSaleOrder(req));
        }
    }
}