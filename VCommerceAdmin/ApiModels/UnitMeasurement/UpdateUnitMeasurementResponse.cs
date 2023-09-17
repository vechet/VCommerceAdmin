﻿using VCommerceAdmin.Models;

namespace VCommerceAdmin.ApiModels
{
    public class UpdateUnitMeasurementResponse : GetUnitMeasurementsResponse
    {
        public UpdateUnitMeasurementResponse(Um data)
        {
            Id = data.Id;
            Name = data.Name;
            Memo = data.Memo;
            Abbreviation = data.Abbreviation;
            CreatedBy = data.CreatedBy;
            CreatedDate = data.CreatedDate;
            ModifiedBy = data.ModifiedBy;
            ModifiedDate = data.ModifiedDate;
            StatusId = data.StatusId;
            StatusName = data.Status == null ? "" : data.Status.Name;
        }
    }
}