using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.Services.Interface
{
    public interface IBrandService
    {
        GetBrandsResponse GetBrands(GetBrandsRequest req);

        BaseResponse CreateBrand(CreateBrandRequest req);

        BaseResponse UpdateBrand(UpdateBrandRequest req);
    }
}
