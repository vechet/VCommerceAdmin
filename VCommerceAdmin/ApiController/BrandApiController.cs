using Microsoft.AspNetCore.Mvc;
using VCommerceAdmin.ApiModels;
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
        public ApiResponse<CreateBrandResponse> CreateBrand([FromBody] CreateBrandRequest req)
        {
            var result = _brandRepository.CreateBrand(req, out int code, out string msg);
            return new ApiResponse<CreateBrandResponse>(result, code, msg);
        }

        [HttpPost("v1/brand/get-brands")]
        public ApiResponse<List<GetBrandsResponse>> GetBrands([FromBody] GetBrandsRequest req)
        {
            var result = _brandRepository.GetBrands(req, out int code, out string msg);
            return new ApiResponse<List<GetBrandsResponse>>(result, code, msg);
        }

        [HttpPost("v1/brand/update-brand")]
        public ApiResponse<UpdateBrandResponse> UpdateBrand([FromBody] UpdateBrandRequest req)
        {
            var result = _brandRepository.UpdateBrand(req, out int code, out string msg);
            return new ApiResponse<UpdateBrandResponse>(result, code, msg);
        }
    }
}
