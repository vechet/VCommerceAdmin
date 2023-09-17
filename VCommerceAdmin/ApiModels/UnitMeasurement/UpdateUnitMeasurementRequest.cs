﻿namespace VCommerceAdmin.ApiModels
{
    public class UpdateUnitMeasurementRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        public string? Abbreviation { get; set; }
        public short StatusId { get; set; }
    }
}