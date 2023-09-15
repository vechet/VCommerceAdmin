using Microsoft.EntityFrameworkCore;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Data;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Models;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.Repository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly IDbContextFactory<VcommerceContext> _contextFactory;

        public ProductTypeRepository(IDbContextFactory<VcommerceContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public CreateProductTypeResponse CreateProductType(CreateProductTypeRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var newProductType = new ProductType
                    {
                        Name = req.Name,
                        Memo = req.Memo,
                        CreatedBy = 1,
                        CreatedDate = GlobalFunction.GetCurrentDateTime(),
                        StatusId = req.StatusId
                    };
                    context.ProductTypes.Add(newProductType);
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new CreateProductTypeResponse(newProductType);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("ProductTypeRepository/CreateProductType", ex, context);
                    return null;
                }
            }
        }

        public List<GetProductTypesResponse> GetProductTypes(GetProductTypesRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var result = context.ProductTypes.Select(x => new GetProductTypesResponse
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
                    return new List<GetProductTypesResponse>(result);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("ProductTypeRepository/GetProductTypes", ex, context);
                    return null;
                }
            }
        }

        public UpdateProductTypeResponse UpdateProductType(UpdateProductTypeRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var currentProductType = context.ProductTypes.Find(req.Id);
                    currentProductType.Name = req.Name;
                    currentProductType.Memo = req.Memo;
                    currentProductType.StatusId = req.StatusId;
                    currentProductType.ModifiedBy = 1;
                    currentProductType.ModifiedDate = GlobalFunction.GetCurrentDateTime();
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new UpdateProductTypeResponse(currentProductType);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("ProductTypeRepository/UpdateProductType", ex, context);
                    return null;
                }
            }
        }
    }
}