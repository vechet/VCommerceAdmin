using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Numerics;
using System.Security.Claims;
using VCommerceAdmin.ApiModels;
using VCommerceAdmin.ApiModels.Authentication;
using VCommerceAdmin.Data;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.Models;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IDbContextFactory<VcommerceContext> _contextFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public BrandRepository(
            IDbContextFactory<VcommerceContext> contextFactory,
            IHttpContextAccessor httpContextAccessor,
            UserManager<IdentityUser> userManager)
        {
            _contextFactory = contextFactory;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<BaseResponse> CreateBrand(CreateBrandRequest req)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    // check duplicate name
                    if (context.Brands.Any(x => x.Name.ToLower() == req.Name.ToLower()))
                    {
                        return new BaseResponse(0, ApiResponseStatus.DuplicateName.Value(), ApiResponseStatus.DuplicateName.Description());
                    }

                    var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var user = await _userManager.FindByIdAsync(userId);

                    //add new brand
                    var newBrand = new Brand
                    {
                        Name = req.Name,
                        Memo = req.Memo,
                        CreatedBy = user.Id,
                        CreatedDate = GlobalFunction.GetCurrentDateTime(),
                        StatusId = req.StatusId,
                        Version = 1
                    };
                    context.Brands.Add(newBrand);

                    //check add new photo
                    if (req.Photo != null)
                    {
                        var newPhotoAndVideo = new PhotoAndVideo
                        {
                            FileName = req.PhotoName,
                            SortOrder = 100
                        };
                        newBrand.PhotoAndVideos.Add(newPhotoAndVideo);
                    }
                    context.SaveChanges();

                    // add audit log
                    GlobalFunction.RecordAuditLog("Brand", "CreateBrand", newBrand.Id, newBrand.Name, newBrand.Version, GetAuditDescription(context, newBrand.Id), context);

                    return new BaseResponse(newBrand.Id, ApiResponseStatus.Success.Value(), ApiResponseStatus.Success.Description());
                }
                catch (Exception ex)
                {
                    GlobalFunction.RecordErrorLog("BrandRepository/CreateBrand", ex, context);
                    return new BaseResponse(0, ApiResponseStatus.DbError.Value(), ApiResponseStatus.DbError.Description());
                }
            }
        }

        public GetBrandsResponse GetBrands(GetBrandsRequest req)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var a = context.Users.ToList();

                    var data = context.Brands.Where(x => (req.isShowAll || (!req.isShowAll && x.Status.KeyName == "Active")));
                    var result = data.Select(x => new BrandsResponse
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Memo = x.Memo,
                        CreatedByUser = context.Users.FirstOrDefault(z => z.Id == x.CreatedBy).UserName,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate.ToString(GlobalVariable.dateFormat),
                        ModifiedByUser = x.ModifiedBy.IsNullOrEmpty() ? null : context.Users.FirstOrDefault(z => z.Id == x.ModifiedBy).UserName,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedDate = x.ModifiedDate.HasValue ? x.ModifiedDate.Value.ToString(GlobalVariable.dateFormat) : null,
                        StatusId = x.StatusId,
                        StatusName = x.Status.Name,
                    })
                    .OrderByDescending(x => x.Id)
                    .Skip((req.PageNumber - 1) * req.PageSize)
                    .Take(req.PageSize).ToList();

                    //pagination
                    var totalRecords = context.Brands.Count(x => (req.isShowAll || (!req.isShowAll && x.Status.KeyName == "Active")));
                    var pageResponse = new PageResponse(req.PageNumber, req.PageSize, totalRecords);
                    
                    return new GetBrandsResponse(result, pageResponse, ApiResponseStatus.Success.Value(), ApiResponseStatus.Success.Description());
                }
                catch (Exception ex)
                {
                    GlobalFunction.RecordErrorLog("BrandRepository/GetBrands", ex, context);
                    return new GetBrandsResponse(new List<BrandsResponse>(), ApiResponseStatus.DbError.Value(), ApiResponseStatus.DbError.Description());
                }
            }
        }

        public async Task<BaseResponse> UpdateBrand(UpdateBrandRequest req)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    // check duplicate name
                    if (context.Brands.Any(x => x.Name.ToLower() == req.Name.ToLower() && x.Id != req.Id))
                    {
                        return new BaseResponse(0, ApiResponseStatus.DuplicateName.Value(), ApiResponseStatus.DuplicateName.Description());
                    }

                    var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var user = await _userManager.FindByIdAsync(userId);

                    //update brand
                    var currentBrand = context.Brands.Find(req.Id);
                    currentBrand.Name = req.Name;
                    currentBrand.Memo = req.Memo;
                    currentBrand.StatusId = req.StatusId;
                    currentBrand.ModifiedBy = user.Id;
                    currentBrand.ModifiedDate = GlobalFunction.GetCurrentDateTime();
                    currentBrand.Version = currentBrand.Version + 1;

                    //check update photo
                    if (req.Photo != null)
                    {
                        var currentPhoto = context.PhotoAndVideos.FirstOrDefault(x => x.BrandId == currentBrand.Id);
                        currentPhoto.FileName = req.PhotoName;
                    }
                    context.SaveChanges();

                    // add audit log
                    GlobalFunction.RecordAuditLog("Brand", "UpdateBrand", currentBrand.Id, currentBrand.Name, currentBrand.Version, GetAuditDescription(context, currentBrand.Id), context);

                    return new BaseResponse(currentBrand.Id, ApiResponseStatus.Success.Value(), ApiResponseStatus.Success.Description());
                }
                catch (Exception ex)
                {
                    GlobalFunction.RecordErrorLog("BrandRepository/UpdateBrand", ex, context);
                    return new BaseResponse(0, ApiResponseStatus.DbError.Value(), ApiResponseStatus.DbError.Description());
                }
            }
        }

        public string GetAuditDescription(VcommerceContext context, int id)
        {
            var type = (context.Brands.Where(x => x.Id == id).Select(x => new
            {
                x.Id,
                x.Name,
                x.Memo,
                x.StatusId,
                StatusName = x.Status.Name,
                CreatedByUser = context.Users.FirstOrDefault(z => z.Id == x.CreatedBy).UserName,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedByUser = x.ModifiedBy.IsNullOrEmpty() ? null : context.Users.FirstOrDefault(z => z.Id == x.ModifiedBy).UserName,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                x.Version,
                PhotoName = context.PhotoAndVideos.Any(z => z.BrandId == x.Id) ? context.PhotoAndVideos.FirstOrDefault(z => z.BrandId == x.Id).FileName : "",
            })).FirstOrDefault();
            return JsonConvert.SerializeObject(type, Formatting.Indented, new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.IsoDateFormat });
        }

        public GetDetailBrandResponse GetDetailBrand(GetDetailBrandRequest req)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var result = context.Brands.Where(x => x.Id == req.Id && x.Status.KeyName == "Active")
                        .Select(x => new DetailBrandResponse
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Memo = x.Memo,
                            CreatedByUser = context.Users.FirstOrDefault(z => z.Id == x.CreatedBy).UserName,
                            CreatedBy = x.CreatedBy,
                            CreatedDate = x.CreatedDate.ToString(GlobalVariable.dateFormat),
                            ModifiedByUser = x.ModifiedBy.IsNullOrEmpty() ? null : context.Users.FirstOrDefault(z => z.Id == x.ModifiedBy).UserName,
                            ModifiedBy = x.ModifiedBy,
                            StatusId = x.StatusId,
                            StatusName = x.Status.Name,
                        }).FirstOrDefault();

                    return new GetDetailBrandResponse(result, ApiResponseStatus.Success.Value(), ApiResponseStatus.Success.Description());
                }
                catch (Exception ex)
                {
                    GlobalFunction.RecordErrorLog("BrandRepository/GetDetailBrand", ex, context);
                    return new GetDetailBrandResponse(new DetailBrandResponse(), ApiResponseStatus.DbError.Value(), ApiResponseStatus.DbError.Description());
                }
            }
        }
    }
}