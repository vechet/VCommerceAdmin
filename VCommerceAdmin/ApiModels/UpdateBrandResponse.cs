﻿using VCommerceAdmin.Models;
using Microsoft.IdentityModel.Tokens;
using VCommerceAdmin.ApiModels;

namespace VCommerceAdmin.ApiModels
{
    public class UpdateBrandResponse : GetBrandsResponse
    {
        public UpdateBrandResponse(Brand data)
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