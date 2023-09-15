using Microsoft.EntityFrameworkCore;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Data;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Models;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContextFactory<VcommerceContext> _contextFactory;

        public CategoryRepository(IDbContextFactory<VcommerceContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public CreateCategoryResponse CreateCategory(CreateCategoryRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var newCategory = new Category
                    {
                        ParentId = req.ParentId,
                        Name = req.Name,
                        Memo = req.Memo,
                        IsSystemValue = false,
                        CreatedBy = 1,
                        CreatedDate = GlobalFunction.GetCurrentDateTime(),
                        StatusId = req.StatusId
                    };
                    context.Categories.Add(newCategory);
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new CreateCategoryResponse(newCategory);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("CategoryRepository/CreateCategory", ex, context);
                    return null;
                }
            }
        }

        public List<GetCategoriesResponse> GetCategories(GetCategoriesRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var filter = context.Categories.AsQueryable();

                    if(req.ParentId != 0)
                    {
                        filter = filter.Where(x => x.ParentId == req.ParentId);
                    }

                    if (!req.ShowAllRecord)
                    {
                        filter = filter.Where(x => x.Status.KeyName == "Active");
                    }

                    var result = filter.Select(x => new GetCategoriesResponse
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Memo = x.Memo,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedDate = x.ModifiedDate,
                        StatusId = x.StatusId,
                        StatusName = x.Status.Name,
                    }).OrderByDescending(x => x.Id).Skip(req.Skip).Take(req.Limit).ToList();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new List<GetCategoriesResponse>(result);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("CategoryRepository/GetCategorys", ex, context);
                    return null;
                }
            }
        }

        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var currentCategory = context.Categories.Find(req.Id);
                    currentCategory.ParentId = req.ParentId;
                    currentCategory.Name = req.Name;
                    currentCategory.Memo = req.Memo;
                    currentCategory.StatusId = req.StatusId;
                    currentCategory.ModifiedBy = 1;
                    currentCategory.ModifiedDate = GlobalFunction.GetCurrentDateTime();
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new UpdateCategoryResponse(currentCategory);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("CategoryRepository/UpdateCategory", ex, context);
                    return null;
                }
            }
        }
    }
}