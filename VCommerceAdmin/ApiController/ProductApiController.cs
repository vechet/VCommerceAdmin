using Microsoft.AspNetCore.Mvc;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.ApiController
{
    [Route("api")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductRepository _ProductRepository;

        public ProductApiController(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        [HttpPost("v1/product/create-product")]
        public ApiResponse<CreateProductResponse> CreateProduct([FromBody] CreateProductRequest req)
        {
            var result = _ProductRepository.CreateProduct(req, out int code, out string msg);
            return new ApiResponse<CreateProductResponse>(result, code, msg);
        }

        [HttpPost("v1/product/get-products")]
        public ApiResponse<List<GetProductsResponse>> GetProducts([FromBody] GetProductsRequest req)
        {
            var result = _ProductRepository.GetProducts(req, out int code, out string msg);
            return new ApiResponse<List<GetProductsResponse>>(result, code, msg);
        }

        [HttpPost("v1/product/update-product")]
        public ApiResponse<UpdateProductResponse> UpdateProduct([FromBody] UpdateProductRequest req)
        {
            var result = _ProductRepository.UpdateProduct(req, out int code, out string msg);
            return new ApiResponse<UpdateProductResponse>(result, code, msg);
        }
    }
}