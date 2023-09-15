using VCommerceAdmin.ApiModels;

namespace VCommerceAdmin.Repository.Interface
{
    public interface IBrandRepository
    {
        List<GetBrandsResponse> GetBrands(GetBrandsRequest req, out int code, out string msg);
        CreateBrandResponse CreateBrand(CreateBrandRequest req);
        UpdateBrandResponse UpdateBrand(UpdateBrandRequest req);
    }
}
