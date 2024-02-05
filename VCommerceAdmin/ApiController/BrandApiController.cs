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
    public class BrandApiController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandApiController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("v1/brand/create-brand")]
        public async Task<ApiResponse<BaseResponse>> CreateBrand([FromBody] CreateBrandRequest req)
        {
            return new ApiResponse<BaseResponse>(await _brandService.CreateBrand(req));
        }

        [HttpPost("v1/brand/get-brands")]
        public async Task<ApiResponse<GetBrandsResponse>> GetBrands([FromBody] GetBrandsRequest req)
        {
            return new ApiResponse<GetBrandsResponse>(await _brandService.GetBrands(req));
        }

        [HttpPost("v1/brand/update-brand")]
        public async Task<ApiResponse<BaseResponse>> UpdateBrand([FromBody] UpdateBrandRequest req)
        {
            return new ApiResponse<BaseResponse>(await _brandService.UpdateBrand(req));
        }

        [HttpPost("v1/brand/get-detial-brand")]
        public async Task<ApiResponse<GetDetailBrandResponse>> GetDetailBrand([FromBody] GetDetailBrandRequest req)
        {
            return new ApiResponse<GetDetailBrandResponse>(await _brandService.GetDetailBrand(req));
        }
    }
}