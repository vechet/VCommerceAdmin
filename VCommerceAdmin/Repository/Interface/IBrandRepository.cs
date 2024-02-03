using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.Repository.Interface
{
    public interface IBrandRepository
    {
        GetBrandsResponse GetBrands(GetBrandsRequest req);
        
        GetDetailBrandResponse GetDetailBrand(GetDetailBrandRequest req);

        Task<BaseResponse> CreateBrand(CreateBrandRequest req);

        Task<BaseResponse> UpdateBrand(UpdateBrandRequest req);
    }
}