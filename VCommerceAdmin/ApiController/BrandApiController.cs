using Microsoft.AspNetCore.Mvc;
using VCommerceAdmin.CustomModels;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.ApiController
{
    [Route("api")]
    [ApiController]
    public class BrandApiController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;

        public BrandApiController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpPost("v1/brand/create-brand")]
        public ApiResponse<BrandCreateResponse> CreateBrand([FromBody] CreateBrandRequest req)
        {
            return new ApiResponse<BrandCreateResponse>(_brandRepository.BrandCreate(req));
        }

        [HttpPost("v1/brand/get-brands")]
        public ApiResponse<List<GetBrandsResponse>> GetBrands([FromBody] GetBrandsRequest req)
        {
            return new ApiResponse<List<GetBrandsResponse>>(_brandRepository.Brands(req));
        }

        [HttpPost("v1/brand/update-brand")]
        public ApiResponse<UpdateBrandResponse> UpdateBrand([FromBody] UpdateBrandRequest req)
        {
            return new ApiResponse<UpdateBrandResponse>(_brandRepository.BrandUpdate(req));
        }
    }
}
