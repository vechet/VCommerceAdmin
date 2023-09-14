using VCommerceAdmin.CustomModels;
using VCommerceAdmin.Data;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Models;
using VCommerceAdmin.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace VCommerceAdmin.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IDbContextFactory<VcommerceContext> _contextFactory;

        public BrandRepository(IDbContextFactory<VcommerceContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public BrandCreateResponse BrandCreate(CreateBrandRequest req)
        {
            using (var context = _contextFactory.CreateDbContext())
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
                return new BrandCreateResponse(newBrand, 0, ApiReturnError.Success.ToString());
            }
        }

        public List<GetBrandsResponse> Brands(GetBrandsRequest req)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Brands.Select(x => new GetBrandsResponse 
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
                }).OrderByDescending(x => x.Id).ToList();
            }
        }

        public UpdateBrandResponse BrandUpdate(UpdateBrandRequest req)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var currentBrand = context.Brands.Find(req.Id);
                currentBrand.Name = req.Name;
                currentBrand.Memo = req.Memo;
                currentBrand.StatusId = req.StatusId;
                currentBrand.ModifiedBy = 1;
                currentBrand.ModifiedDate = GlobalFunction.GetCurrentDateTime();
                context.SaveChanges();
                return new UpdateBrandResponse(currentBrand);
            }
        }
    }
}
