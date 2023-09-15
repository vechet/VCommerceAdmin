﻿using VCommerceAdmin.Models;

namespace VCommerceAdmin.ApiModels
{
    public class CreateCategoryResponse : GetCategoriesResponse
    {
        public CreateCategoryResponse(Category data)
        {
            Id = data.Id;
            Name = data.Name;
            Memo = data.Memo;
            CreatedBy = data.CreatedBy;
            CreatedDate = data.CreatedDate;
            ModifiedBy = data.ModifiedBy;
            ModifiedDate = data.ModifiedDate;
            StatusId = data.StatusId;
            StatusName = data.Status == null ? "" : data.Status.Name;
        }
    }
}