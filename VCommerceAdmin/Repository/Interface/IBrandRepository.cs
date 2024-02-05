using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.Repository.Interface
{
    public interface IBrandRepository
    {
        Task<GetBrandsResponse> GetBrands(GetBrandsRequest req);

        Task<GetDetailBrandResponse> GetDetailBrand(GetDetailBrandRequest req);

        Task<BaseResponse> CreateBrand(CreateBrandRequest req);

        Task<BaseResponse> UpdateBrand(UpdateBrandRequest req);
    }
}