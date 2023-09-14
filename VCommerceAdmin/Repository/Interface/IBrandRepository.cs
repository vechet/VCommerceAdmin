using VCommerceAdmin.CustomModels;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.Repository.Interface
{
    public interface IBrandRepository
    {
        List<GetBrandsResponse> Brands(GetBrandsRequest req);
        BrandCreateResponse BrandCreate(CreateBrandRequest req);
        UpdateBrandResponse BrandUpdate(UpdateBrandRequest req);
    }
}
