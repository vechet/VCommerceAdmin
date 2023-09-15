using VCommerceAdmin.ApiModels;

namespace VCommerceAdmin.Repository.Interface
{
    public interface IProductTypeRepository
    {
        List<GetProductTypesResponse> GetProductTypes(GetProductTypesRequest req, out int code, out string msg);

        CreateProductTypeResponse CreateProductType(CreateProductTypeRequest req, out int code, out string msg);

        UpdateProductTypeResponse UpdateProductType(UpdateProductTypeRequest req, out int code, out string msg);
    }
}