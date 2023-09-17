using VCommerceAdmin.ApiModels;

namespace VCommerceAdmin.Repository.Interface
{
    public interface IProductRepository
    {
        List<GetProductsResponse> GetProducts(GetProductsRequest req, out int code, out string msg);

        CreateProductResponse CreateProduct(CreateProductRequest req, out int code, out string msg);

        UpdateProductResponse UpdateProduct(UpdateProductRequest req, out int code, out string msg);
    }
}