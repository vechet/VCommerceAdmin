using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.Services.Interface
{
    public interface IBrandService
    {
        GetBrandsResponse GetBrands(GetBrandsRequest req);

        GetDetailBrandResponse GetDetailBrand(GetDetailBrandRequest req);
        Task<BaseResponse> CreateBrand(CreateBrandRequest req);

        Task<BaseResponse> UpdateBrand(UpdateBrandRequest req);
    }
}
