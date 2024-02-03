using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.Repository.Interface
{
    public interface IBrandRepository
    {
        GetBrandsResponse GetBrands(GetBrandsRequest req);
        
        GetDetailBrandResponse GetDetailBrand(GetDetailBrandRequest req);

        BaseResponse CreateBrand(CreateBrandRequest req);

        BaseResponse UpdateBrand(UpdateBrandRequest req);
    }
}