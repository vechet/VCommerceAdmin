﻿using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Drawing.Imaging;
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

        public BaseResponse CreateBrand(CreateBrandRequest req)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    // check duplicate name
                    if (context.Brands.Any(x => x.Name.ToLower() == req.Name.ToLower()))
                    {
                        return new BaseResponse(0, ApiReturnError.DuplicateName.Value(), ApiReturnError.DuplicateName.Description());
                    }

                    //add new brand
                    var newBrand = new Brand
                    {
                        Name = req.Name,
                        Memo = req.Memo,
                        CreatedBy = 1,
                        CreatedDate = GlobalFunction.GetCurrentDateTime(),
                        StatusId = req.StatusId
                    };
                    context.Brands.Add(newBrand);
                    
                    //check add new photo
                    if(req.Photo != null)
                    {
                        var newPhotoAndVideo = new PhotoAndVideo
                        {
                            FileName = req.PhotoName,
                            SortOrder = 100
                        };
                        newBrand.PhotoAndVideos.Add(newPhotoAndVideo);
                    }
                    context.SaveChanges();

                    return new BaseResponse(newBrand.Id, ApiReturnError.Success.Value(), ApiReturnError.Success.Description());
                }
                catch (Exception ex)
                {
                    GlobalFunction.RecordErrorLog("BrandRepository/CreateBrand", ex, context);
                    return new BaseResponse(0, ApiReturnError.DbError.Value(), ApiReturnError.DbError.Description());
                }
            }
        }

        public GetBrandsResponse GetBrands(GetBrandsRequest req)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var result = context.Brands.Select(x => new BrandsResponse
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
                    return new GetBrandsResponse(result, ApiReturnError.Success.Value(), ApiReturnError.Success.Description());
                }
                catch (Exception ex)
                {
                    GlobalFunction.RecordErrorLog("BrandRepository/GetBrands", ex, context);
                    return new GetBrandsResponse(new List<BrandsResponse>(), ApiReturnError.DbError.Value(), ApiReturnError.DbError.Description());
                }
            }
        }

        public BaseResponse UpdateBrand(UpdateBrandRequest req)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    // check duplicate name
                    if (context.Brands.Any(x => x.Name.ToLower() == req.Name.ToLower() && x.Id != req.Id))
                    {
                        return new BaseResponse(0, ApiReturnError.DuplicateName.Value(), ApiReturnError.DuplicateName.Description());
                    }

                    //update brand
                    var currentBrand = context.Brands.Find(req.Id);
                    currentBrand.Name = req.Name;
                    currentBrand.Memo = req.Memo;
                    currentBrand.StatusId = req.StatusId;
                    currentBrand.ModifiedBy = 1;
                    currentBrand.ModifiedDate = GlobalFunction.GetCurrentDateTime();

                    //check update photo
                    if (req.Photo != null)
                    {
                        var currentPhoto = context.PhotoAndVideos.FirstOrDefault(x => x.BrandId == currentBrand.Id);
                        currentPhoto.FileName = req.PhotoName;
                    }
                    context.SaveChanges();

                    return new BaseResponse(currentBrand.Id, ApiReturnError.Success.Value(), ApiReturnError.Success.Description());
                }
                catch (Exception ex)
                {
                    GlobalFunction.RecordErrorLog("BrandRepository/UpdateBrand", ex, context);
                    return new BaseResponse(0, ApiReturnError.DbError.Value(), ApiReturnError.DbError.Description());
                }
            }
        }
    }
}