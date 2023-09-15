using VCommerceAdmin.ApiModels;

namespace VCommerceAdmin.Repository.Interface
{
    public interface IBrandRepository
    {
        List<GetBrandsResponse> GetBrands(GetBrandsRequest req, out int code, out string msg);
        CreateBrandResponse CreateBrand(CreateBrandRequest req, out int code, out string msg);
        UpdateBrandResponse UpdateBrand(UpdateBrandRequest req, out int code, out string msg);
    }
}
