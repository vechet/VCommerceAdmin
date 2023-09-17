﻿using VCommerceAdmin.Models;

namespace VCommerceAdmin.ApiModels
{
    public class UpdateCategoryResponse : GetBrandsResponse
    {
        public UpdateCategoryResponse(Category data)
        {
            Id = data.Id;
            Name = data.Name;
            Memo = data.Memo;
            Photo = data.PhotoAndVideos.FirstOrDefault(z => z.CategoryId == data.Id).FileName;
            CreatedBy = data.CreatedBy;
            CreatedDate = data.CreatedDate;
            ModifiedBy = data.ModifiedBy;
            ModifiedDate = data.ModifiedDate;
            StatusId = data.StatusId;
            StatusName = data.Status == null ? "" : data.Status.Name;
        }
    }
}