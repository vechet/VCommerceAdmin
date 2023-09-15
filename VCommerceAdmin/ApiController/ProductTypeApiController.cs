using Microsoft.AspNetCore.Mvc;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.ApiController
{
    [Route("api")]
    [ApiController]
    public class ProductTypeApiController : ControllerBase
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeApiController(IProductTypeRepository ProductTypeRepository)
        {
            _productTypeRepository = ProductTypeRepository;
        }

        [HttpPost("v1/product-type/create-product-type")]
        public ApiResponse<CreateProductTypeResponse> CreateProductType([FromBody] CreateProductTypeRequest req)
        {
            var result = _productTypeRepository.CreateProductType(req, out int code, out string msg);
            return new ApiResponse<CreateProductTypeResponse>(result, code, msg);
        }

        [HttpPost("v1/product-type/get-product-types")]
        public ApiResponse<List<GetProductTypesResponse>> GetProductTypes([FromBody] GetProductTypesRequest req)
        {
            var result = _productTypeRepository.GetProductTypes(req, out int code, out string msg);
            return new ApiResponse<List<GetProductTypesResponse>>(result, code, msg);
        }

        [HttpPost("v1/product-type/update-product-type")]
        public ApiResponse<UpdateProductTypeResponse> UpdateProductType([FromBody] UpdateProductTypeRequest req)
        {
            var result = _productTypeRepository.UpdateProductType(req, out int code, out string msg);
            return new ApiResponse<UpdateProductTypeResponse>(result, code, msg);
        }
    }
}