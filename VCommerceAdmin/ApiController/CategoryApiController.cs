using Microsoft.AspNetCore.Mvc;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.ApiController
{
    [Route("api")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApiController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost("v1/category/create-category")]
        public ApiResponse<CreateCategoryResponse> CreateCategory([FromBody] CreateCategoryRequest req)
        {
            var result = _categoryRepository.CreateCategory(req, out int code, out string msg);
            return new ApiResponse<CreateCategoryResponse>(result, code, msg);
        }

        [HttpPost("v1/category/get-categories")]
        public ApiResponse<List<GetCategoriesResponse>> GetCategories([FromBody] GetCategoriesRequest req)
        {
            var result = _categoryRepository.GetCategories(req, out int code, out string msg);
            return new ApiResponse<List<GetCategoriesResponse>>(result, code, msg);
        }

        [HttpPost("v1/category/update-category")]
        public ApiResponse<UpdateCategoryResponse> UpdateCategory([FromBody] UpdateCategoryRequest req)
        {
            var result = _categoryRepository.UpdateCategory(req, out int code, out string msg);
            return new ApiResponse<UpdateCategoryResponse>(result, code, msg);
        }
    }
}