using Microsoft.EntityFrameworkCore;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.Data;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Models;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IDbContextFactory<VcommerceContext> _contextFactory;

        public BrandRepository(IDbContextFactory<VcommerceContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public CreateBrandResponse CreateBrand(CreateBrandRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var newBrand = new Brand
                    {
                        Name = req.Name,
                        Memo = req.Memo,
                        CreatedBy = 1,
                        CreatedDate = GlobalFunction.GetCurrentDateTime(),
                        StatusId = req.StatusId
                    };
                    context.Brands.Add(newBrand);
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new CreateBrandResponse(newBrand);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("BrandRepository/CreateBrand", ex, context);
                    return null;
                }
            }
        }

        public List<GetBrandsResponse> GetBrands(GetBrandsRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var result = context.Brands.Select(x => new GetBrandsResponse
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
                    return new List<GetBrandsResponse>(result);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("BrandRepository/GetBrands", ex, context);
                    return null;
                }
            }
        }

        public UpdateBrandResponse UpdateBrand(UpdateBrandRequest req, out int code, out string msg)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var currentBrand = context.Brands.Find(req.Id);
                    currentBrand.Name = req.Name;
                    currentBrand.Memo = req.Memo;
                    currentBrand.StatusId = req.StatusId;
                    currentBrand.ModifiedBy = 1;
                    currentBrand.ModifiedDate = GlobalFunction.GetCurrentDateTime();
                    context.SaveChanges();
                    code = ApiReturnError.Success.Value();
                    msg = ApiReturnError.Success.Description();
                    return new UpdateBrandResponse(currentBrand);
                }
                catch (Exception ex)
                {
                    code = ApiReturnError.DbError.Value();
                    msg = ApiReturnError.DbError.Description();
                    GlobalFunction.RecordErrorLog("BrandRepository/UpdateBrand", ex, context);
                    return null;
                }
            }
        }
    }
}