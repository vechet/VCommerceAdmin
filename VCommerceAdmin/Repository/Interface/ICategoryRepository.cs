using VCommerceAdmin.ApiModels;

namespace VCommerceAdmin.Repository.Interface
{
    public interface ICategoryRepository
    {
        List<GetCategoriesResponse> GetCategories(GetCategoriesRequest req, out int code, out string msg);

        CreateCategoryResponse CreateCategory(CreateCategoryRequest req, out int code, out string msg);

        UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest req, out int code, out string msg);
    }
}